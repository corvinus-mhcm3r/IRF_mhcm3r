using irf_gyak5_mhcm3r2.Entities;
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
using System.Xml;

namespace irf_gyak5_mhcm3r2
{
    public partial class Form1 : Form
    {
        //4.3
        BindingList<RateData> Rates = new BindingList<RateData>();

        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = Rates;

            var r = GetExchangeRates();
            GetXmlData(GetExchangeRates());
        }

        private string GetExchangeRates()
        {
            //3.1
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient(); //var mnbService = new MNBArfolyamServiceSoapClient();

            //3.2
            var request = new GetExchangeRatesRequestBody() //megfogalmaztuk a kérést
            {
                currencyNames = "EUR", //hogy ide mi kellhet --> jobboldalt rányomni az MnbServiceReference1 --> irf_gyak5_mhcm3r2.MnbServiceReference1 --> GetExchangeRatesRequestBody --> jobboldalt ott lesznek a paraméterek amik kellhetnek
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            //3.3
            var response = mnbService.GetExchangeRates(request); //elküldtük a kérést

            //3.4
            var result = response.GetExchangeRatesResult; //lekértük a kérésre a választ

            //richTextBox1.Text = result; //ezzel ki lehet írni minden adatot amit lekértünk, --> létrehozni egy notepadet --> mentés másként --> átváltani xml fájlra (mentés másként -> fájl típusa: minden fájl -> átnevezni a notepadet, hogy hozzáadjuk .xml-t a végére) --> behúzni böngészőbe a fájlt

            //ez kell ahhoz, hogy vissza lehessen returnulni a kövi függvényhez
            return result;
        }

        private void GetXmlData(string result)
        {
            var xml = new XmlDocument(); //ezt meg kell jegyezni, hogy "XmlDocument" !!!
            xml.LoadXml(result); //vigyázzunk, hogy ez kell, nem a sima Load függvény

            foreach (XmlElement item in xml.DocumentElement)
            {
                //var r = new RateData()
                //{

                //};
                //Rates.Add(r)

                var date = item.GetAttribute("date"); //ezt az xml fájlban ha megnézzük, onnan tudjuk meg, számít a kis és nagybetű

                var rate = (XmlElement)item.ChildNodes[0];
                var currency = rate.GetAttribute("curr");
                var value = rate.InnerText;

                Rates.Add(new RateData()
                {
                    Date = DateTime.Parse(date),
                    Currency = currency,
                    Value = decimal.Parse(value)
                }) ;
            }
        }
    }
}
