﻿using System;
using CommandLine;
using DNX.Helpers.CommandLine.Interfaces;
using DNX.Helpers.Console;
using DNX.Helpers.Reflection;

namespace DNX.Helpers.CommandLine
{
    /// <summary>
    /// Class ParserSettingsCustomiserHelper.
    /// </summary>
    public class ParserSettingsHelper
    {
        /// <summary>
        /// The default parser customiser
        /// </summary>
        public static Action<ParserSettings> DefaultParserCustomiser = (settings) =>
        {
            settings.IgnoreUnknownArguments    = false;
            settings.CaseInsensitiveEnumValues = true;
            settings.HelpWriter                = null;
            settings.MaximumDisplayWidth       = ConsoleHelper.GetConsoleWidth(settings.MaximumDisplayWidth);
        };

        /// <summary>
        /// Determines whether this instance can customise the settings for the specified parser.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns><c>true</c> if this instance can customise the settings for the specified parser; otherwise, <c>false</c>.</returns>
        public static bool CanCustomiseSettings<T>()
            where T : new()
        {
            return CanCustomiseSettings(typeof(T));
        }

        /// <summary>
        /// Determines whether this instance can customise the settings for the specified parser.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if this instance can customise the settings for the specified parser; otherwise, <c>false</c>.</returns>
        public static bool CanCustomiseSettings(Type type)
        {
            return type.IsA<IParserSettingsCustomiser>();
        }

        /// <summary>
        /// Gets the settings customiser.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Action&lt;ParserSettings&gt;.</returns>
        public static Action<ParserSettings> GetSettingsCustomiser<T>()
            where T : new()
        {
            var customiser = new T() as IParserSettingsCustomiser;

            return customiser == null
                ? ParserSettingsChain.Create()
                : ParserSettingsChain.Create(customiser.CustomiseSettings);
        }
    }
}
