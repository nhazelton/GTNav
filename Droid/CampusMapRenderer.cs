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

        BusMarker marker;

        public CampusMapRenderer(Context context) : base(context) {
            // nothing ¯\_(ツ)_/¯
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null) {
                var formsMap = (CampusMap)e.NewElement;
                marker = formsMap.Marker;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map) {
            base.OnMapReady(map);

            PolylineOptions routeOptions = new PolylineOptions(); // use these to trace the *routes*, here's Ferst Dr for example
            routeOptions.Add(new LatLng(33.771282, -84.392072));
            routeOptions.Add(new LatLng(33.776892, -84.392088));
            routeOptions.Add(new LatLng(33.776961, -84.395176));
            routeOptions.Add(new LatLng(33.778180, -84.396451));
            routeOptions.Add(new LatLng(33.778413, -84.401306));

            NativeMap.AddPolyline(routeOptions);

            CircleOptions markerOptions = new CircleOptions(); // use these to mark the *buses* (until we get some better markers). I've put one at North Ave for example
            markerOptions.InvokeCenter(new LatLng(33.770171, -84.3911916));
            markerOptions.InvokeRadius(1000);
            markerOptions.InvokeFillColor(0XFF6666);
            markerOptions.InvokeStrokeColor(0XFF4949);
            markerOptions.InvokeStrokeWidth(1);

            NativeMap.AddCircle(markerOptions);
        }

    } // CampusMapRenderer
}