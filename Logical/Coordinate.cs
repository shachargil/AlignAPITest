using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlignAPITest.Logical
{
    public class Coordinate
    {
        public double Lat { get; set; }
        public double Lon { get; set; }

        public Coordinate(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }
    }
}
