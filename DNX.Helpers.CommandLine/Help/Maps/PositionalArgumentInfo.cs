using System.Reflection;
using CommandLine;
using DNX.Helpers.Strings;

#pragma warning disable 1591
namespace DNX.Helpers.CommandLine.Help.Maps
{
    public class PositionalArgumentInfo : BaseArgumentInfo
    {
        public int Position { get; protected set; }

        public PositionalArgumentInfo(MemberInfo memberInfo, ValueAttribute argument)
            : base(memberInfo, argument)
        {
            Name             = StringExtensions.CoalesceNullOrEmpty(argument.MetaName, memberInfo.Name);
            Position         = argument.Index;
            VerboseValueList = false;
        }

        public static PositionalArgumentInfo Create(MemberInfo memberInfo, ValueAttribute value)
        {
            var instance = new PositionalArgumentInfo(memberInfo, value);

            return instance;
        }
    }
}
