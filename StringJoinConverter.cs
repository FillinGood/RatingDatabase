using System;
using System.Globalization;
using System.Windows.Data;

namespace RatingDatabase;
public class StringJoinConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value is not string[] arr)
            return "";
        return string.Join(", ", arr);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
