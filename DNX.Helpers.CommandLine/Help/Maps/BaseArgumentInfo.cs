using System;
using System.Collections;
using System.Reflection;
using CommandLine;
using DNX.Helpers.Reflection;
using DNX.Helpers.Validation;

namespace DNX.Helpers.CommandLine.Help.Maps
{
    #pragma warning disable 1591
    public class BaseArgumentInfo : IArgumentInfo
    {
        public MemberInfo MemberInfo { get; private set; }

        public BaseAttribute Argument { get; private set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public bool Visible { get; protected set; }

        public bool Hidden { get { return !Visible; } }

        public bool Required { get; protected set; }

        public bool Optional { get { return !Required; } }

        public string DefaultValue { get; protected set; }

        public int MinOccurs { get; protected set; }

        public int MaxOccurs { get; protected set; }

        public string ValueSeparator { get; protected set; }

        public string MetaValueList { get; protected set; }

        public bool VerboseValueList { get; protected set; }

        public string ValueList
        {
            get
            {
                if (ValueType != null && ValueType.IsEnum)
                {
                    var values = Enum.GetNames(ValueType);

                    return string.Join(ValueSeparator, values);
                }

                return null;
            }
        }

        public Type ValueType
        {
            get
            {
                var propertyInfo = MemberInfo as PropertyInfo;
                var fieldInfo = MemberInfo as FieldInfo;

                var type = propertyInfo != null
                    ? propertyInfo.PropertyType
                    : fieldInfo != null
                        ? fieldInfo.FieldType
                        : null;

                return type;
            }
        }

        public string ValueTypeName
        {
            get
            {
                return ValueType == null || ValueType == typeof(bool)
                    ? null
                    : ValueType.Name;
            }
        }

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

        protected BaseArgumentInfo(MemberInfo memberInfo, BaseAttribute argument)
        {
            Guard.IsNotNull(() => argument);

            MemberInfo       = memberInfo;
            Argument         = argument;
            Required         = argument.Required;
            Description      = argument.HelpText;
            DefaultValue     = argument.Default == null ? null : argument.Default.ToString();
            MetaValueList    = string.IsNullOrEmpty(argument.MetaValue) ? null : argument.MetaValue;
            Visible          = !argument.Hidden;
            MinOccurs        = argument.Min;
            MaxOccurs        = argument.Max;
            ValueSeparator   = ",";
            VerboseValueList = true;
        }
    }
}
