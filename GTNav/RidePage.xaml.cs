using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

//Page that appears when the user selects the Riding option

namespace GTNav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RidePage : ContentPage
    {
        public Button backButton;
        public Button rideButton;
        public Button directionsButton;
        public Location loc;

        public RidePage(string rideTime, Location loc)
        {
            InitializeComponent();
            backButton = ReturnButton;
            rideButton = OnwardButton;
            directionsButton = DirectionsButton;
            backButton.Clicked += OnBackButtonPressed;
            directionsButton.Clicked += OnDirectionsButtonPressed;
            rideEstimate.Text = rideTime;
            this.loc = loc;
        }

        //back button returns to the main page
        public void OnBackButtonPressed(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopToRootAsync();
        }

        // when directions is pushed
        public void OnDirectionsButtonPressed(object sender, EventArgs e)
        {
            var address = loc.Name;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Device.OpenUri(
                      new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(address))));
                    break;
                case Device.Android:
                    Device.OpenUri(
                      new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(address))));
                    break;
                case Device.UWP:
                case Device.WinPhone:
                    Device.OpenUri(
                      new Uri(string.Format("bingmaps:?where={0}", Uri.EscapeDataString(address))));
                    break;
            }
        }
    }
}