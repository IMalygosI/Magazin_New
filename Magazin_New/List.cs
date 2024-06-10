using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magaz
{
    public class List
    {
        public List<Product> Product = new List<Product>()
        {
            new Product("МЯСО", 1000, 0, $"default_image.jpg"),
            new Product("Телевизор", 1000,  1, $"default_image.jpg"),
            new Product("Пальто", 100000,  2, $"default_image.jpg"),
            new Product("Ноутбук", 12000, 3, $"default_image.jpg"),
            new Product("Ручки", 1000, 4, $"default_image.jpg"),
            new Product("Куртка", 100000, 5, $"default_image.jpg"),
            new Product("Мак", 100, 6, $"default_image.jpg")
        };
        public List<Product> korzinaa = new List<Product>(){};
    }
}
