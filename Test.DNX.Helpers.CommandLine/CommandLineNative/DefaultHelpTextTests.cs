using System.Collections.Generic;
using System.IO;
using System.Text;
using CommandLine;
using CommandLine.Text;
using DNX.Helpers.CommandLine.Help;
using DNX.Helpers.Console;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.CommandLine.CommandLineNative
{
    internal enum PositionType {  Above, Below }

    internal class ArgumentsRaw1
    {
        [Value(0, MetaName = "FileNameX", Required = true, HelpText = "The filename to process")]
        public string FileName { get; set; }

        [Option('p', "position", Required = true, HelpText = "Where to start from")]
        public PositionType Position { get; set; }

        [Option('l', "lines", HelpText = "How many lines to process")]
        public int LineCount { get; set; }
    }

    internal class ArgumentsUsage1
    {
        [Value(0, Required = true, HelpText = "The filename to process")]
        public string FileName { get; set; }

        [Option('p', "position", Required = true, HelpText = "Where to start from")]
        public PositionType Position { get; set; }

        [Option('l', "lines", Default = 5, HelpText = "How many lines to process")]
        public int LineCount { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get { yield return new Example("Default", UnParserSettings.WithGroupSwitchesOnly(), new ArgumentsUsage1 { FileName = "[filename]" }); }
        }
    }

    [TestFixture]
    public class DefaultHelpTextTests
    {
        [Test]
        public void ArgumentsRaw1_Test()
        {
            // Arrange
            var success = false;
            var failure = false;
            var args = new string[] { };
            var output = new StringBuilder();
            var outputWriter = new StringWriter(output);

            // Act
            var parser = new Parser(config => config.HelpWriter = outputWriter);
            var result = parser.ParseArguments<ArgumentsRaw1>(args)
                .WithParsed(o => success = true)
                .WithNotParsed(o => failure = true)
                ;

            // Assert
            var outputText = output.ToString();
            System.Console.WriteLine(outputText);

            success.ShouldBeFalse();
            failure.ShouldBeTrue();
        }

        [Test]
        public void ArgumentsUsage1_Test()
        {
            // Arrange
            var success = false;
            var failure = false;
            var args = new string[] { };
            var output = new StringBuilder();
            var outputWriter = new StringWriter(output);

            // Act
            var parser = new Parser(config => config.HelpWriter = outputWriter);
            var result = parser.ParseArguments<ArgumentsUsage1>(args)
                    .WithParsed(o => success = true)
                    .WithNotParsed(o => failure = true)
                ;

            // Assert
            var autoHelp = HelpText.AutoBuild(result,
                text =>
                {
                    text.AdditionalNewLineAfterOption = false;
                    text.AddPreOptionsLine(" ");
                    text.AddEnumValuesToHelpText = true;
                    return text;
                },
                example => example,
                false,
                ConsoleHelper.GetConsoleWidth()
                );
            var autoHelpText = autoHelp.ToString();

            var myHelpText = HelpBuilder.BuildTemplatedHelpText(result);

            var outputText = output.ToString();
            System.Console.WriteLine(outputText);

            success.ShouldBeFalse();
            failure.ShouldBeTrue();
        }
    }
}
