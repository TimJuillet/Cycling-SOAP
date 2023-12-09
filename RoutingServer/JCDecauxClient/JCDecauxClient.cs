using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace JCDecauxClient
{
    public class JCDecauxClient
    {

        static void Main(string[] args)
        {
            // Display the number of command line arguments.
            //Console.WriteLine(args.Length);

            // Do a test
            //JCDecauxClient client = new JCDecauxClient();
            //var contracts = client.GetAllStationsFromAllContracts().Result;
            //Console.WriteLine(contracts);
        }

        public JCDecauxClient() { }


        public async Task<List<Contract>> GetContracts()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://api.jcdecaux.com/vls/v3/contracts?apiKey=882e4ad9152fe8084440b76ad14cb9f55cc3d483");

            //response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            // deserialize the jsonResponse by keeping only the attribute "name"


            List<Contract> jsonString = System.Text.Json.JsonSerializer.Deserialize<List<Contract>>(jsonResponse);

            for (int i = 0; i < jsonString.Count; i++)
            {
                Console.WriteLine(jsonString[i].name);
            }

            return jsonString;
        }

        public async Task<List<Station>> GetStations(Contract contract)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"https://api.jcdecaux.com/vls/v3/stations?contract={contract.name}&apiKey=882e4ad9152fe8084440b76ad14cb9f55cc3d483");

            //response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            // deserialize the jsonResponse by keeping only the attribute "name"    

            List<Station> stations = new List<Station>();

            List<Station> jsonString = System.Text.Json.JsonSerializer.Deserialize<List<Station>>(jsonResponse);

            for (int i = 0; i < jsonString.Count; i++)
            {
                Console.WriteLine(jsonString[i].name);
            }

            return jsonString;
        }

        public async Task<List<Station>> GetAllStationsFromAllContracts()
        {

            List<Contract> contracts = await GetContracts();
            List<Station> allStations = new List<Station>();

            for (int i = 0; i < contracts.Count; i++)
            {
                List<Station> stations = await GetStations(contracts[i]);
                allStations.AddRange(stations);
            }

            return allStations;

        }
    }
}


public class Contract
{
    public string name { get; set; }
}

public class Station
{
    public string name { get; set; }
    public OSMRoutingClient.Position position { get; set; }
}

