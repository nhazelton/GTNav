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

        SearchBar searchBar;
        Button walkButton;
        Button rideButton;

        public GTNavPage()
        {
            InitializeComponent();
            List<Location> tempList = LoadXMLData();
            Debug.WriteLine(tempList.First());

            searchBar = MySearchBar;
            String searchQuery; // changes to what the user searched for
            searchBar.SearchCommand = new Command(() => { searchQuery = searchBar.Text; searchBar.Text = "OK!"; }); // sets "on enter" command to populate searchQuery and display success message on bar

            walkButton = MyWalkButton;
            // code for walk button

            rideButton = MyRideButton;
            // code for ride button
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