using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RatingDatabase;
public class RatingColorConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value is not int rating)
            return Brushes.White;
        return rating switch {
            int x when x <= 3 => Brushes.Red,
            int x when x > 3 && x <= 6 => Brushes.Yellow,
            int x when x > 6 && x <= 9 => Brushes.Green,
            _ => Brushes.Cyan
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
