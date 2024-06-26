﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Magaz;

namespace Magazin_New;

public partial class guest : Window
{
    public guest()
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
        sotirovka.SelectionChanged += Sotirovka_SelectionChanged;//ЦЕНА
        sotirovka2.SelectionChanged += Sotirovka_OrganaizProduct;//ПРОИЗВОДИТЕЛЬ
        sotirovka3.SelectionChanged += Sotirovka_SortByType;//Тип продукта

        exit.Click += Click_exit;
        in_korz.Click += Click_korz;
        LBoxInitialization(ShopTab.SaveMagaz.Product);
        ssil("");
    }
    
    private void ResetSort(object sender, RoutedEventArgs e)
    {
        sotirovka.SelectedIndex = 0;
        sotirovka2.SelectedIndex = 0;
        sotirovka3.SelectedIndex = 0;
        poisk.Text = "";
        AAA.ItemsSource = ShopTab.SaveMagaz.Product.Select(x => new
        {
            x.ProductName,
            x.Id,
            x.OpisanieProduct,
            x.Sourse,
            x.OrganaizProduct,
            x.ColvoProduct,
            x.PraiseProduct,
            x.TypeProduct,
            Color = x.ColvoProduct > 0 ? "CenterScreen" : "Gray"
        }).ToList();
        FiltersTogether();
    }
    private void LBoxInitialization(List<Product> listBoxSource) //Метод для обновления листбокса
    {
        AAA.ItemsSource = ShopTab.SaveMagaz.Product.Select(x => new //обновление лисбокса, в качестве источника - список, принимаемый методом
        {
            x.ProductName,
            x.Id,
            x.OpisanieProduct,
            x.Sourse,
            x.OrganaizProduct,
            x.ColvoProduct,
            x.PraiseProduct,
            x.TypeProduct,
            Color = x.ColvoProduct > 0 ? "CenterScreen" : "Gray"
        }).ToList();
    }
    private void FiltersTogether()
    {
        var filteredProducts = ShopTab.SaveMagaz.Product.AsEnumerable();

        if (sotirovka3.SelectedIndex > 0) // Сортировка по типу продукта
        {
            string selectedTypeProduct = (sotirovka3.SelectedItem as ComboBoxItem).Content.ToString();
            filteredProducts = filteredProducts.Where(p => p.TypeProduct == selectedTypeProduct);
        }
        if (sotirovka2.SelectedIndex > 0) // Сортировка по производителю
        {
            string selectedOrganaizProduct = (sotirovka2.SelectedItem as ComboBoxItem).Content.ToString();
            filteredProducts = filteredProducts.Where(p => p.OrganaizProduct == selectedOrganaizProduct);
        }
        switch (sotirovka.SelectedIndex) // Сортировка по цене
        {
            case 1: // по возрастанию цены
                filteredProducts = filteredProducts.OrderBy(p => p.PraiseProduct);
                break;
            case 2: // по убыванию цены
                filteredProducts = filteredProducts.OrderByDescending(p => p.PraiseProduct);
                break;
        }
        AAA.ItemsSource = filteredProducts.Select(x => new
        {
            x.image,
            x.ProductName,
            x.PraiseProduct,
            x.Id,
            x.TypeProduct,
            x.OpisanieProduct,
            x.ColvoProduct,
            x.OrganaizProduct,
            Color = x.ColvoProduct > 0 ? "CenterScreen" : "Gray"
        }).ToList();
    }
    private void Sotirovka_SortByType(object sender, SelectionChangedEventArgs e)
    {
        if (sotirovka3.SelectedIndex > 0) // Проверяем, что выбран один из типов продуктов
        {
            string selectedTypeProduct = (sotirovka3.SelectedItem as ComboBoxItem).Content.ToString();
            var sortedList = ShopTab.SaveMagaz.Product
                .Where(p => p.TypeProduct == selectedTypeProduct)
                .ToList();

            AAA.ItemsSource = sortedList;
        }
        else
        {
            AAA.ItemsSource = ShopTab.SaveMagaz.Product.ToList();
        }
        FiltersTogether();
    }
    private void Sotirovka_OrganaizProduct(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;
        if (comboBox.SelectedIndex > 0)
        {
            string selectedOrganaizProduct = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();

            var sortedList = ShopTab.SaveMagaz.Product
                .Where(p => p.OrganaizProduct == selectedOrganaizProduct)
                .ToList();

            AAA.ItemsSource = sortedList.Select(x => new
            {
                x.image,
                x.ProductName,
                x.PraiseProduct,
                x.Id,
                x.TypeProduct,
                x.OpisanieProduct,
                x.ColvoProduct,
                x.OrganaizProduct,
                Color = x.ColvoProduct > 0 ? "CenterScreen" : "Gray"
            }).ToList();
        }
        else
        {
            AAA.ItemsSource = ShopTab.SaveMagaz.Product.ToList();
        }
        FiltersTogether();
    }
    private void Sotirovka_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (sotirovka.SelectedIndex)
        {
            case 0:
                break;
            case 1: // Сортировка по Воззрастанию
                SortByPrice();
                break;
            case 2: // Сортировка по Убыванию
                OrderByDescending();
                break;
        }
        FiltersTogether();
    }
    private void OrderByDescending()//Убывание "От большего"
    {
        var sortedList = ShopTab.SaveMagaz.Product
            .OrderByDescending(p => p.PraiseProduct)
            .ToList();

        AAA.ItemsSource = sortedList.Select(x => new {
            x.image,
            x.ProductName,
            x.PraiseProduct,
            x.Id,
            x.TypeProduct,
            x.OpisanieProduct,
            x.ColvoProduct,
            x.OrganaizProduct,
            Color = x.ColvoProduct > 0 ? "CenterScreen" : "Gray"
        }).ToList();
    }
    private void SortByPrice()//Воззрастание
    {
        var sortedList = ShopTab.SaveMagaz.Product
            .OrderBy(p => p.PraiseProduct)
            .ToList();

        AAA.ItemsSource = sortedList.Select(x => new
        {
            x.image,
            x.ProductName,
            x.PraiseProduct,
            x.Id,
            x.ColvoProduct,
            x.OrganaizProduct,
            x.TypeProduct,
            x.OpisanieProduct,
            Color = x.ColvoProduct > 0 ? "CenterScreen" : "Gray"
        }).ToList();
    }
    private void ssil(string type)
    {
        AAA.ItemsSource = ShopTab.SaveMagaz.Product.Select(x => new {
            x.image,
            x.ProductName,
            x.PraiseProduct,
            x.Id,
            x.ColvoProduct,
            x.OrganaizProduct,
            x.OpisanieProduct,
            x.TypeProduct,
            Color = x.ColvoProduct > 0 ? "CenterScreen" : "Gray"
        }).ToList();
    }
    public void Searching(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        if (poisk.Text != null || poisk.Text == "")
        {
            ShopTab.SaveMagaz.vremenno.Clear();
            foreach (Product Product in ShopTab.SaveMagaz.Product)
            {
                if (Product.ProductName.ToLower().Contains(poisk.Text.ToLower()))
                {
                    ShopTab.SaveMagaz.vremenno.Add(Product);
                }
            }
            LBoxInitiaLization(ShopTab.SaveMagaz.vremenno);
        }
        else
        {
            LBoxInitiaLization(ShopTab.SaveMagaz.Product);
        }
    }
    private void LBoxInitiaLization(List<Product> listBox)
    {
        AAA.ItemsSource = listBox.Select(x => new {
            x.image,
            x.ProductName,
            x.PraiseProduct,
            x.Id,
            x.ColvoProduct,
            x.OrganaizProduct,
            x.OpisanieProduct,
            x.TypeProduct,
            Color = x.ColvoProduct > 0 ? "CenterScreen" : "Gray"
        }).ToList();
    }
    public void Click_korz(object sender, RoutedEventArgs args)
    {
        error3 taskWindow = new error3();
        taskWindow.Show();
    }
    public void Click_exit(object sender, RoutedEventArgs args)
    {
        MainWindow taskWindow = new MainWindow();
        taskWindow.Show();
        this.Close();
    }
}