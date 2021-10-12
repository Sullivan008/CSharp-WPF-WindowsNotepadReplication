using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Application.Utilities.Extensions.Exceptions;

namespace Application.Utilities.Extensions
{
    public static class EnumExtension
    {
        public static string GetEnumMemberAttrValue<TEnum>(this TEnum @this) where TEnum : Enum
        {
            EnumMemberAttribute enumMemberAttr = @this.GetAttribute<EnumMemberAttribute>();

            return !string.IsNullOrWhiteSpace(enumMemberAttr.Value) ? enumMemberAttr.Value : throw new ArgumentNullException(nameof(@this), "The value cannot be null!");
        }

        private static TAttributeType GetAttribute<TAttributeType>(this Enum @this)
        {
            Type type = @this.GetType();
            MemberInfo[] memberInfo = type.GetMember(@this.ToString());

            object[] attributes = memberInfo[0].GetCustomAttributes(typeof(TAttributeType), false);
            object? attribute = attributes.SingleOrDefault();

            if (attribute == null)
            {
                throw new MissingExpectedAttributeException($"The following attribute is missing! {nameof(TAttributeType).ToUpper()}: {typeof(TAttributeType)}");
            }

            return (TAttributeType)attribute;
        }
    }
}
