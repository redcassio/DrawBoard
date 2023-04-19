using System;
using System.Globalization;
using System.Windows.Data;

namespace DrawBoard
{
    public class NullCheckConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value?.ToString()) ? 0 : value;
        }
    }
}
