using System;
using System.Globalization;
using System.Windows.Data;

namespace BaseballScoreboard;

internal class IsGreaterThanOrEqualToValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (double.TryParse(value.ToString(), out double v) && double.TryParse(parameter.ToString(), out double p))
        {
            return v >= p;
        }
        throw new ArgumentException($"{nameof(IsGreaterThanOrEqualToValueConverter)} only supports objects convertible to double.");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}