using System;
namespace GTNav {
    public class Location {
        public string Name { get; set; }
        public float Latititude { get; set; }
        public float Longitude { get; set; }

        public override string ToString()
        {
            return (Name);
        }
    }
}
