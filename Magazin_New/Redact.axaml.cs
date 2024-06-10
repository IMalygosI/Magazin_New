using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Magaz;

namespace Magazin_New;

public partial class Redact : Window
{
    public Redact()
    {
        InitializeComponent();
        Otmen.Click += Click_Otmen;
        redaktirovat.Click += Redaktirovat_Click;

        prise.Text = Convert.ToString(ShopTab.SaveMagaz.Product[ShopTab.massiv[0]].PraiseProduct);
        name.Text = ShopTab.SaveMagaz.Product[ShopTab.massiv[0]].ProductName;
        SelectedImage = ShopTab.SaveMagaz.Product[ShopTab.massiv[0]].Sourse;
        if (SelectedImage != null)
        {
            img_preview.Source = new Bitmap($"Asset/{SelectedImage}");
        }
        else
        {
            img_preview.Source = new Bitmap("Asset/default_image.jpg");
        }
        ssil();
    }
    string SelectedImage;
    private void ssil()
    {
        ShopTab.SaveMagaz.Product.Select(x => new {x.image, x.ProductName, x.PraiseProduct, x.Id});
    }
    private void Redaktirovat_Click(object? sender, RoutedEventArgs e)
    {
        ShopTab.SaveMagaz.Product[ShopTab.massiv[0]].Sourse = SelectedImage;
        ShopTab.SaveMagaz.Product[ShopTab.massiv[0]].ProductName = name.Text;
        ShopTab.SaveMagaz.Product[ShopTab.massiv[0]].PraiseProduct = Convert.ToDouble(prise.Text);
        
        admin taskWindow = new admin();
        taskWindow.Show();
        this.Close();
    }
    private readonly FileDialogFilter fileFilter = new()
    {
        Extensions = new System.Collections.Generic.List<string>() {"png", "jpg", "jpeg"},
        Name = "Файлы изображений"
    };
    private async void ImageSelection(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var button = (sender as Button)!;
        switch (button.Name)
        {
            case "btn_imgAdd":
                OpenFileDialog dialog = new();
                dialog.Filters.Add(fileFilter);

                string[] result = await dialog.ShowAsync(this);
                if (result == null)
                    return;
                string imageName = Path.GetFileName(result[0]);
                File.Copy(result[0], $"Asset/{imageName}", true);
                tblock_preview.IsVisible = img_preview.IsVisible = true; 
                tblock_preview.Text = SelectedImage = imageName;
                img_preview.Source = new Bitmap($"Asset/{imageName}");
                break;
            case "btn_imgDel":
                tblock_preview.IsVisible = img_preview.IsVisible = false;
                SelectedImage = null;
                break;
        }
    }
    public void Click_Otmen(object sender, RoutedEventArgs args)
    {
        this.Close();
    }
}