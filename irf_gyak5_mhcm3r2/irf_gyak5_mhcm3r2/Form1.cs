using irf_gyak5_mhcm3r2.MnbServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace irf_gyak5_mhcm3r2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            GetExchangeRates();
        }

        private void GetExchangeRates()
        {
            //3.1

            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient(); //var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody() //megfogalmaztuk a kérést
            {
                currencyNames = "EUR", //hogy ide mi kellhet --> jobboldalt rányomni az MnbServiceReference1 --> irf_gyak5_mhcm3r2.MnbServiceReference1 --> GetExchangeRatesRequestBody --> jobboldalt ott lesznek a paraméterek amik kellhetnek
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request); //elküldtük a kérést

            var result = response.GetExchangeRatesResult; //lekértük a kérésre a választ

            richTextBox1.Text = result; //ezzel ki lehet írni minden adatot amit lekértünk, --> létrehozni egy notepadet --> mentés másként --> átváltani xml fájlra (mentés másként -> fájl típusa: minden fájl -> átnevezni a notepadet, hogy hozzáadjuk .xml-t a végére) --> behúzni böngészőbe a fájlt
        }
    }
}
