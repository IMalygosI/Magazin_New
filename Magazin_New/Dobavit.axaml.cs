using System;
using System.Collections.Generic;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Magaz;

namespace Magazin_New;

public partial class Dobavit : Window
{
    public Dobavit()
    {
        InitializeComponent();
        Otmen.Click += Click_Otmen;
        PostavkaK.Click += Click_PostavkaK;
    }
    string SelectedImage;
    public void Click_PostavkaK(object sender, RoutedEventArgs args){
        ShopTab.SaveMagaz.Product.Add(new Product(name.Text, Convert.ToDouble(prise.Text), id:1, SelectedImage));
        
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
    public void Click_Otmen(object sender, RoutedEventArgs args){
        this.Close();
    }
}