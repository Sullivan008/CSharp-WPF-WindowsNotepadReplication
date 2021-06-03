using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Application.Client.Core.Exceptions;

namespace Application.Utilities.Extensions
{
    public static class EnumExtension
    {
        public static string ToEnumMemberAttrValue<TEnum>(this TEnum value) where TEnum : Enum
        {
            EnumMemberAttribute enumMemberAttr = GetAttribute<EnumMemberAttribute>(value);

            string enumMemberAttrValue = enumMemberAttr.Value;

            return !string.IsNullOrWhiteSpace(enumMemberAttrValue) ? enumMemberAttrValue : throw new ArgumentNullException(nameof(value), "The value cannot be null!");
        }

        private static TAttributeType GetAttribute<TAttributeType>(this Enum value)
        {
            Type type = value.GetType();
            MemberInfo[] memberInfo = type.GetMember(value.ToString());

            object[] attributes = memberInfo[0].GetCustomAttributes(typeof(TAttributeType), false);
            object attribute = attributes.SingleOrDefault();

            if (attribute == null)
            {
                throw new MissingExpectedAttributeException($"The following attribute is missing! {nameof(TAttributeType).ToUpper()}: {typeof(TAttributeType)}");
            }

            return (TAttributeType)attribute;
        }
    }
}
