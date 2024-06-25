using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magaz
{
    public class Product
    {
        private string NameProduct;
        private double praiseProduct;
        private string organaizProduct;
        private string opisanieProduct;
        private string typeProduct;
        private string sourse;
        private int ids = 0;
        private int colvo;
        public Product(string Name, double Prise, int id, string Image_sourse, int count, string organiz, string type, string opisanie)
        {
            NameProduct = Name;
            praiseProduct = Prise;
            sourse = Image_sourse;
            ids = id;
            colvo = count;
            opisanieProduct = opisanie;
            organaizProduct = organiz;
            typeProduct = type;
        }
   
            public Product Clone()
            {
                return new Product(NameProduct, praiseProduct, ids, sourse, colvo, organaizProduct, typeProduct, opisanieProduct);
            }

        

        public double PraiseProduct
        {
            get { return praiseProduct; }
            set { praiseProduct = value; }
        }
        public string ProductName
        {
            get { return NameProduct; }
            set { NameProduct = value; }
        }
        public string OrganaizProduct
        {
            get { return organaizProduct; }
            set { organaizProduct = value; }
        }
        public string OpisanieProduct
        {
            get { return opisanieProduct; }
            set { opisanieProduct = value; }
        }
        public string TypeProduct
        {
            get { return typeProduct; }
            set { typeProduct = value; }
        }
        public int Id
        {
            get { return ids; }
            set { ids = value; }
        }
        public int ColvoProduct
        {
            get { return colvo; }
            set { colvo = value; }
        }
        public string Sourse
        {
            get { return sourse; }
            set { sourse = value; }
        }
        public Bitmap? image => Sourse != null ? new Bitmap($"Asset/{Sourse}") : new Bitmap($"Asset/default_image.jpg");
    }
}