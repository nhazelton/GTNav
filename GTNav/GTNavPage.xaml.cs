using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

using Plugin.Geolocator;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Diagnostics;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;


namespace GTNav {

    public partial class GTNavPage : ContentPage {

        SearchBar searchBar;
        ObservableCollection<Location> locations;
        List<Location> locationList;
        CampusMap campusMap;

        Location loc;
        public Button walkButton;
        public Button rideButton;
        bool searchReady = false;

        enum Routes {Red, Blue, Green, Trolley, Emory, MidnightRambler, TSExpress};


        HttpClient client;

        public GTNavPage() {
            InitializeComponent();
            locationList = LoadXMLData();
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            locations = new ObservableCollection<Location>(locationList);
            LocationSuggestions.ItemsSource = locations; // binds listview in XAML to locations collection

            plotBuses(Routes.Red);

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
                loc = (Location)e.SelectedItem;
                Debug.WriteLine(loc.ToString());
                
                //Allow the walk and ride buttons to activate
                searchReady = true;
            };




            campusMap = MyCampusMap;
            var sampleMarker = new Position(33.774671, -84.396374);
            campusMap.Marker = new BusMarker {
                Position = sampleMarker,
                Radius = 100
            };

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

        //Needs cleaning later on when modifying
        //Completely changed functionality
        //At the moment there is no cool visual when pressing button, but it has functionality
        //Passs on to a new page depending on what is selected

        //activate if the button is presed and the search has been completed
        public async void OnWalkButtonPressed(object sender, EventArgs e)
        {
            if (searchReady)
            { // if button is currently 'on'
              //    if (ridePressed) { // 'unpress' the ride button -- same contents as else block in OnRideButtonPressed
              //        ridePressed = false;
              //        rideButton.BackgroundColor = Color.LimeGreen;
              //        rideButton.TextColor = Color.Black;
              //    }
                string walkTime = await getWalkingTime();
                await App.NavigationPage.Navigation.PushAsync(new WalkPage(walkTime, loc));
                //    walkPressed = true;
                //    walkButton.BackgroundColor = Color.White;
                //    walkButton.TextColor = Color.Fuchsia;
            }// else { // if it's not
            //    walkPressed = false;
            //    walkButton.BackgroundColor = Color.Fuchsia;
            //    walkButton.TextColor = Color.Black;
            //}
            else
            {
                DisplayAlert("Alert", "Please search for a location and select from the drop-down menu", "OK");
            }
        }

        public async Task<String> getWalkingTime() {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            Debug.WriteLine("hello");
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(0.01), null, true);


            Debug.WriteLine("hello");
            double startLat = position.Latitude;
            double startLong = position.Longitude;

            string destLat = loc.Latititude.ToString();
            string destLong = loc.Longitude.ToString();
            Debug.WriteLine(startLat);
            Debug.WriteLine(startLong);
            string URLwalk = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&mode=walking&origins=" + startLat + "," + startLong + "&destinations=" + destLat + "," + destLong + "&key=AIzaSyBiI71LNFa4oOgVHyqrzPN3VGAMtnPLvm8"; // Constructs a url for sending to Google with our maps api
            Task<String> timeTask = Task.Run(async () => await SendLocations(URLwalk));
            timeTask.Wait();
            string walkTimeString = timeTask.Result;
            Debug.WriteLine(walkTimeString);
            return walkTimeString;
        }

        //activate if the button is presed and the search has been completed
        public void OnRideButtonPressed(object sender, EventArgs e)
        {
            if (searchReady)
            { // if button is currently 'on'
              //    if (walkPressed) { // 'unpress' the walk button -- same contents as else block in OnWalkButtonPressed
              //        walkPressed = false;
              //        walkButton.BackgroundColor = Color.Fuchsia;
              //        walkButton.TextColor = Color.Black;
              //    }
                App.NavigationPage.Navigation.PushAsync(new RidePage());
                //ridePressed = true;
                //    rideButton.BackgroundColor = Color.White;
                //    rideButton.TextColor = Color.LimeGreen;
            }// else { // if it's not
            //    ridePressed = false;
            //    rideButton.BackgroundColor = Color.LimeGreen;
            //    rideButton.TextColor = Color.Black;
            //}
            else
            {
                DisplayAlert("Alert", "Please search for a location and select from the drop-down menu", "OK");
            }
        }

        private async void plotBuses(Routes route) { // Plots the current location of the buses of a specific route
            string URL = "http://m.gatech.edu:80/api/buses/position";
            var uri = new Uri(URL);
            var response = await client.GetAsync(uri);
            HttpContent content = response.Content;
            string mycontent = await content.ReadAsStringAsync();
            Bus[] items = JsonConvert.DeserializeObject<Bus[]>(mycontent);

            foreach(Bus item in items) {
                Debug.WriteLine(item.id);   
            }

        }

    } // GTNavPage


} // GTNav