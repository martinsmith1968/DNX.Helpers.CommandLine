﻿using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using CommandLine;
using DNX.Helpers.Assemblies;
using DNX.Helpers.CommandLine.Help;
using DNX.Helpers.CommandLine.Help.Maps;
using DNX.Helpers.CommandLine.Templating.DotLiquid;
using DNX.Helpers.Linq;
using DNX.Helpers.Reflection;
using NUnit.Framework;
using SampleApp;
using Shouldly;

namespace Test.DNX.Helpers.CommandLine.CommandLine.Templating.DotLiquid
{
    internal class TestArguments
    {

    }

    internal class TestArguments2
    {
        [Value(0, Required = true, HelpText = "The file to process")]
        public string FileName { get; set; }

        [Value(1, Required = false, HelpText = "The format to read the file in")]
        public string Format { get; set; }

        [Option('c', "CheckExists", Default = false, HelpText = "Check folder exists")]
        public bool CheckFolderExists { get; set; }

        [Option('m', "mode", Default = FileMode.Text, HelpText = "The mode to read the file in")]
        public FileMode Mode { get; set; }
    }

    [TestFixture]
    public class DotLiquidTemplateEngineTests
    {
        private DotLiquidTemplateEngine _templateEngine;

        [SetUp]
        public void TestInitialise()
        {
            _templateEngine = new DotLiquidTemplateEngine();
        }

        [Test]
        public void RenderTest()
        {
            // Arrange
            var assemblyDetails = new AssemblyDetails(Assembly.GetExecutingAssembly());
            _templateEngine.AddObject("Program", assemblyDetails);

            var argumentsMap = ArgumentsMap.Create<TestArguments>();
            _templateEngine.AddObject("Arguments", argumentsMap);

            var errors = new List<IDictionary<string, object>>()
            {
                new ParserErrorInfo() {Message = "Invalid argument: -k"}.ToDictionary()
            };

            dynamic result = new ExpandoObject();
            result.Errors = errors;
            result.Failed = errors.HasAny();

            _templateEngine.AddObject("ParserResult", result);

            // Act
            var resultText = _templateEngine.Render(Templates.StandardTemplate);

            // Assert
            resultText.ShouldNotBeNullOrEmpty();
            resultText.Length.ShouldBeGreaterThan(0);

            //resultLines.Count.ShouldBe(Templates.StandardTemplateLines.Length - 1);
            //
            //resultLines.Skip(0).First().ShouldBe(string.Format("{0} v{1} - {2}", assemblyDetails.Title, assemblyDetails.SimplifiedVersion, assemblyDetails.Description));
            //resultLines.Skip(1).First().ShouldBe(string.Format("{0}", assemblyDetails.Copyright));
            //resultLines.Skip(2).First().ShouldBe("");
            //resultLines.Skip(3).First().ShouldBe("Usage:");
            //resultLines.Skip(4).First().ShouldBe(string.Format("{0}", assemblyDetails.FileName));
        }

        [Test]
        public void HelpBuilder_Render_Test()
        {
            // Arrange
            var assemblyDetails = new AssemblyDetails(Assembly.GetExecutingAssembly());
            _templateEngine.AddObject("Program", assemblyDetails);

            var argumentsMap = ArgumentsMap.Create<TestArguments2>();
            _templateEngine.AddObject("Arguments", argumentsMap);

            dynamic result = new ExpandoObject();
            result.Failed = true;
            result.Errors = new List<IDictionary<string, object>>()
            {
            };

            _templateEngine.AddObject("ParserResult", result);

            // Act
            var resultText = _templateEngine.Render(Templates.StandardTemplate);

            // Assert
            resultText.ShouldNotBeNullOrEmpty();
            resultText.Length.ShouldBeGreaterThan(0);

            //resultLines.Count.ShouldBe(Templates.StandardTemplateLines.Length - 1);
            //
            //resultLines.Skip(0).First().ShouldBe(string.Format("{0} v{1} - {2}", assemblyDetails.Title, assemblyDetails.SimplifiedVersion, assemblyDetails.Description));
            //resultLines.Skip(1).First().ShouldBe(string.Format("{0}", assemblyDetails.Copyright));
            //resultLines.Skip(2).First().ShouldBe("");
            //resultLines.Skip(3).First().ShouldBe("Usage:");
            //resultLines.Skip(4).First().ShouldBe(string.Format("{0}", assemblyDetails.FileName));
        }
    }
}
