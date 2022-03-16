using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RatingDatabase;
public class BoolToVisConverter : DependencyObject, IValueConverter {
    public Visibility True {
        get => (Visibility)GetValue(TrueProperty); set => SetValue(TrueProperty, value);
    }
    public Visibility False {
        get => (Visibility)GetValue(FalseProperty); set => SetValue(FalseProperty, value);
    }

    public static readonly DependencyProperty TrueProperty =
        DependencyProperty.Register(nameof(True), typeof(Visibility), typeof(BoolToVisConverter), new PropertyMetadata(Visibility.Visible));
    public static readonly DependencyProperty FalseProperty =
        DependencyProperty.Register(nameof(False), typeof(Visibility), typeof(BoolToVisConverter), new PropertyMetadata(Visibility.Collapsed));

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return value is bool b && b ? True : False;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return value is Visibility v && v == True;
    }
}
