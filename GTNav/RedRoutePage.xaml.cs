using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace GTNav
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RedRoutePage : ContentPage
	{

        CampusMap campusMap;

		public RedRoutePage()
		{
			InitializeComponent();

            campusMap = MyRedMap;
            var sampleMarker = new Position(33.774671, -84.396374);
            campusMap.Marker = new BusMarker
            {
                Position = sampleMarker,
                Radius = 100
            };

            campusMap.MoveToRegion(MapSpan.FromCenterAndRadius(sampleMarker, Distance.FromMiles(0.6)));
        }
	}
}