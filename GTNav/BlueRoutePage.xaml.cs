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
	public partial class BlueRoutePage : ContentPage
	{
		public BlueRoutePage ()
		{
			InitializeComponent ();

            blueCampusMap.RouteCoordinates.Add(new Position(33.771282, -84.392072));
            blueCampusMap.RouteCoordinates.Add(new Position(33.776892, -84.392088));
            blueCampusMap.RouteCoordinates.Add(new Position(33.776961, -84.395176));
            blueCampusMap.RouteCoordinates.Add(new Position(33.778180, -84.396451));
            blueCampusMap.RouteCoordinates.Add(new Position(33.778413, -84.401306));
            blueCampusMap.RouteCoordinates.Add(new Position(33.779669, -84.402527));
            blueCampusMap.RouteCoordinates.Add(new Position(33.779638, -84.406084));
            blueCampusMap.RouteCoordinates.Add(new Position(33.778707, -84.406125));
            blueCampusMap.RouteCoordinates.Add(new Position(33.778673, -84.404191));
            blueCampusMap.RouteCoordinates.Add(new Position(33.777309, -84.404225));
            blueCampusMap.RouteCoordinates.Add(new Position(33.777316, -84.402397));
            blueCampusMap.RouteCoordinates.Add(new Position(33.775246, -84.402564));
            blueCampusMap.RouteCoordinates.Add(new Position(33.774685, -84.402288));
            blueCampusMap.RouteCoordinates.Add(new Position(33.774595, -84.402528));
            blueCampusMap.RouteCoordinates.Add(new Position(33.774375, -84.402450));
            blueCampusMap.RouteCoordinates.Add(new Position(33.773929, -84.402063));
            blueCampusMap.RouteCoordinates.Add(new Position(33.773688, -84.401366));
            blueCampusMap.RouteCoordinates.Add(new Position(33.773141, -84.397929));
            blueCampusMap.RouteCoordinates.Add(new Position(33.772972, -84.397483));
            blueCampusMap.RouteCoordinates.Add(new Position(33.772405, -84.396655));
            blueCampusMap.RouteCoordinates.Add(new Position(33.772355, -84.395508));
            blueCampusMap.RouteCoordinates.Add(new Position(33.771389, -84.395540));
            blueCampusMap.RouteCoordinates.Add(new Position(33.771307, -84.392058));
            blueCampusMap.RouteCoordinates.Add(new Position(33.770163, -84.392197));
            blueCampusMap.RouteCoordinates.Add(new Position(33.770164, -84.391692));
            blueCampusMap.RouteCoordinates.Add(new Position(33.770104, -84.391631));
            blueCampusMap.RouteCoordinates.Add(new Position(33.769981, -84.391650));
            blueCampusMap.RouteCoordinates.Add(new Position(33.769950, -84.391740));
            blueCampusMap.RouteCoordinates.Add(new Position(33.769961, -84.392126));
            blueCampusMap.RouteCoordinates.Add(new Position(33.771282, -84.392072));

            blueCampusMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(33.774671, -84.396374), Distance.FromMiles(0.6)));

        }
    }
}