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
        private string base_url = "https://api.openrouteservice.org/v2/directions/cycling-road?api_key=" + api_key;
        static readonly HttpClient client = new HttpClient();
        
        public Route getRoute(Position start, Position end)
        {
            string url = base_url + "&start=" + start.getLatitude() + "," + start.getLongitude() + "&end=" + end.getLatitude() + "," + end.getLongitude();
            // decode json
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