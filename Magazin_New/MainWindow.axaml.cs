using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Magazin_New;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        sign.Click += Sign_Click;
    }
    private void Sign_Click(object? sender, RoutedEventArgs e)
    {
        if (name.Text == "admin" && parol.Text == "admin")
        {
            admin taskWindow = new admin();
            taskWindow.Show();
            this.Close();
        }
        else if (name.Text == "user" && parol.Text == "user")
        {
            user taskWindow = new user();
            taskWindow.Show();
            this.Close();
        }
        else
        {
            error taskWindow = new error();
            taskWindow.Show();
        }
    }
}