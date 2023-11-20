namespace OSMRoutingClient
{
    public class OSMRoutingClient
    {
        private string api_key = "5b3ce3597851110001cf6248d6b9b3b0c1e84c7d9b7b4b0b6a0b2a4d";
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
    
    public class Route
    {
        public string[] features { get; set; }
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