using ProxyCache;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ProxyCache
{
    public class JCDStationProxy : IJCDStationsProxy
    {
        private static readonly ObjectCache cache = MemoryCache.Default;

        static void Main(string[] args)
        {
            // Display the number of command line arguments.
            //Console.WriteLine(args.Length);
            // Do a test
            //JCDStationProxy client = new JCDStationProxy();
            //IJCDStationsProxy proxy = new JCDStationProxy();
            //List<Station> stations = proxy.GetallStations();
            //Console.WriteLine(stations);
        }

        public JCDStationProxy() { }


        /*
        public async Task<List<Contract>> GetContracts()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://api.jcdecaux.com/vls/v3/contracts?apiKey=882e4ad9152fe8084440b76ad14cb9f55cc3d483");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Contract> jsonString = deserializeContracts(jsonResponse);
            return jsonString;
        }


        public List<Contract> deserializeContracts(string jsonString)
        {
            List<Contract> contracts = System.Text.Json.JsonSerializer.Deserialize<List<Contract>>(jsonString);
            return contracts;
        }
        */

        async public Task<List<Station>> asyncgetStations()
        {
            List<Station> allstations = cache.Get("allStations") as List<Station>;
            if (allstations == null)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    HttpResponseMessage response = await httpClient.GetAsync($"https://api.jcdecaux.com/vls/v3/stations?apiKey=882e4ad9152fe8084440b76ad14cb9f55cc3d483");
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    allstations = deserializeStations(jsonResponse);
                    cache.Add("allStations", allstations, ObjectCache.InfiniteAbsoluteExpiration);
                } catch (Exception ex)
                {
                    LogError("Error in GetallStations method", ex);
                }
            }
            return allstations;
        } 

        List<Station> IJCDStationsProxy.GetallStations()
        {
            return asyncgetStations().Result;
        }

        public List<Station> deserializeStations(string jsonString)
        {
            List<Station> stations = System.Text.Json.JsonSerializer.Deserialize<List<Station>>(jsonString);
            LogError($"Stations deserialized : nb station {stations.Count}", new Exception());
            return stations;
        }

        public static void LogError(string message, Exception ex)
        {
            // Log the error to a file
            try
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\astag\\source\\repos\\ProjectBiking\\RoutingServer\\ClientTest\\Connected Services\\ServiceReference1\\zizicaca.txt", true))
                {
                    writer.WriteLine($"[{DateTime.Now}] - {message}: {ex.ToString()}");
                }
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Failed to log error: {logEx.Message}");
            }
        }

    }


    [DataContract]
    public class Station
    {
        [DataMember(Name = "position")]
        public OSMRoutingClient.Position position { get; set; }
        [DataMember(Name = "number")]
        public int Number { get; set; }
        [DataMember(Name = "ContractName")]
        public string ContractName { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Address")]
        public string Address { get; set; }
        [DataMember(Name = "BikeStands")]
        public bool Banking { get; set; }
        [DataMember(Name = "Bonus")]
        public bool Bonus { get; set; }
        [DataMember(Name = "Status")]
        public string Status { get; set; }
        [DataMember(Name = "LastUpdate")]
        public DateTime LastUpdate { get; set; }
        [DataMember(Name = "Connected")]
        public bool Connected { get; set; }
        [DataMember(Name = "Overflow")]
        public bool Overflow { get; set; }
        [DataMember(Name = "Shape")]
        public object Shape { get; set; }
        [DataMember(Name = "TotalStands")]
        public TotalStands TotalStands { get; set; }
        [DataMember(Name = "MainStands")]
        public MainStands MainStands { get; set; }
        [DataMember(Name = "OverflowStands")]
        public object OverflowStands { get; set; }
    }

    [DataContract]
    public class Availabilities
    {
        public int Bikes { get; set; }
        public int Stands { get; set; }
        public int MechanicalBikes { get; set; }
        public int ElectricalBikes { get; set; }
        public int ElectricalInternalBatteryBikes { get; set; }
        public int ElectricalRemovableBatteryBikes { get; set; }
    }
    [DataContract]
    public class TotalStands
    {
        public Availabilities Availabilities { get; set; }
        public int Capacity { get; set; }
    }
    [DataContract]
    public class MainStands
    {
        public Availabilities Availabilities { get; set; }
        public int Capacity { get; set; }
    }
}
