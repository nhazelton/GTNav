using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Page that appears when the user selects the Walking option

namespace GTNav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalkPage : ContentPage
    {
        public Button backButton;
        public Button walkButton;
        public Button directionsButton;

        public WalkPage()
        {
            InitializeComponent();
            backButton = ReturnButton;
            walkButton = OnwardButton;
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