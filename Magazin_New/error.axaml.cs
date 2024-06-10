using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Magazin_New;

public partial class error : Window
{
    public error()
    {
        InitializeComponent();
        exit.Click += Exit_Click;
    }
    private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close();
    }
}