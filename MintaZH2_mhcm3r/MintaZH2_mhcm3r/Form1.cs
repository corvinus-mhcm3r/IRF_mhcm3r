using irf_mhcm3r_gak7.Abstract;
using irf_mhcm3r_gak7.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace irf_mhcm3r_gak7
{
    public partial class Form1 : Form
    {
        private List<Product> _products = new List<Product>();

        public Form1()
        {
            InitializeComponent();

            this.AutoScroll = true;                                         //ha túl sok dolog van a formon, megjeleníti a görgetőt

            ProcessXml();
            DisplayProducts();
        }

        public string LoadXml(string fileName) //terméktörzs 2.feladata
        {
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                //var output = "";                                           ez egy alternatíva
                //while (!sr.EndOfStream)
                //{
                //    output += "\n" + sr.ReadLine();
                //}
                //return output;

                //var outputlist = new List<string>();                       ez egy másik alternaíva
                //while (!sr.EndOfStream)
                //{
                //    outputlist.Add(sr.ReadLine());
                //}
                //var output = string.Join("\n", outputlist);
                //return output;

                return sr.ReadToEnd();                                      //ez egy harmadik alternatva, ha egy fájlt egybe kell felolvsni
            }
        }

        public void ProcessXml()
        {
            var xmlText = LoadXml("Menu.xml");                              //ez csak annyi, hogy meghívja az xml-t

            var xml = new XmlDocument();
            xml.LoadXml(xmlText);                                           //ez a függvény biztos, hogy nagyon kell majd

            foreach (XmlElement item in xml.DocumentElement)
            {
                var name = item.SelectSingleNode("name").InnerText;
                var description = item.SelectSingleNode("description").InnerText;
                var calories = item.SelectSingleNode("calories").InnerText;
                var type = item.SelectSingleNode("type").InnerText;

                //if (type.Equals("food"))                                    ez egy alternatíva
                //{
                //    var food = new Food()
                //    {
                //        Title = name,
                //        Description = description,
                //        Calories = int.Parse(calories)
                //    };
                //    _products.Add(food);
                //}

                //var drink = new Drink()
                //{
                //    Title = name,
                //    Calories = int.Parse(calories)
                //};
                //_products.Add(drink);

                Product product = null;
                if (type.Equals("food"))
                {
                    product = new Food();
                    ((Food)product).Description = description;
                }
                if (type.Equals("drink"))
                {
                    product = new Drink();
                }
                product.Title = name;
                product.Calories = int.Parse(calories);
                _products.Add(product);
                //product.Description = description;                    ehelyett a food-nál is lehet úgy description
            }
        }

        private void DisplayProducts()
        {
            var orderedProducts = from p in _products
                                  orderby p.Title
                                  select p;

            //Product előző = null;

            //foreach (var product in orderedProducts)                  //ez egy szebb alternatíva
            //{
            //    this.Controls.Add(product);
            //    if (előző != null)
            //        product.Top = előző.Top + előző.Height;
            //    else
            //        product.Top = 0;
            //    előző = product;
            //}

            var előzőTop = 0;
            foreach (var product in orderedProducts)                  //ez egy rövidebb alternatíva
            {
                this.Controls.Add(product);
                product.Top = előzőTop;
                előzőTop += product.Height;
            }
        }

    }
}
