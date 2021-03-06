﻿using System.Collections.Generic;
using System.Linq;
using CommandLine;
using DNX.Helpers.CommandLine.Exceptions;
using DNX.Helpers.CommandLine.Interfaces;
using DNX.Helpers.CommandLine.Results;

namespace DNX.Helpers.CommandLine
{
    /// <summary>
    /// Class ParserResultExtensions.
    /// </summary>
    public static class ParserResultExtensions
    {
        /// <summary>
        /// Oks the specified result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Ok<T>(this ParserResult<T> result)
        {
            return result.SuccessResult() != null;
        }

        /// <summary>
        /// Returns the success result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>Parsed&lt;T&gt;.</returns>
        public static Parsed<T> SuccessResult<T>(this ParserResult<T> result)
        {
            return result as Parsed<T>;
        }

        /// <summary>
        /// Returns the failure result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>NotParsed&lt;T&gt;.</returns>
        public static NotParsed<T> ErrorResult<T>(this ParserResult<T> result)
        {
            return result as NotParsed<T>;
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>T.</returns>
        public static T GetArguments<T>(this ParserResult<T> result)
        {
            var successResult = result.SuccessResult();

            return successResult != null
                ? successResult.Value
                : default(T);
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>System.Collections.Generic.IEnumerable&lt;CommandLine.Error&gt;.</returns>
        public static IEnumerable<Error> GetErrors<T>(this ParserResult<T> result)
        {
            var errorResult = result.ErrorResult();

            return errorResult == null
                ? Enumerable.Empty<Error>()
                : errorResult.Errors;
        }

        /// <summary>
        /// Custom validation on a parsed arguments instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        public static void ValidateInstance<T>(this Parsed<T> result)
            where T : new()
        {
            var validator = result.Value as IPostParseValidator;
            if (validator != null)
            {
                validator.Validate();
            }
        }

        /// <summary>
        /// Post processes the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>ParserResult&lt;T&gt;.</returns>
        /// <exception cref="ExtendedParserResultException{T}"></exception>
        internal static void PostProcessResult<T>(this IExtendedParserResult<T> result)
            where T : new()
        {
            if (!result.Success)
            {
                var extendedSettings = ParserExtendedSettings.GetExtendedSettings(result.Parser.Settings);
                if (extendedSettings.ThrowOnParseFailure)
                {
                    throw new ExtendedParserResultException<T>(result.Result.ErrorResult().CreateExtendedResult(result.Parser));
                }
            }

            if (result.Success)
            {
                ValidateInstance(result.Result.SuccessResult());
            }
        }

        /// <summary>
        /// Creates the extended result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="parser">The parser.</param>
        /// <returns>IExtendedParserResult.</returns>
        public static IExtendedParserResult<T> CreateExtendedResult<T>(this ParserResult<T> result, Parser parser)
        {
            return new ExtendedParserResult<T>(result, parser);
        }
    }
}
