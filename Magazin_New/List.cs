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
            new Product("МЯСО", 1000, 0, $"default_image.jpg", 12, "ООО 'ЯщеркиТехКорп'", "Продукты", "Это мясо отличных и упитанных животных! Точно-точно)))"),
            new Product("Телевизор", 1000,  1, $"default_image.jpg", 181, "ООО 'Поклоняемся Солнцу!'", "Техника", "Хороший  4к телевизор! Лушая цветопередача и насыщенность красок на рынке!"),
            new Product("Пальто", 100000,  2, $"default_image.jpg", 132, "ООО 'Венера'", "Одежда", "Хорошое и качественное пальто! Прослужит несколько зимних сезонов"),
            new Product("Ноутбук", 12000, 3, $"default_image.jpg", 175, "ООО 'Олимп'", "Техника", "Мощный и долгоработающий от батарии ноутбук! Раскрывает всю свою мощность без зарядки!"),
            new Product("Ручки", 1000, 4, $"default_image.jpg", 561, "ООО 'Поклоняемся Солнцу!'", "Канцелярия", "Лучшие ручки в мире! Из дерева и золота!"),
            new Product("Куртка", 100000, 5, $"default_image.jpg", 651, "ООО 'ЯщеркиТехКорп'", "Одежда", "Куртка из крепких и износастойких материалов! Подходит для Лета-Зимы-Весны-Осени!"),
            new Product("Мак", 100, 6, $"default_image.jpg", 129, "ООО 'Олимп'", "Продукты", "Хороший и свежий мак! Покупай не ошибешься!")
        };
        public List<Product> korzinaa = new List<Product>(){};
        public List<Product> vremenno = new List<Product>(){};
    }
}
