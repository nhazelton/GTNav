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

        CampusMap campusMap;

        Button walkButton;
        bool walkPressed = false;

        Button rideButton;
        bool ridePressed = false;

        public GTNavPage()
        {
            InitializeComponent();
            List<Location> tempList = LoadXMLData();
            Debug.WriteLine(tempList.First());

            searchBar = MySearchBar;
            String searchQuery; // changes to what the user searched for
            searchBar.SearchCommand = new Command(() => { searchQuery = searchBar.Text; searchBar.Text = "OK!"; }); // sets "on enter" command to populate searchQuery and display success message on bar

            campusMap = MyCampusMap;
            var sampleMarker = new Position(33.774671, -84.396374);
            campusMap.Marker = new BusMarker {
                Position = sampleMarker,
                Radius = 100
            };

            var culc = new Pin {
                Type = PinType.Place,
                Position = new Position(33.774671, -84.396374),
                Label = "Clough Undergraduate Learning Commons",
            };

            campusMap.Pins.Add(culc);
            campusMap.MoveToRegion(MapSpan.FromCenterAndRadius(sampleMarker, Distance.FromMiles(0.4)));

            walkButton = MyWalkButton;
            walkButton.Clicked += OnWalkButtonPressed; // OnWalkButtonPressed happens when button is tapped -- see below
            
            rideButton = MyRideButton;
            rideButton.Clicked += OnRideButtonPressed; // OnRideButtonPressed happens when button is tapped -- see below

            // add future functionality code here
        }

        private List<Location> LoadXMLData() {
            string resPrefix = "GTNav.";
            var assembly = typeof(GTNavPage).GetTypeInfo().Assembly;
            IEnumerable<Location> locations = null;
            Stream stream = assembly.GetManifestResourceStream(resPrefix + "Locations.xml");
            XDocument doc = XDocument.Load(stream);
            locations = from l in doc.Descendants("Location")
                        select new Location {
                            Name = l.Attribute("Name").Value,
                            Latititude = float.Parse(l.Attribute("Latitude").Value),
                            Longitude = float.Parse(l.Attribute("Longitude").Value)
                        };
            return locations.ToList();
        }

        public void OnWalkButtonPressed(object sender, EventArgs e) 
        {
            if (!walkPressed) { // if button is currently 'on'
                if (ridePressed) { // 'unpress' the ride button -- same contents as else block in OnRideButtonPressed
                    ridePressed = false;
                    rideButton.BackgroundColor = Color.Green;
                    rideButton.TextColor = Color.Black;
                }
                walkPressed = true;
                walkButton.BackgroundColor = Color.White;
                walkButton.TextColor = Color.Purple;
            } else { // if it's not
                walkPressed = false;
                walkButton.BackgroundColor = Color.Purple;
                walkButton.TextColor = Color.Black;
            }
        }

        public void OnRideButtonPressed(object sender, EventArgs e) 
        {
            if (!ridePressed) { // if button is currently 'on'
                if (walkPressed) { // 'unpress' the walk button -- same contents as else block in OnWalkButtonPressed
                    walkPressed = false;
                    walkButton.BackgroundColor = Color.Purple;
                    walkButton.TextColor = Color.Black;
                }
                ridePressed = true;
                rideButton.BackgroundColor = Color.White;
                rideButton.TextColor = Color.Green;
            } else { // if it's not
                ridePressed = false;
                rideButton.BackgroundColor = Color.Green;
                rideButton.TextColor = Color.Black;
            }
        }
    } // GTNavPage
} // GTNav