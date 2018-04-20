using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

//Page that appears when the user selects the Walking option

namespace GTNav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalkPage : ContentPage
    {
        public Button backButton;
        public Button walkButton;
        public Button directionsButton;
        Location loc;


        public WalkPage(string walkTime, Location loc)
        {
            InitializeComponent();
            backButton = ReturnButton;
            walkButton = OnwardButton;
            directionsButton = DirectionsButton;
            backButton.Clicked += OnBackButtonPressed;
            directionsButton.Clicked += OnDirectionsButtonPressed;
            walkEstimate.Text = walkTime;
            this.loc = loc;

        }

        //back button returns to the main page
        public void OnBackButtonPressed(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopToRootAsync();
        }

        public void OnDirectionsButtonPressed(object sender, EventArgs e) {
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