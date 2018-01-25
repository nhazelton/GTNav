using Xamarin.Forms;
namespace GTNav
{
    public partial class GTNavPage : ContentPage
    {
        public GTNavPage()
        {
            InitializeComponent();
        }
        void LoginEvent(object sender, System.EventArgs e)
        {
            DisplayAlert("Login", "Username: " + usernameBox.Text + "\nPassword: " + passwordBox.Text, "Close");
        }
    }
}
