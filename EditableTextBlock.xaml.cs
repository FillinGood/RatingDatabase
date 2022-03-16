using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RatingDatabase;
public partial class EditableTextBlock : UserControl {
    public bool IsEdit {
        get => (bool)GetValue(IsEditProperty);
        set => SetValue(IsEditProperty, value);
    }
    public static readonly DependencyProperty IsEditProperty =
        DependencyProperty.Register(nameof(IsEdit), typeof(bool), typeof(EditableTextBlock));

    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(EditableTextBlock));

    public Command DoubleClickCommand { get; }
    private void DoubleClick() {
        IsEdit = true;
    }

    public EditableTextBlock() {
        DoubleClickCommand = new(DoubleClick);
        InitializeComponent();
    }

    private void TextBox_LostFocus(object sender, RoutedEventArgs e) {
        IsEdit = false;
        int v = int.Parse(tb.Text);
        if(v < 0)
            v = 0;
        else if(v > 10)
            v = 10;
        Text = v.ToString();
    }

    private static readonly Key[] AllowedKeys = new[] {
        Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9, Key.D0,
        Key.Enter, Key.Back, Key.Left, Key.Right, Key.Delete
        };

    private void TextBox_KeyDown(object sender, KeyEventArgs e) {
        if(!AllowedKeys.Contains(e.Key))
            e.Handled = true;
    }
}
