using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProxyCacheSwagg
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        private readonly StationsApi _stationsApi;
        private readonly MemoryCache _memoryCache;
        private readonly int _cacheDurationInSeconds;

        Service1() : this("882e4ad9152fe8084440b76ad14cb9f55cc3d483", 3600)
        {
        }

        Service1(string apiKey, int cacheDurationInSeconds)
        {
            if (apiKey == null)
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            if (!Configuration.Default.ApiKey.ContainsKey("apiKey"))
            {
                Configuration.Default.ApiKey.Add("apiKey", apiKey);
            }

            _stationsApi = new StationsApi();
            _memoryCache = MemoryCache.Default;
            _cacheDurationInSeconds = cacheDurationInSeconds;
        }


        public List<Station> GetStations()
        {
            List<Station> stations = _memoryCache.Get("stations") as List<Station>;
            if (stations == null)
            {
                stations = _stationsApi.GetStations();
                _memoryCache.Add("stations", stations, DateTimeOffset.Now.AddSeconds(_cacheDurationInSeconds));
            }
            return stations;
        }
    }
}
