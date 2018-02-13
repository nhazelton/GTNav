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
        public GTNavPage()
        {
            InitializeComponent();
            List<Location> tempList = LoadXMLData();
            Debug.WriteLine(tempList.First());
        }


        private List<Location> LoadXMLData()
        {
            string resPrefix = "GTNav.";
            var assembly = typeof(GTNavPage).GetTypeInfo().Assembly;
            IEnumerable<Location> locations = null;
            Stream stream = assembly.GetManifestResourceStream(resPrefix + "Locations.xml");
            XDocument doc = XDocument.Load(stream);
            locations = from l in doc.Descendants("Location")
                  select new Location
                  {
                      Name = l.Attribute("Name").Value,
                      Latititude = float.Parse(l.Attribute("Latitude").Value),
                      Longitude = float.Parse(l.Attribute("Longitude").Value)
                  };
            return locations.ToList();

        }
    }
}