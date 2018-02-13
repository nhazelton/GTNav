using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Diagnostics;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.Linq;

namespace GTNav
{
    public partial class GTNavPage : ContentPage
    {
        private List<Location> locationList = null;
        public GTNavPage()
        {
            InitializeComponent();
            LoadXMLData();
        }


        private async void LoadXMLData()
        {
            string resPrefix = "GTNav.";

            var assembly = typeof(GTNavPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(resPrefix + "Locations.xml");
            await Task.Factory.StartNew(delegate {
                XDocument doc = XDocument.Load(stream);
                IEnumerable<Location> locations = from l in doc.Descendants("Location")
                                          select new Location
                                          {
                                              Name = l.Attribute("Name").Value,
                                              Latititude = float.Parse(l.Attribute("Latitude").Value),
                                              Longitude = float.Parse(l.Attribute("Longitude").Value)
                                          };
                locationList = locations.ToList();
            });
        }
    }
}