using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GTNav;
using GTNav.Droid;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

[assembly: ExportRenderer(typeof(BlueCampusMap), typeof(BlueCampusMapRenderer))]
namespace GTNav.Droid
{
    class BlueCampusMapRenderer : MapRenderer
    {
        List<Position> routeCoordinates;

        public BlueCampusMapRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsub
            }

            if (e.NewElement != null)
            {
                var formsMap = (BlueCampusMap)e.NewElement;
                routeCoordinates = formsMap.RouteCoordinates;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            var polylineOptions = new PolylineOptions();
            polylineOptions.InvokeColor(0x702418ff);

            foreach (var position in routeCoordinates)
            {
                polylineOptions.Add(new LatLng(position.Latitude, position.Longitude));
            }

            NativeMap.AddPolyline(polylineOptions);

            foreach (Bus bus in BusList.busList)
            {
                if (bus.route == "blue")
                {
                    CircleOptions circleOptions = new CircleOptions();
                    circleOptions.InvokeCenter(new LatLng(bus.lat, bus.lng));
                    circleOptions.InvokeRadius(30);
                    circleOptions.InvokeFillColor(0X700000ff);
                    circleOptions.InvokeStrokeColor(0X70FFFFFF);
                    circleOptions.InvokeStrokeWidth(5);

                    NativeMap.AddCircle(circleOptions);
                }
            }
        }
    }
}