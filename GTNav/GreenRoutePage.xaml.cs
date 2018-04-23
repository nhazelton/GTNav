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
	public partial class GreenRoutePage : ContentPage
	{
		public GreenRoutePage ()
		{
			InitializeComponent ();

            greenCampusMap.RouteCoordinates.Add(new Position(33.773033, -84.397003));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773283, -84.397038));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773312, -84.397156));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773261, -84.397245));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773154, -84.397244));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773035, -84.397152));
            greenCampusMap.RouteCoordinates.Add(new Position(33.772973, -84.397050));
            greenCampusMap.RouteCoordinates.Add(new Position(33.772814, -84.397200));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773175, -84.397883));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773730, -84.401258));
            greenCampusMap.RouteCoordinates.Add(new Position(33.774334, -84.402381));
            greenCampusMap.RouteCoordinates.Add(new Position(33.774581, -84.402502));
            greenCampusMap.RouteCoordinates.Add(new Position(33.774689, -84.402284));
            greenCampusMap.RouteCoordinates.Add(new Position(33.775154, -84.402428));
            greenCampusMap.RouteCoordinates.Add(new Position(33.775272, -84.402586));
            greenCampusMap.RouteCoordinates.Add(new Position(33.777294, -84.402387));
            greenCampusMap.RouteCoordinates.Add(new Position(33.777984, -84.401980));
            greenCampusMap.RouteCoordinates.Add(new Position(33.778408, -84.401282));
            greenCampusMap.RouteCoordinates.Add(new Position(33.778471, -84.400236));
            greenCampusMap.RouteCoordinates.Add(new Position(33.778256, -84.399113));
            greenCampusMap.RouteCoordinates.Add(new Position(33.780563, -84.399115));
            greenCampusMap.RouteCoordinates.Add(new Position(33.781522, -84.399177));
            greenCampusMap.RouteCoordinates.Add(new Position(33.781586, -84.404166));
            greenCampusMap.RouteCoordinates.Add(new Position(33.784783, -84.406075));
            greenCampusMap.RouteCoordinates.Add(new Position(33.786210, -84.406042));
            greenCampusMap.RouteCoordinates.Add(new Position(33.786188, -84.397254));
            greenCampusMap.RouteCoordinates.Add(new Position(33.786538, -84.393255));
            greenCampusMap.RouteCoordinates.Add(new Position(33.786537, -84.391980));
            greenCampusMap.RouteCoordinates.Add(new Position(33.781614, -84.391985));
            greenCampusMap.RouteCoordinates.Add(new Position(33.781551, -84.399202));
            greenCampusMap.RouteCoordinates.Add(new Position(33.778297, -84.399238));
            greenCampusMap.RouteCoordinates.Add(new Position(33.778490, -84.400610));
            greenCampusMap.RouteCoordinates.Add(new Position(33.778396, -84.401321));
            greenCampusMap.RouteCoordinates.Add(new Position(33.777904, -84.402060));
            greenCampusMap.RouteCoordinates.Add(new Position(33.777293, -84.402421));
            greenCampusMap.RouteCoordinates.Add(new Position(33.774896, -84.402622));
            greenCampusMap.RouteCoordinates.Add(new Position(33.774316, -84.402446));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773904, -84.402016));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773685, -84.401316));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773193, -84.398039));
            greenCampusMap.RouteCoordinates.Add(new Position(33.772811, -84.397237));
            greenCampusMap.RouteCoordinates.Add(new Position(33.772793, -84.397195));
            greenCampusMap.RouteCoordinates.Add(new Position(33.773033, -84.397003));

            greenCampusMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(33.774671, -84.396374), Distance.FromMiles(0.6)));
        }
	}
}