using System.Globalization;
using System.Windows.Data;
using Converter.MVVM.Model;

namespace Converter.MVVM.ViewModel;

public class FlagConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string code)
            return $"{CurrencyConverter.GetFlag(code)} {code}";
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
