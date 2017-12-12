using System;
using System.Reflection;

namespace DNX.Helpers.CommandLine.Help.Maps
{
    #pragma warning disable 1591
    public class BaseArgumentInfo : IArgumentInfo
    {
        public MemberInfo MemberInfo { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }

        public string DefaultValue { get; set; }

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
            get { return ValueType == null ? null : ValueType.Name; }
        }

        protected BaseArgumentInfo(MemberInfo memberInfo)
        {
            MemberInfo = memberInfo;
        }
    }
}
