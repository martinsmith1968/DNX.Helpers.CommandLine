using System;
using System.Linq;
using System.Reflection;
using CommandLine;
using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Strings;

#pragma warning disable 1591
namespace DNX.Helpers.CommandLine.Help.Maps
{
    public class OptionArgumentInfo : BaseArgumentInfo
    {
        public string Shortcut { get; set; }

        public string GroupName { get; set; }

        public int GroupPosition { get; set; }

        public bool HasGroup
        {
            get { return !string.IsNullOrEmpty(GroupName); }
        }

        public bool Optional { get { return !Required; } }

        public string ValueList { get; set; }

        public string ValueSeparator { get; set; }

        public OptionArgumentInfo(MemberInfo memberInfo)
            : base(memberInfo)
        {
        }

        public static OptionArgumentInfo Create(MemberInfo memberInfo, OptionAttribute option)
        {
            if (option == null)
            {
                return null;
            }

            var instance = new OptionArgumentInfo(memberInfo)
            {
                Shortcut       = option.ShortName,
                Name           = option.LongName,
                Description    = option.HelpText,
                GroupName      = GetGroupName(option.SetName),
                GroupPosition  = GetGroupPosition(option.SetName),
                Required       = option.Required,
                DefaultValue   = option.Default == null ? null : option.Default.ToString(),
                ValueSeparator = char.IsControl(option.Separator) ? "," : option.Separator.ToString(),
            };

            if (instance.ValueType != null && instance.ValueType.IsEnum)
            {
                var values = Enum.GetNames(instance.ValueType);

                instance.ValueList = string.Join(instance.ValueSeparator, values);
            }

            return instance;
        }

        private static string GetGroupName(string setName)
        {
            var parts = setName.Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var name = StringExtensions.CoalesceNullOrEmpty(parts)
                ?? string.Empty;

            return name;
        }

        private static int GetGroupPosition(string setName)
        {
            var parts = setName.Split(":", StringSplitOptions.RemoveEmptyEntries);

            var positionText = setName.Length > 0
                ? parts.Last()
                : null;

            var position = positionText.ToInt32(50);

            return position;
        }
    }
}
