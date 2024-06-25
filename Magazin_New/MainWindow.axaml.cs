using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Magazin_New;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        sign.Click += Sign_Click;
        guest.Click += Quest_Click;
    }
    private void Quest_Click(object? sender, RoutedEventArgs e)
    {
        guest taskWindow = new guest();
        taskWindow.Show();
        this.Close();
    }
    public static class UserInfo
    {
        public static string UserType { get; set; }
    }
    private void Sign_Click(object? sender, RoutedEventArgs e)
    {
        if (name.Text == "admin" && parol.Text == "admin")
        {
            UserInfo.UserType = "admin";
            admin taskWindow = new admin();
            taskWindow.Show();
            this.Close();
        }
        else if (name.Text == "user" && parol.Text == "user")
        {
            UserInfo.UserType = "user";
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