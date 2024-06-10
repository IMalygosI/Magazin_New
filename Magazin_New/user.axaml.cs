using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Magaz;

namespace Magazin_New;

public partial class user : Window
{
    public user()
    {
        InitializeComponent();
        
        if (0 <= ShopTab.SaveMagaz.Product.Count - 1)
        {
            for (int i = 0; i < ShopTab.SaveMagaz.Product.Count; i++)
            {
                ShopTab.SaveMagaz.Product[i].Id = i;
            }
            AAA.ItemsSource = ShopTab.SaveMagaz.Product.ToList();
        }
        exit.Click += Click_exit;
        in_korz.Click += Click_korz;
        ssil("");
    }
    private void ssil(string type)
    {
        AAA.ItemsSource = ShopTab.SaveMagaz.Product.Select(x => new { x.image, x.ProductName, x.PraiseProduct, x.Id });
    }
    public void basket(object sender, RoutedEventArgs args)
    {
        ShopTab.SaveMagaz.korzinaa.Add(ShopTab.SaveMagaz.Product[(int)(sender as Button)!.Tag!]);
    }
    public void Click_korz(object sender, RoutedEventArgs args)
    {
        basket taskWindow = new basket();
        taskWindow.Show();
    }
    public void Click_exit(object sender, RoutedEventArgs args)
    {
        MainWindow taskWindow = new MainWindow();
        taskWindow.Show();
        this.Close();
    }
}
