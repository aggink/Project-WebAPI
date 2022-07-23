using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Company.WPF.Infrastructure.Converters;

[ValueConversion(typeof(bool), typeof(string))]
[MarkupExtensionReturnType(typeof(BoolenToStringConverter))]
public class BoolenToStringConverter : IValueConverter
{
    private readonly string Yes = "Да";
    private readonly string No = "Нет";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var flag = (bool)value;
        if (flag) return Yes;
        else return No;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var flag = (string)value;
        if (flag.Contains(Yes, StringComparison.OrdinalIgnoreCase)) return true;
        else return false;
    }
}