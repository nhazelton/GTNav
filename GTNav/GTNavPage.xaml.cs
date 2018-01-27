using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GTNav
{
    public partial class GTNavPage : ContentPage
    {
        public GTNavPage()
        {
            InitializeComponent();
            var map = new Map();
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
        }
    }
}
