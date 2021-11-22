
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlignAPITest.Logical
{
    public class CalcAddress
    {
        public static async Task<Coordinate> GetCoordinateByAddressAsync(Location location)
        {

            HttpClient client = new HttpClient();
            string msg = await client.GetStringAsync(string.Format("https://atlas.microsoft.com/search/address/json?subscription-key=MCVngD7ppi-H174en2vWgJTigGFG_ulTEYeL0yOfTFE&limit=1&api-version=1.0&query={0}", location.Address + " " + location.Country));
            dynamic response = JObject.Parse(msg);
            Coordinate coordinate = new Coordinate(Convert.ToDouble(response.results[0].position.lat), Convert.ToDouble(response.results[0].position.lon));
            return coordinate;
            
        }
        public static double CalcDistance(Coordinate coordinateA, Coordinate coordinateB, char unit = 'K')
        {
            if ((coordinateA.Lat == coordinateB.Lat) && (coordinateA.Lon == coordinateB.Lon))
                return 0;
            else
            {
                double theta = coordinateA.Lon - coordinateB.Lon;
                double dist = Math.Sin(deg2rad(coordinateA.Lat)) * Math.Sin(deg2rad(coordinateB.Lat)) + Math.Cos(deg2rad(coordinateA.Lat)) * Math.Cos(deg2rad(coordinateB.Lat)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K')
                    dist = dist * 1.609344;
                else if (unit == 'N')
                    dist = dist * 0.8684;
                return (dist);
            }
        }
        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
