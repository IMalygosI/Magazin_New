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

public partial class Dobavit : Window
{
    public Dobavit()
    {
        InitializeComponent();
        Otmen.Click += Click_Otmen;
        PostavkaK.Click += Click_PostavkaK;
    }
    string SelectedImage;
    public void Click_PostavkaK(object sender, RoutedEventArgs args)
    {
        int Index =ShopTab.SaveMagaz.Product[ShopTab.massiv[0]].Id;
        int i = 0;
        foreach (Product product in ShopTab.SaveMagaz.Product)
        {
            if (ShopTab.SaveMagaz.Product.IndexOf(product) != Index && product.ProductName == name.Text)
            {
                i++;
            }   
        }
        string III = " ";
        switch (strok.SelectedIndex)
        {
            case 0:
                III = TypeVibor.Text;
                break;
            case 1:
                III = "ООО 'Олимп'";
                break;
            case 2:
                III = "ООО 'Поклоняемся Солнцу!'";
                break;
            case 3:
                III = "ООО 'Венера'";
                break;
            case 4:
                III = "ООО 'ЯщеркиТехКорп'";
                break;
        }
        string IV = " ";
        switch (strok2.SelectedIndex)
        {
            case 0:
                IV = TypeVibor2.Text;
                break;
            case 1:
                IV = "Техника";
                break;
            case 2:
                IV = "Одежда";
                break;
            case 3:
                IV = "Продукты";
                break;
            case 4:
                IV = "Канцелярия";
                break;
        }
        ShopTab.SaveMagaz.Product.Add(new Product(name.Text, Convert.ToDouble(prise.Text), id:1, SelectedImage,  Convert.ToInt32(colvo.Text), III, IV, opisanie.Text));
           
            if (i==0)
            {
                admin taskWindow = new admin();
                taskWindow.Show();
                this.Close();   
            }
            else if(i>0)
            {
                error4 taskWindow = new error4();
                taskWindow.Show();
            }  
    }
    private readonly FileDialogFilter fileFilter = new()
    {
        Extensions = new System.Collections.Generic.List<string>() {"png", "jpg", "jpeg"},
        Name = "Файлы изображений"
    };
    private void DeleteImage(string imageName)
    {
        bool isImageUsed = ShopTab.SaveMagaz.Product.Any(p => p.Sourse == imageName);// Проверяем, используется ли изображение в других продуктах
        if (!isImageUsed)       
        {
            string filePath = Path.Combine("Asset", imageName);            
            if (File.Exists(filePath))
            {                
                File.Delete(filePath); // Если изображение не используется, удаляем его
            }        
        }
    }  
    private async void ImageSelection(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var button = (sender as Button)!;
        switch (button.Name)
        {
            case "btn_imgAdd":
                if (!string.IsNullOrEmpty(SelectedImage))
                {            
                    DeleteImage(SelectedImage);
                } 
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
                if (!string.IsNullOrEmpty(SelectedImage))
                {                    
                    DeleteImage(SelectedImage);
                }    
                break;
        }
    }
    public void Click_Otmen(object sender, RoutedEventArgs args){
        if (!string.IsNullOrEmpty(SelectedImage))
        {            
            DeleteImage(SelectedImage);
        } 
        admin taskWindow = new admin();
        taskWindow.Show();
        this.Close();
    }
}
