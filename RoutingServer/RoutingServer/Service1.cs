using OSMRoutingClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1 { 

        public static OSMRoutingClient.OSMRoutingClient client = new OSMRoutingClient.OSMRoutingClient();
        public static Task<List<Station>> allStations = JCDecauxClient.JCDecauxClient.GetAllStationsFromAllContracts();

        public List<Position> GetTrajet(String start, String end, String mode)
        {
            List<Position> positions = new List<Position>();
            positions = client.getRoute(client.getPosition(start), client.getPosition(end), mode);
            return positions;
        }

        public Station getClosestStationFromPlace(String place)
        {
            // get the position of the place
            // compare the position of the place with the position of all the stations
            // return the closest station
            double minDistance = 0;
            Station closestStation = null;
            Position placePosition = client.getPosition(place);

            foreach(Station station in allStations.Result)
            {
                double distance = station.position.distance(placePosition);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestStation = station;
                }
            }
            
            return closestStation;
        }



        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
