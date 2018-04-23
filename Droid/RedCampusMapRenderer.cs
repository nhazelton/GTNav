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

[assembly: ExportRenderer(typeof(RedCampusMap), typeof(RedCampusMapRenderer))]
namespace GTNav.Droid
{
    class RedCampusMapRenderer : MapRenderer
    {
        List<Position> routeCoordinates;

        public RedCampusMapRenderer(Context context) : base(context)
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
                var formsMap = (RedCampusMap)e.NewElement;
                routeCoordinates = formsMap.RouteCoordinates;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            var polylineOptions = new PolylineOptions();
            polylineOptions.InvokeColor(0x66FF0000);

            foreach (var position in routeCoordinates)
            {
                polylineOptions.Add(new LatLng(position.Latitude, position.Longitude));
            }

            NativeMap.AddPolyline(polylineOptions);
        }
    }
}