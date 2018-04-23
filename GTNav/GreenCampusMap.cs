using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace GTNav
{
    public class GreenCampusMap : Map
    {
        public List<Position> RouteCoordinates { get; set; }
        public List<Position> Buses { get; set; }

        public GreenCampusMap()
        {
            RouteCoordinates = new List<Position>();
        }
    }
}
