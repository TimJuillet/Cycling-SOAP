using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Collections.Specialized.BitVector32;

namespace OSMRoutingClient
{
    public class OSMRoutingClient
        
    {
        private static string api_key = "5b3ce3597851110001cf6248ba0ea999ab9e47e39f4ae0415f4840e3";
        private string base_url = "https://api.openrouteservice.org/";
        static readonly HttpClient client = new HttpClient();

        public OSMRoutingClient()
        {
        }

        static void Main(string[] args)
        {
            // Display the number of command line arguments.
            //Console.WriteLine(args.Length);
            // do a test
            //OSMRoutingClient client = new OSMRoutingClient();
            //Console.WriteLine(client.getPosition("Lyon").Result.getLatitude());
        }

        public string getUrl(string endpoint)
        {
            return base_url + endpoint + "?api_key=" + api_key;
        }
        
        
        async public Task<List<Position>> getRoute(Position start, Position end, string mode)
        {
            string url = getUrl("v2/directions/" + mode) + "&start=" + start.getLongitudeString() + "," + start.getLatitudeString() + "&end=" + end.getLongitudeString() + "," + end.getLatitudeString();
            
            Console.WriteLine(url);
            
            string json = await client.GetStringAsync(url);
            dynamic o = JsonConvert.DeserializeObject(json);
            List<Position> positions = new List<Position>();
            foreach (var step in o.features[0].geometry.coordinates)
            {
                positions.Add(new Position(step[1].ToObject<double>(), step[0].ToObject<double>()));
            }

            return positions;
        }
        
        async public Task<List<Position>> getRoute(Position start, Position end)
        {
            return await getRoute(start, end, "foot-walking");
        }

        async public Task<Position> getPosition(string query)
        {
            string url = getUrl("geocode/search") + "&text=" + query;
            Console.WriteLine(url);
            string json = await client.GetStringAsync(url);
            dynamic o = JsonConvert.DeserializeObject(json);
           
            return new Position(o.features[0].geometry.coordinates[1].ToObject<double>(), o.features[0].geometry.coordinates[0].ToObject<double>());
        }
    }

    [DataContract]
    public class Position
    {
        [DataMember(Name = "latitude")]
        public double latitude { get; set; }
        [DataMember(Name = "longitude")]
        public double longitude { get; set; }

        public Position(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }


        public string getLatitudeString()
        {
            return this.latitude.ToString().Replace(",", ".");
        }

        public string getLongitudeString()
        {
            return this.longitude.ToString().Replace(",", ".");
        }

        public double distance(Position position)
        {
            var tmp1 = new GeoCoordinate(this.latitude, this.longitude);
            var tmp2 = new GeoCoordinate(position.latitude, position.longitude);
            return tmp1.GetDistanceTo(tmp2);
        }

        public static double distance(List<Position> positions)
        {
            double d = 0;
            for (int i = 0; i < positions.Count - 1; i++)
            {
                d += positions[i].distance(positions[i + 1]);
            }

            return d;
        }
    }
}