using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace irf_mhcm3r_gak7.Abstract
{
    public abstract class Product : Button
    {
        protected string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                Text = _title;
            }
        }

        private int _calories;
        public int Calories
        {
            get { return _calories; }
            set
            {
                _calories = value;
                Display();
            }
        }

        public string Description { get; set; }

        public Product()  //ctor tabtab --> ez egy konstruktor, ezért kell a neve Product
        {
            Width = 150;
            Height = 50;
        }

        public abstract void Display();
    }
}
