using Xamarin.Forms;
using Xamarin.Forms.Maps;

using System.Collections.Generic;
using System.Xml.Linq;
using System.Diagnostics;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace GTNav {

    public partial class GTNavPage : ContentPage {

        SearchBar searchBar;
        ObservableCollection<Location> locations;
        List<Location> locationList;
        CampusMap campusMap;

        Button walkButton;
        bool walkPressed = false;

        Button rideButton;
        bool ridePressed = false;

        HttpClient client;

        public GTNavPage() {
            InitializeComponent();
            locationList = LoadXMLData();
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            locations = new ObservableCollection<Location>(locationList);
            LocationSuggestions.ItemsSource = locations; // binds listview in XAML to locations collection


            searchBar = MySearchBar;
            String searchQuery; // changes to what the user searched for
            searchBar.SearchCommand = new Command(() => { //Starts an action once an item is searched
                searchQuery = searchBar.Text;
                searchBar.Text = "OK!";
                Debug.WriteLine(searchQuery);
            }); // sets "on enter" command to populate searchQuery and display success message on bar


            searchBar.TextChanged += (object sender, TextChangedEventArgs e) => // Whenever a new character is entered filter the suggestion results
            {
                if (e.NewTextValue == "") {
                    LocationSuggestions.IsVisible = false;
                } else {
                    LocationSuggestions.IsVisible = true;
                }
                List<Location> searchList = new List<Location>();
                foreach (Location loc in locationList) {
                    if (loc.Name.ToLowerInvariant().Contains(e.NewTextValue)) {
                        searchList.Add(loc);
                    }
                }
                LocationSuggestions.ItemsSource = new ObservableCollection<Location>(searchList);
                Debug.WriteLine(e.NewTextValue);
            };

            LocationSuggestions.ItemSelected += (sender, e) => {
                Location loc = (Location)e.SelectedItem;
                Debug.WriteLine(loc.ToString());


                string startLat = "33.7746";
                string startLong = "-84.39";

                string destLat = loc.Latititude.ToString();
                string destLong = loc.Longitude.ToString();
                Debug.WriteLine(destLat);
                Debug.WriteLine(destLong);
                if (ridePressed == true && walkPressed == false)
                {
                    string URL = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + startLat + "," + startLong + "&destinations=" + destLat + "," + destLong + "&mode=driving" + "&key=AIzaSyBiI71LNFa4oOgVHyqrzPN3VGAMtnPLvm8"; // Constructs a url for sending to Google with our maps api
                    Task<String> timeTask = Task.Run(async () => await SendLocations(URL));
                    timeTask.Wait();
                    string timeString = timeTask.Result;
                    Task<String> distTask = Task.Run(async () => await SendDistance(URL));
                    distTask.Wait();
                    string distString = distTask.Result;
                    Debug.WriteLine(distString + " " + timeString);
                }
                else if (walkPressed == true && ridePressed == false)
                {
                    string URL = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + startLat + "," + startLong + "&destinations=" + destLat + "," + destLong + "&mode=walking" + "&key=AIzaSyBiI71LNFa4oOgVHyqrzPN3VGAMtnPLvm8"; // Constructs a url for sending to Google with our maps api
                    Task<String> timeTask = Task.Run(async () => await SendLocations(URL));
                    timeTask.Wait();
                    string timeString = timeTask.Result;
                    Task<String> distTask = Task.Run(async () => await SendDistance(URL));
                    distTask.Wait();
                    string distString = distTask.Result;
                    Debug.WriteLine(distString + " " + timeString);
                }
                
            };




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
            campusMap.MoveToRegion(MapSpan.FromCenterAndRadius(sampleMarker, Distance.FromMiles(0.6)));

            walkButton = MyWalkButton;
            walkButton.Clicked += OnWalkButtonPressed; // OnWalkButtonPressed happens when button is tapped -- see below
            
            rideButton = MyRideButton;
            rideButton.Clicked += OnRideButtonPressed; // OnRideButtonPressed happens when button is tapped -- see below

            // add future functionality code here
        }


        public async Task<String> SendLocations(string URL)
        {
            var uri = new Uri(URL);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JToken token = JToken.Parse(content);
                string time = token["rows"][0]["elements"][0]["duration"]["text"].ToString();
                return time;
            }
            return "";
        }

        public async Task<String> SendDistance(string URL)
        {
            var uri = new Uri(URL);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JToken token = JToken.Parse(content);
                string time = token["rows"][0]["elements"][0]["distance"]["text"].ToString();
                return time;
            }
            return "";
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

        public void OnWalkButtonPressed(object sender, EventArgs e) {
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

        public void OnRideButtonPressed(object sender, EventArgs e) {
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