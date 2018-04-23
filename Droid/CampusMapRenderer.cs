using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using GTNav;
using GTNav.Droid;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CampusMap), typeof(CampusMapRenderer))]
namespace GTNav.Droid {

    class CampusMapRenderer : MapRenderer {

        List<Position> blueCoordinates = new List<Position>();
        List<Position> redCoordinates = new List<Position>();
        List<Position> greenCoordinates = new List<Position>();
        List<Position> trolleyCoordinates = new List<Position>();
        List<CustomPin> customPins;
        BusMarker marker;


        public CampusMapRenderer(Context context) : base(context) {
            // nothing ¯\_(ツ)_/¯
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            marker.SetIcon(BitmapDescriptorFactory.FromAsset("BusStop_blue.png"));
            return marker;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null) {
                var formsMap = (CampusMap)e.NewElement;
                //routeCoordinates = formsMap.RouteCoordinates;
                //marker = formsMap.Marker;
                customPins = formsMap.CustomPins;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map) {
            base.OnMapReady(map);

            // add blue positions
            blueCoordinates.Add(new Position(33.771282, -84.392072));
            blueCoordinates.Add(new Position(33.776892, -84.392088));
            blueCoordinates.Add(new Position(33.776961, -84.395176));
            blueCoordinates.Add(new Position(33.778180, -84.396451));
            blueCoordinates.Add(new Position(33.778413, -84.401306));
            blueCoordinates.Add(new Position(33.778007, -84.401955));
            blueCoordinates.Add(new Position(33.777316, -84.402397));// 6th and ferst
            blueCoordinates.Add(new Position(33.777295, -84.404166));
            blueCoordinates.Add(new Position(33.778676, -84.404192));
            blueCoordinates.Add(new Position(33.778696, -84.406125));
            blueCoordinates.Add(new Position(33.779625, -84.406100));
            blueCoordinates.Add(new Position(33.779638, -84.402478));
            blueCoordinates.Add(new Position(33.778390, -84.401328));
            blueCoordinates.Add(new Position(33.777987, -84.401987));
            blueCoordinates.Add(new Position(33.777316, -84.402397));

            blueCoordinates.Add(new Position(33.774930, -84.402623));
            blueCoordinates.Add(new Position(33.774375, -84.402450));
            blueCoordinates.Add(new Position(33.773929, -84.402063));
            blueCoordinates.Add(new Position(33.773688, -84.401366));
            blueCoordinates.Add(new Position(33.773141, -84.397929));
            blueCoordinates.Add(new Position(33.772972, -84.397483));
            blueCoordinates.Add(new Position(33.772405, -84.396655));
            blueCoordinates.Add(new Position(33.772355, -84.395508));
            blueCoordinates.Add(new Position(33.771389, -84.395540));
            blueCoordinates.Add(new Position(33.771384, -84.396136));
            blueCoordinates.Add(new Position(33.768869, -84.396118));
            blueCoordinates.Add(new Position(33.768857, -84.394114));
            blueCoordinates.Add(new Position(33.768688, -84.393522));
            blueCoordinates.Add(new Position(33.768873, -84.392757));
            blueCoordinates.Add(new Position(33.768914, -84.392129));
            blueCoordinates.Add(new Position(33.769955, -84.392100));
            blueCoordinates.Add(new Position(33.769956, -84.391723));
            blueCoordinates.Add(new Position(33.770022, -84.391630));
            blueCoordinates.Add(new Position(33.770132, -84.391643));
            blueCoordinates.Add(new Position(33.770169, -84.392123));
            blueCoordinates.Add(new Position(33.771282, -84.392072));

            // add red positions
            redCoordinates.Add(new Position(33.771282, -84.392072));
            redCoordinates.Add(new Position(33.776892, -84.392088));
            redCoordinates.Add(new Position(33.776961, -84.395176));
            redCoordinates.Add(new Position(33.778180, -84.396451));
            redCoordinates.Add(new Position(33.778413, -84.401306));
            redCoordinates.Add(new Position(33.779669, -84.402527));
            redCoordinates.Add(new Position(33.779638, -84.406084));
            redCoordinates.Add(new Position(33.778707, -84.406125));
            redCoordinates.Add(new Position(33.778673, -84.404191));
            redCoordinates.Add(new Position(33.777309, -84.404225));
            redCoordinates.Add(new Position(33.777316, -84.402397));// 6th and ferst
            redCoordinates.Add(new Position(33.775246, -84.402564));
            redCoordinates.Add(new Position(33.774685, -84.402288));
            redCoordinates.Add(new Position(33.774595, -84.402528));
            redCoordinates.Add(new Position(33.774375, -84.402450));
            redCoordinates.Add(new Position(33.773929, -84.402063));
            redCoordinates.Add(new Position(33.773688, -84.401366));
            redCoordinates.Add(new Position(33.773141, -84.397929));
            redCoordinates.Add(new Position(33.772972, -84.397483));
            redCoordinates.Add(new Position(33.772405, -84.396655));
            redCoordinates.Add(new Position(33.772355, -84.395508));
            redCoordinates.Add(new Position(33.771389, -84.395540));
            redCoordinates.Add(new Position(33.771307, -84.392058));
            redCoordinates.Add(new Position(33.770163, -84.392197));
            redCoordinates.Add(new Position(33.770164, -84.391692));
            redCoordinates.Add(new Position(33.770104, -84.391631));
            redCoordinates.Add(new Position(33.769981, -84.391650));
            redCoordinates.Add(new Position(33.769950, -84.391740));
            redCoordinates.Add(new Position(33.769961, -84.392126));
            redCoordinates.Add(new Position(33.771282, -84.392072));

            // add green positions
            greenCoordinates.Add(new Position(33.773033, -84.397003));
            greenCoordinates.Add(new Position(33.773283, -84.397038));
            greenCoordinates.Add(new Position(33.773312, -84.397156));
            greenCoordinates.Add(new Position(33.773261, -84.397245));
            greenCoordinates.Add(new Position(33.773154, -84.397244));
            greenCoordinates.Add(new Position(33.773035, -84.397152));
            greenCoordinates.Add(new Position(33.772973, -84.397050));
            greenCoordinates.Add(new Position(33.772814, -84.397200));
            greenCoordinates.Add(new Position(33.773175, -84.397883));
            greenCoordinates.Add(new Position(33.773730, -84.401258));
            greenCoordinates.Add(new Position(33.774334, -84.402381));
            greenCoordinates.Add(new Position(33.774581, -84.402502));
            greenCoordinates.Add(new Position(33.774689, -84.402284));
            greenCoordinates.Add(new Position(33.775154, -84.402428));
            greenCoordinates.Add(new Position(33.775272, -84.402586));
            greenCoordinates.Add(new Position(33.777294, -84.402387));
            greenCoordinates.Add(new Position(33.777984, -84.401980));
            greenCoordinates.Add(new Position(33.778408, -84.401282));
            greenCoordinates.Add(new Position(33.778471, -84.400236));
            greenCoordinates.Add(new Position(33.778256, -84.399113));
            greenCoordinates.Add(new Position(33.780563, -84.399115));
            greenCoordinates.Add(new Position(33.781522, -84.399177));
            greenCoordinates.Add(new Position(33.781586, -84.404166));
            greenCoordinates.Add(new Position(33.784783, -84.406075));
            greenCoordinates.Add(new Position(33.786210, -84.406042)); // 14th st
            greenCoordinates.Add(new Position(33.786188, -84.397254));
            greenCoordinates.Add(new Position(33.786538, -84.393255));
            greenCoordinates.Add(new Position(33.786537, -84.391980));
            greenCoordinates.Add(new Position(33.781614, -84.391985));
            greenCoordinates.Add(new Position(33.781551, -84.399202));
            greenCoordinates.Add(new Position(33.778297, -84.399238));
            greenCoordinates.Add(new Position(33.778490, -84.400610));
            greenCoordinates.Add(new Position(33.778396, -84.401321));
            greenCoordinates.Add(new Position(33.777904, -84.402060));
            greenCoordinates.Add(new Position(33.777293, -84.402421));
            greenCoordinates.Add(new Position(33.774896, -84.402622));
            greenCoordinates.Add(new Position(33.774316, -84.402446));
            greenCoordinates.Add(new Position(33.773904, -84.402016));
            greenCoordinates.Add(new Position(33.773685, -84.401316));
            greenCoordinates.Add(new Position(33.773193, -84.398039));
            greenCoordinates.Add(new Position(33.772811, -84.397237));
            greenCoordinates.Add(new Position(33.772793, -84.397195));
            greenCoordinates.Add(new Position(33.773033, -84.397003));

            PolylineOptions routeOptions = new PolylineOptions(); // route tracing, default to blue for now
            routeOptions.InvokeColor(0x3f75A2FF);

            //routeOptions.InvokeColor(0x33DD1D36); // red
            //routeOptions.InvokeColor(0x6600a86b); // green
            foreach (var position in blueCoordinates)
            {
                routeOptions.Add(new LatLng(position.Latitude, position.Longitude));
            }

            NativeMap.AddPolyline(routeOptions);

            CircleOptions markerOptions = new CircleOptions(); // use these to mark the *buses* (until we get some better markers). I've put one at North Ave for example
            markerOptions.InvokeCenter(new LatLng(33.770171, -84.3911916));
            markerOptions.InvokeRadius(10);
            markerOptions.InvokeFillColor(0X33DD1D36);
            markerOptions.InvokeStrokeColor(0XFF4949);
            markerOptions.InvokeStrokeWidth(3);

            NativeMap.AddCircle(markerOptions);
        }

    } // CampusMapRenderer
}