using System.Windows;
using System.Windows.Controls;

namespace RatingDatabase;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        if(sender is not DataGrid dg)
            return;
        if(dg.SelectedItem is null) {
            return;
        }
        dg.ScrollIntoView(dg.SelectedItem);
    }
}
