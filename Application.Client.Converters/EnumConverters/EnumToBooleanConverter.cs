using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Application.Utilities.Guard;

namespace Application.Client.Converters.EnumConverters
{
    public class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return DependencyProperty.UnsetValue;
            }

            if (!IsExistingEnumValue(value))
            {
                return DependencyProperty.UnsetValue;
            }

            object enumValue = ParseToEnum(value, parameter);

            return enumValue.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return DependencyProperty.UnsetValue;
            }

            return Enum.Parse(targetType, (string) parameter);
        }

        private static bool IsExistingEnumValue(object value)
        {
            Guard.ThrowIfNull(value, nameof(value));

            return Enum.IsDefined(value.GetType(), value);
        }

        private static object ParseToEnum(object value, object parameter)
        {
            return Enum.Parse(value.GetType(), (string)parameter);
        }
    }
}
