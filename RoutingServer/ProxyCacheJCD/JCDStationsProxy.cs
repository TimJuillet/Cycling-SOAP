using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCacheJCD
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
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
                }
                catch (Exception ex)
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
        public int number { get; set; }

        [DataMember(Name = "contractName")]
        public string contractName { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "address")]
        public string address { get; set; }

        [DataMember(Name = "banking")]
        public bool banking { get; set; }

        [DataMember(Name = "bonus")]
        public bool bonus { get; set; }

        [DataMember(Name = "status")]
        public string status { get; set; }

        [DataMember(Name = "connected")]
        public bool connected { get; set; }

        [DataMember(Name = "overflow")]
        public bool overflow { get; set; }

        [DataMember(Name = "shape")]
        public object shape { get; set; }

        [DataMember(Name = "totalStands")]
        public TotalStands totalStands { get; set; }

        [DataMember(Name = "mainStands")]
        public MainStands mainStands { get; set; }

        [DataMember(Name = "overflowStands")]
        public object overflowStands { get; set; }
    }

    [DataContract]
    public class Availabilities
    {
        [DataMember(Name = "bikes")]
        public int Bikes { get; set; }

        [DataMember(Name = "stands")]
        public int Stands { get; set; }

        [DataMember(Name = "mechanicalBikes")]
        public int MechanicalBikes { get; set; }

        [DataMember(Name = "electricalBikes")]
        public int ElectricalBikes { get; set; }

        [DataMember(Name = "electricalInternalBatteryBikes")]
        public int ElectricalInternalBatteryBikes { get; set; }

        [DataMember(Name = "electricalRemovableBatteryBikes")]
        public int ElectricalRemovableBatteryBikes { get; set; }
    }

    [DataContract]
    public class TotalStands
    {
        [DataMember(Name = "availabilities")]
        public Availabilities Availabilities { get; set; }

        [DataMember(Name = "capacity")]
        public int Capacity { get; set; }
    }

    [DataContract]
    public class MainStands
    {
        [DataMember(Name = "availabilities")]
        public Availabilities Availabilities { get; set; }

        [DataMember(Name = "capacity")]
        public int Capacity { get; set; }
    }
}
