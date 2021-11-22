using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlignAPITest.Logical
{
    public class Location
    {
        public string Country { get; set; }
        public string Address { get; set; }

        public Location(string country, string address)
        {
            Country = country;
            Address = address;
        }

    }
}
