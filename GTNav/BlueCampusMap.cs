﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace GTNav
{
    public class BlueCampusMap : Map
    {
        public List<Position> RouteCoordinates { get; set; }

        public BlueCampusMap()
        {
            RouteCoordinates = new List<Position>();
        }
    }
}
