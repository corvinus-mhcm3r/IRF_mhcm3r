﻿using irf_gyak5_mhcm3r2.Entities;
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
using System.Windows.Forms.DataVisualization.Charting;
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

            chartRateData.DataSource = Rates;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
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
                var unit = int.Parse(rate.GetAttribute("unit"));
                var value = int.Parse(rate.InnerText);

                Rates.Add(new RateData()
                {
                    Date = DateTime.Parse(date),
                    Currency = currency,
                    Value = unit != 0
                        ? value / unit
                        : 0
                }) ;
            }
        }
    }
}
