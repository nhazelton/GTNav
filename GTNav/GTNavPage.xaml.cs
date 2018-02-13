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
        //private List<Location> _rawData = null;
        public GTNavPage()
        {
            InitializeComponent();
            LoadXMLData();
        }


        private async void LoadXMLData()
        {
            string resPrefix = "GTNav.";
            //#if __IOS__
            //    string resPrefix = "GTNav.iOS.";
            //#endif
            //#if __ANDROID__
            //    string resPrefix = "GTNav.Droid.";
            //#endif

            var assembly = typeof(GTNavPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(resPrefix + "Locations.xml");
            await Task.Factory.StartNew(delegate {
                XDocument doc = XDocument.Load(stream);
                IEnumerable<Location> locations = from l in doc.Descendants("Location")
                                          select new Location
                                          {
                                              Name = l.Attribute("name").Value,
                                              Latititude = float.Parse(l.Attribute("latitude").Value),
                                              Longitude = float.Parse(l.Attribute("longitude").Value)

                                          };
                //_rawData = locations.ToList();
            });
        }
    }
}