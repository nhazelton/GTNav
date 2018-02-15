using Xamarin.Forms;
using Xamarin.Forms.Maps;

using System;
using System.Collections.Generic;
using System.Text;

namespace GTNav
{
    public partial class GTNavPage : ContentPage
    {
        
        SearchBar locationSearch;
        
        public GTNavPage() {
            InitializeComponent();

            locationSearch = new SearchBar {
                Text = "Enter a location...",
                SearchCommand = new Command(() => { locationSearch.Text = "OK!";})
            };
            
            // button code should go here

        } // GTNavPage()

    } // class GTNavPage

} // GTNav