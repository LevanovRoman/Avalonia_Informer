using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MyApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void Clear_OnClick(object? sender, RoutedEventArgs e)
    {
        Clear();
        StatusBar.Text = "Cleared!";
    }

    private void Clear()
    {
        InputFirstName.Clear();
        InputLastName.Clear();
    }

    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        var first = InputFirstName.Text;
        var last = InputLastName.Text;

        if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last))
        {
            StatusBar.Text = "Warning! One of the fields is empty";
            return;
        }
       
        using var file = new StreamWriter("output.dat", append: true);
        file.WriteLine($"{last} {first}");
        Clear();
        StatusBar.Text = "Saved!";
    }
}