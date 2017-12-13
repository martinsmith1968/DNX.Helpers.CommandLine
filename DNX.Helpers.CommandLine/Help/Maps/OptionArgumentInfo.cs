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
        public string Shortcut { get; protected set; }

        public string GroupName { get; protected set; }

        public int GroupPosition { get; protected set; }

        public bool HasGroup
        {
            get { return !string.IsNullOrEmpty(GroupName); }
        }

        public OptionArgumentInfo(MemberInfo memberInfo, OptionAttribute argument)
            : base(memberInfo, argument)
        {
            Shortcut       = argument.ShortName;
            Name           = argument.LongName;
            GroupName      = GetGroupName(argument.SetName);
            GroupPosition  = GetGroupPosition(argument.SetName);
            ValueSeparator = char.IsControl(argument.Separator)
                ? ","
                : argument.Separator.ToString();
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

        public static OptionArgumentInfo Create(MemberInfo memberInfo, OptionAttribute option)
        {
            var instance = new OptionArgumentInfo(memberInfo, option);

            return instance;
        }
    }
}
