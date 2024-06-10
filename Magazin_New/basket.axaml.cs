using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Magaz;

namespace Magazin_New;

public partial class basket : Window
{
    public basket()
    {
        InitializeComponent();
        if (0 <= ShopTab.SaveMagaz.korzinaa.Count - 1)
        {
            for (int i = 0; i < ShopTab.SaveMagaz.korzinaa.Count; i++)
            {
                ShopTab.SaveMagaz.korzinaa[i].Id = i;
            }
            AA.ItemsSource = ShopTab.SaveMagaz.korzinaa.ToList();
        }
        exitA.Click += Click_exit;
        ssil();
    }
    private void ssil()
    {
        AA.ItemsSource = ShopTab.SaveMagaz.korzinaa.Select(x => new {x.image, x.ProductName, x.PraiseProduct, x.Id });
        Colvo.Text = $"{ShopTab.SaveMagaz.korzinaa.Count()}";
        Summa.Text = $"{ShopTab.SaveMagaz.korzinaa.Sum(x=>x.PraiseProduct)}";
    }
    public void Ubrat2(object sender, RoutedEventArgs e)
    {
        if (0 <= ShopTab.SaveMagaz.Product.Count - 1)
        {
            ShopTab.SaveMagaz.korzinaa.RemoveAt((int)(sender as Button)!.Tag!);

            for (int i = 0; i < ShopTab.SaveMagaz.korzinaa.Count; i++)
            {
                ShopTab.SaveMagaz.korzinaa[i].Id = i;
            }
            AA.ItemsSource = ShopTab.SaveMagaz.korzinaa.ToList();
        }
        ssil();
    }
    public void Oplata(object sender, RoutedEventArgs e)
    {
        if (Convert.ToInt32(Summa.Text) >= 1 && Convert.ToInt32(Colvo.Text) >= 1)
        {
            ShopTab.SaveMagaz.korzinaa.Clear();
            ssil();
            this.Close();   
            bagodarim taskWindow = new bagodarim();
            taskWindow.Show();
        }
        else
        {
            ssil();
            this.Close();   
            error2 taskWindow = new error2();
            taskWindow.Show();
        }
    }
    public void Click_exit(object sender, RoutedEventArgs args)
    {
        this.Close();
    }
}