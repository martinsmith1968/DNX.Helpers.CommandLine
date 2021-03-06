﻿using System;
using System.Collections.Generic;
using System.Linq;
using DNX.Helpers.CommandLine.Templating.DotLiquid;
using DNX.Helpers.Reflection;
using DNX.Helpers.Strings;

namespace DNX.Helpers.CommandLine.Templating
{
    /// <inheritdoc />
    /// <summary>
    /// Class DotLiquidTemplateEngine.
    /// </summary>
    /// <seealso cref="T:DNX.Helpers.Console.CommandLine.Help.Templating.ITemplateEngine" />
    public abstract class BaseTemplateEngine : ITemplateEngine
    {
        /// <summary>
        /// The substitutables
        /// </summary>
        protected readonly IDictionary<string, object> Substitutables;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotLiquidTemplateEngine"/> class.
        /// </summary>
        protected BaseTemplateEngine()
        {
            Substitutables = new Dictionary<string, object>();
        }

        /// <inheritdoc />
        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            Substitutables.Clear();
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds the object.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="instance">The instance.</param>
        public void AddObject(string name, object instance)
        {
            var dict = instance as IDictionary<string, object>
                       ?? instance.ToDictionary();

            Substitutables[name] = dict;
        }

        /// <inheritdoc />
        /// <summary>
        /// Renders the specified template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public abstract string Render(string template);

        /// <inheritdoc />
        /// <summary>
        /// Renders the specified template lines.
        /// </summary>
        /// <param name="templateLines">The template lines.</param>
        /// <returns>System.String.</returns>
        public IList<string> Render(IList<string> templateLines)
        {
            var template = string.Join(Environment.NewLine, templateLines);

            var output = Render(template);

            var outputLines = output == null
                ? new List<string>()
                : output.SplitByText(Environment.NewLine).ToList();

            return outputLines;
        }
    }
}
