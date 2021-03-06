﻿using CommandLine;
using DNX.Helpers.CommandLine;
using DNX.Helpers.CommandLine.Interfaces;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace CommandLineTester
{
    /// <summary>
    /// Arguments class for command line
    /// </summary>
    public class Arguments : IParserSettingsCustomiser, IPostParseValidator
    {
        [Value(0, Required = true, HelpText = "The file to process")]
        public string FileName { get; set; }

        [Option('c', "CheckExists", Default = false, HelpText = "Check folder exists")]
        public bool CheckFolderExists { get; set; }

        public void CustomiseSettings(ParserSettings settings)
        {
            var extendedSettings = ParserExtendedSettings.GetExtendedSettings(settings);

            // Add custom parser settings here
            extendedSettings.Reset();
            //extendedSettings.ThrowOnParseFailure = true;
        }

        public void Validate()
        {
            // Add post-parse validation here
        }
    }

    public class CommandA
    {
        public void Run()
        {
        }
    }

    public class CommandB
    {
        public void Run()
        {
        }
    }

    public class CommandC
    {
        public void Run()
        {
        }
    }

    public class CommandD
    {
        public void Run()
        {
        }
    }
}
