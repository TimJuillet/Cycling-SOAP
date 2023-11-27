using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Text.Json;

namespace OSMRoutingClient
{
    public class OSMRoutingClient
    {
        private static string api_key = "5b3ce3597851110001cf6248ba0ea999ab9e47e39f4ae0415f4840e3";
        private string base_url = "https://api.openrouteservice.org/";
        static readonly HttpClient client = new HttpClient();

        public string getUrl(string endpoint)
        {
            return base_url + endpoint + "?api_key=" + api_key;
        }
        
        public Route getRoute(Position start, Position end)
        {
            string url = getUrl("v2/directions/foot-walking") + "&start=" + start.getLatitudeString() + "," + start.getLongitudeString() + "&end=" + end.getLatitudeString() + "," + end.getLongitudeString();
            
            string json = client.GetStringAsync(url).Result;
            return JsonSerializer.Deserialize<Route>(json);
        }

        public Route getPosition(string query)
        {
            string url = getUrl("geocode/search") + "&text=" + query;
            Console.WriteLine(url);
            string json = client.GetStringAsync(url).Result;
            return JsonSerializer.Deserialize<Route>(json);
            
        }
    }
    
    public class Position
    {
        double latitude;
        double longitude;
        
        public Position(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
        
        public double getLatitude()
        {
            return this.latitude;
        }
        
        public double getLongitude()
        {
            return this.longitude;
        }
        
        public string getLatitudeString()
        {
            return this.latitude.ToString().Replace(",", ".");
        }
        
        public string getLongitudeString()
        {
            return this.longitude.ToString().Replace(",", ".");
        }
    }
    
    public class Route
    {
        public Feature[] features { get; set; }
    }
    
    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
    }
    
    public class Geometry
    {
        public string type { get; set; }
        public float[][] coordinates { get; set; }
    }
}