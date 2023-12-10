using ProxyCache;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            //JCDecauxClient client = new JCDecauxClient();
            //var contracts = client.GetAllStationsFromAllContracts().Result;
            //Console.WriteLine(contracts);
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


        List<Station> IJCDStationsProxy.GetallStations()
        {
            List<Station> allstations = cache.Get("allStations") as List<Station>;
            if (allstations == null)
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.GetAsync($"https://api.jcdecaux.com/vls/v3/stations?apiKey=882e4ad9152fe8084440b76ad14cb9f55cc3d483").Result;
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                allstations = deserializeStations(jsonResponse);
                cache.Add("allStations", allstations, ObjectCache.InfiniteAbsoluteExpiration);
            }
            return allstations;
        }

        public List<Station> deserializeStations(string jsonString)
        {
            List<Station> stations = System.Text.Json.JsonSerializer.Deserialize<List<Station>>(jsonString);
            return stations;
        }
     
    }
}

public class Contract
{
    public string name { get; set; }
}

[DataContract]
public class Station
{
    [DataMember(Name = "name")]
    public string name { get; set; }
    [DataMember(Name = "position")]
    public OSMRoutingClient.Position position { get; set; }
}

