using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Maps;


namespace GTNav {

    public class CampusMap : Map {
        public List<Position> RouteCoordinates { get; set; }
        public List<CustomPin> CustomPins { get; set; }
        public BusMarker Marker { get; set; }

        public CampusMap()
        {
            RouteCoordinates = new List<Position>();
        }
    }

}
