using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Company.WPF.Infrastructure.Converters;

public class NumberRowConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        DataGridRow row = (DataGridRow)value;
        if (row == null) return null;
        return row!.GetIndex() + 1;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
