using System.Collections;
using System.Reflection;
using CommandLine;
using DNX.Helpers.Reflection;
using DNX.Helpers.Strings;

#pragma warning disable 1591
namespace DNX.Helpers.CommandLine.Help.Maps
{
    public class PositionalArgumentInfo : BaseArgumentInfo
    {
        public int Position { get; set; }

        public bool Optional { get { return !Required; } }

        public bool Hidden { get; set; }

        public int MinOccurs { get; set; }

        public int MaxOccurs { get; set; }

        public bool IsArray
        {
            get
            {
                var type = ValueType;

                if (type == null)
                {
                    return false;
                }

                if (type.IsValueType) return false;
                if (type == typeof(string)) return false;

                return type.IsA(typeof(IEnumerable));
            }
        }

        public PositionalArgumentInfo(MemberInfo memberInfo)
            : base(memberInfo)
        {
        }

        public static PositionalArgumentInfo Create(MemberInfo memberInfo, ValueAttribute value)
        {
            if (value == null)
            {
                return null;
            }

            var instance = new PositionalArgumentInfo(memberInfo)
            {
                Name         = StringExtensions.CoalesceNullOrEmpty(value.MetaName, memberInfo.Name),
                Description  = value.HelpText,
                Position     = value.Index,
                Required     = value.Required,
                Hidden       = value.Hidden,
                DefaultValue = value.Default == null ? null : value.Default.ToString(),
                MinOccurs    = value.Min,
                MaxOccurs    = value.Max,
            };

            return instance;
        }
    }
}
