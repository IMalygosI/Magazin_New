using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Magazin_New;

public partial class bagodarim : Window
{
    public bagodarim()
    {
        InitializeComponent();
        magazin.Click += Click_magazin;
    }
    public void Click_magazin(object sender, RoutedEventArgs args){
        this.Close();
    }
}