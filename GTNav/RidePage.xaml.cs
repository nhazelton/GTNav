using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Page that appears when the user selects the Riding option

namespace GTNav
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RidePage : ContentPage
    {

        public Button backButton;
        public Button rideButton;
        public Button directionsButton;

        public RidePage()
        {
            InitializeComponent();
            backButton = ReturnButton;
            rideButton = OnwardButton;
            directionsButton = DirectionsButton;
            backButton.Clicked += OnBackButtonPressed;
        }

        //back button returns to the main page
        public void OnBackButtonPressed(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopToRootAsync();
        }
    }
}