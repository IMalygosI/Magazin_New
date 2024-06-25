using System;
using System.Linq;
using System.Xml.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Magaz;
using static Magazin_New.MainWindow;

namespace Magazin_New;

public partial class basket : Window
{
    public event Action OnBasketClosed;
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
        exit.Click += Click_exit;
        ssil();
    }
    private void ssil()
    {
        AA.ItemsSource = ShopTab.SaveMagaz.korzinaa.Select(x => new { x.image, x.ProductName, x.PraiseProduct, x.Id, x.ColvoProduct, x.OrganaizProduct });
        Colvo.Text = $"{ShopTab.SaveMagaz.korzinaa.Sum(x => x.ColvoProduct)}";
        Summa.Text = $"{ShopTab.SaveMagaz.korzinaa.Sum(x => x.PraiseProduct * x.ColvoProduct)}";
    }
    public void Ubrat2(object sender, RoutedEventArgs e)
    {
        int productIndex = (int)(sender as Button)!.Tag!;
        var productInBasket = ShopTab.SaveMagaz.korzinaa[productIndex];
        productInBasket.ColvoProduct -= 1;

        var productInStock = ShopTab.SaveMagaz.Product.FirstOrDefault(p => p.Id == productIndex);// Возвращаем товар на склад
        if (productInStock != null)
        {
            productInStock.ColvoProduct += 1;
        }
        if (productInBasket.ColvoProduct == 0)
        {
            ShopTab.SaveMagaz.korzinaa.RemoveAt(productIndex);
        }
        for (int i = 0; i < ShopTab.SaveMagaz.korzinaa.Count; i++)
        {
            ShopTab.SaveMagaz.korzinaa[i].Id = i;
        }

        AA.ItemsSource = ShopTab.SaveMagaz.korzinaa.ToList();
        ssil();
    }
    public void Oplata(object sender, RoutedEventArgs e)
    {
        if (UserInfo.UserType == "admin")
        {
            if (Convert.ToInt32(Summa.Text) >= 1 && Convert.ToInt32(Colvo.Text) >= 1)
            {
                ShopTab.SaveMagaz.korzinaa.Clear();
                ssil();
                admin taskWindow = new admin();
                taskWindow.Show();
                bagodarim thankYouWindow = new bagodarim();
                thankYouWindow.Show();
                this.Close();
            }
            else
            {
                ssil();                
                admin taskWindow = new admin();
                taskWindow.Show();
                error2 thankYouWindow = new error2();
                thankYouWindow.Show();
                this.Close();
            }
        }
        else if (UserInfo.UserType == "user")
        {
            if (Convert.ToInt32(Summa.Text) >= 1 && Convert.ToInt32(Colvo.Text) >= 1)
            {
                ShopTab.SaveMagaz.korzinaa.Clear();
                ssil();
                user taskWindow = new user();
                taskWindow.Show();
                bagodarim thankYouWindow = new bagodarim();
                thankYouWindow.Show();
                this.Close();
            }
            else
            {
                ssil();
                user taskWindow = new user();
                taskWindow.Show();
                error2 thankYouWindow = new error2();
                thankYouWindow.Show();
                this.Close();
            }
        }
    }
    public void Click_exit(object sender, RoutedEventArgs args)
    {
        if (UserInfo.UserType == "admin")
        {
            admin taskWindow = new admin();
            taskWindow.Show();
            this.Close();
        }
        else if(UserInfo.UserType == "user")
        {
            user taskWindow = new user();
            taskWindow.Show();
            this.Close();
        }

    }
}