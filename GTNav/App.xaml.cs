using Xamarin.Forms;

namespace GTNav
{
    public partial class App : Application
    {

        public NavigationPage NavigationPage { get; private set; }

        public App()
        {
            var menuPage = new MenuPage();
            NavigationPage = new NavigationPage(new GTNavPage());
            var rootPage = new RootPage();
            rootPage.Master = menuPage;
            rootPage.Detail = NavigationPage;
            MainPage = rootPage;


            InitializeComponent();

            //MainPage = new GTNavPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
