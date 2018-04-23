using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace GTNav
{
    public class RedCampusMap : Map
    {
        public List<Position> RouteCoordinates { get; set; }
        public List<Position> Buses { get; set; }
        public List<CustomPin> CustomPins { get; set; }

        public RedCampusMap()
        {
            RouteCoordinates = new List<Position>();
        }
    }
}
