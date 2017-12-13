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
    internal enum PositionType { Above, Below }

    internal class ArgumentsRaw1
    {
        [Value(0, MetaName = "FileName", Required = true, HelpText = "The filename to process")]
        public string FileName { get; set; }

        [Value(1, MetaName = "Position", Required = false, Default = PositionType.Above, HelpText = "Where to start from")]
        public PositionType Position { get; set; }

        [Option('l', "lines", HelpText = "How many lines to process")]
        public int LineCount { get; set; }

        [Option('t', "trim", HelpText = "Trim lines as they are read")]
        public bool Trim { get; set; }
    }

    internal class ArgumentsUsage1
    {
        [Value(0, MetaName = "FileName", Required = true, HelpText = "The filename to process")]
        public string FileName { get; set; }

        [Value(1, MetaName = "Position", Required = false, Default = PositionType.Above, HelpText = "Where to start from")]
        public PositionType Position { get; set; }

        [Option('l', "lines", Required = true, HelpText = "How many lines to process", MetaValue = "E.g. 50")]
        public int LineCount { get; set; }

        [Option('t', "trim", HelpText = "Trim lines as they are read")]
        public bool Trim { get; set; }

        [Option('f', "footer", HelpText = "The footer text to write")]
        public string FooterText { get; set; }

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
            System.Console.WriteLine(autoHelpText);

            var myHelpText = HelpBuilder.BuildTemplatedHelpText(result);
            System.Console.WriteLine(myHelpText);

            var outputText = output.ToString();
            System.Console.WriteLine(outputText);

            success.ShouldBeFalse();
            failure.ShouldBeTrue();
        }
    }
}
