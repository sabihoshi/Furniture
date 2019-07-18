using System;
using System.Globalization;
using System.Windows.Data;

namespace Furniture.ViewModels.Quotation
{
    public class DecimalPercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              CultureInfo culture)
        {
            if (targetType != typeof(string) || value == null)
                return value;

            if (!(value is decimal num))
                return value;

            return $"{num *= 100}%";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  CultureInfo culture)
        {
            if (targetType != typeof(decimal) || value == null)
                return value;

            if (!(value is string str))
                return value;

            if (string.IsNullOrWhiteSpace(str))
                return value;

            str = str.TrimEnd(culture.NumberFormat.PercentSymbol.ToCharArray());

            if (decimal.TryParse(str, out var num))
                num /= 100;

            return num;
        }
    }
}