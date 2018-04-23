using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;

//File that works with MenuPage's buttons

namespace GTNav
{
    public class MenuPageViewModel
    {

        public ICommand GoHomeCommand { get; set; }
        public ICommand GoSecondCommand { get; set; }
        public ICommand GoRedCommand { get; set; }
        public ICommand GoBlueCommand { get; set; }
        public ICommand GoGreenCommand { get; set; }

        public MenuPageViewModel()
        {
            GoHomeCommand = new Command(GoHome);
            GoSecondCommand = new Command(GoSecond);
            GoRedCommand = new Command(GoRed);
            GoBlueCommand = new Command(GoBlue);
            GoGreenCommand = new Command(GoGreen);
        }

        void GoHome(object obj)
        {
            App.NavigationPage.Navigation.PopToRootAsync();
            App.MenuIsPresented = false;
        }

        void GoSecond(object obj)
        {
            App.NavigationPage.Navigation.PushAsync(new SecondPage());
            App.MenuIsPresented = false;
        }

        void GoRed(object o)
        {
            App.NavigationPage.Navigation.PushAsync(new RedRoutePage());
            App.MenuIsPresented = false;
        }

        void GoBlue(object o)
        {
            App.NavigationPage.Navigation.PushAsync(new BlueRoutePage());
            App.MenuIsPresented = false;
        }

        void GoGreen(object o)
        {
            App.NavigationPage.Navigation.PushAsync(new GreenRoutePage());
            App.MenuIsPresented = false;
        }
    }
}