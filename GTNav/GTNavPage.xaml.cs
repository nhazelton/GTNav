using Xamarin.Forms;

namespace GTNav
{
    public partial class GTNavPage : ContentPage
    {
        public GTNavPage()
        {
            InitializeComponent();
        }
        void loginEvent(object sender, System.EventArgs e)
        {
            DisplayAlert("Login", "Username: " + usernameBox.Text + "\nPassword: " + passwordBox.Text, "Close");
        }
    }
}
