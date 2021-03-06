﻿using System;
using DNX.Helpers.Assemblies;
using DNX.Helpers.CommandLine;
using DNX.Helpers.CommandLine.Exceptions;
using DNX.Helpers.CommandLine.Results;
using DNX.Helpers.Console.Exceptions;

namespace CommandLineTester
{
    /// <summary>
    /// Program controller class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.Int32.</returns>
        private static int Main(string[] args)
        {
            try
            {
                var result = ParserHelper.GetParserAndParse<Arguments>(args)
                    .WithParsed(Run);

                var result2 = ParserHelper.GetParserAndParse<CommandA, CommandB, CommandC, CommandD>(args)
                    .WithParsed<CommandA>(a => a.Run())
                    .WithParsed<CommandB>(b => b.Run())
                    .WithParsed<CommandC>(c => c.Run())
                    .WithParsed<CommandD>(d => d.Run())
                    ;

                return result.Success ? 0 : 1;
            }
            catch (ExtendedParserResultException<Arguments>)
            {
                return 1;
            }
            catch (ExtendedParserResultException ex)
            {
                var failureA = ex.GetFailureResultAs<CommandA>();
                var failureB = ex.GetFailureResultAs<CommandB>();
                var failureC = ex.GetFailureResultAs<CommandC>();
                var failureD = ex.GetFailureResultAs<CommandD>();

                return 1;
            }
            catch (ReturnCodeException ex)
            {
                Console.WriteLine(ex);

                return ex.ReturnCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return ReturnCodeException.MaximumReturnCode;
            }
        }

        /// <summary>
        /// Runs the program using the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        private static void Run(Arguments arguments)
        {
            var assemblyDetails = new AssemblyDetails();

            //ConsoleHelper.DisplayHeader(assemblyDetails);
            //ConsoleHelper.Display();

            // TODO: Functionality here
        }
    }
}
