using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CourseProject2022FallWPF.Converters
{
    internal class CurrencyNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return $"{value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ($"{value}".IsNullOrEmpty()) return "";
            if ($"{value}".Length < 3) return $"{value}".ToUpper();
            return $"{value}"[..3].ToUpper();
        }
    }
}
