using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CommandLine;
using DNX.Helpers.Reflection;

#pragma warning disable 1591

namespace DNX.Helpers.CommandLine.Help.Maps
{
    /// <summary>
    /// Class ArgumentsMap.
    /// </summary>
    public class ArgumentsMap
    {
        protected Type Type { get; private set; }

        protected IList<PositionalArgumentInfo> PositionalArguments = new List<PositionalArgumentInfo>();
        protected IList<OptionArgumentInfo> OptionArguments = new List<OptionArgumentInfo>();

        public IOrderedEnumerable<KeyValuePair<string, List<OptionArgumentInfo>>> OptionArgumentsByGroup { get; private set; }

        public string ShortcutPrefix { get; private set; }

        public string NamePrefix { get; private set; }

        public int MaxOptionShortcutLength { get; private set; }

        public int MaxOptionNameLength { get; private set; }

        public IList<IDictionary<string, object>> Positional
        {
            get
            {
                return PositionalArguments
                    .Select(pa => pa.ToDictionary())
                    .ToList();
            }
        }

        public IList<IDictionary<string, object>> Options
        {
            get
            {
                return OptionArguments
                    .Select(oa => oa.ToDictionary())
                    .ToList();
            }
        }

        public ArgumentsMap(Type type)
        {
            Type = type;

            GetArgumentProperties(type)
                .Where(p => ArgumentInfo.IsPositionalArgument(p))
                .Select(p => ArgumentInfo.GetPositionalArgumentInfo(p))
                .ToList()
                .ForEach(p => PositionalArguments.Add(p));

            GetArgumentProperties(type)
                .Where(p => ArgumentInfo.IsOptionArgument(p))
                .Select(p => ArgumentInfo.GetOptionArgumentInfo(p))
                .Union(new [] { GenerateHelpOption() })
                .ToList()
                .ForEach(a => OptionArguments.Add(a));

            OptionArguments
                .ToList()
                .ForEach(opt =>
                {
                    MaxOptionShortcutLength = OptionArguments.Max(o => (o.Shortcut ?? string.Empty).Length);
                    MaxOptionNameLength     = OptionArguments.Max(o => (o.Name ?? string.Empty).Length);
                });

            var groups = OptionArguments
                .GroupBy(o => o.GroupName)
                .ToDictionary(o => o.Key, o => o.Min(x => x.GroupPosition))
                ;

            OptionArgumentsByGroup = OptionArguments
                .GroupBy(o => o.GroupName)
                .ToDictionary(o => o.Key, o => o.ToList())
                .OrderBy(g => groups[g.Key])
                ;
        }

        private static OptionArgumentInfo GenerateHelpOption()
        {
            var helpOption = new OptionAttribute('?', "help")
            {
                HelpText = "Display this Help page",
                Required = false,
                SetName  = "BuiltIn:99"
            };

            return OptionArgumentInfo.Create(null, helpOption);
        }

        private static IEnumerable<PropertyInfo> GetArgumentProperties(Type type)
        {
            return type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
                .ToList();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>System.Object.</returns>
        public static ArgumentsMap Create<T>()
        {
            return Create(typeof(T));
        }

        /// <summary>
        /// Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>ArgumentsMap.</returns>
        public static ArgumentsMap Create(Type type)
        {
            var argumentsMap = new ArgumentsMap(type);

            return argumentsMap;
        }

        public void ApplyParserSettings(ParserSettings parserSettings)
        {
            NamePrefix = parserSettings.EnableDashDash
                ? "--"
                : string.Empty;
        }
    }
}
