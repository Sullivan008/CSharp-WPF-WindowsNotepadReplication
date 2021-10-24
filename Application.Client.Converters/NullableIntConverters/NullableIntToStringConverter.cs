using System;
using System.Globalization;
using System.Windows.Data;

namespace Application.Client.Converters.NullableIntConverters
{
    public class NullableIntToStringConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            int? integer = (int?)value;

            return integer?.ToString() ?? (object)string.Empty;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !int.TryParse((string)value, out int result) ? default(int?) : result;
        }
    }
}
