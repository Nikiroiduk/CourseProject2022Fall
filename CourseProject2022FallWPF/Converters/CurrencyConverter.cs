using System;
using System.Windows.Data;

namespace CourseProject2022FallWPF.Converters
{
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return $"{value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            float returnedValue;

            if (float.TryParse((string)value, out returnedValue))
            {
                return returnedValue;
            }

            return 0;
        }
    }
}
