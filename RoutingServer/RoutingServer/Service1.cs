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
        private static double bikeSpeed = 15;
        private static double walkSpeed = 5;

        List<Position> GetBestTrajet(String start, String end)
        {
            Station closestToStart = getClosestStationFromPlace(start);
            Station closestToEnd = getClosestStationFromPlace(end);

            List<Position> WalkingtrajetFromBaseToFirstStation = GetTrajet(client.getPosition(start), closestToStart.position, "foot-walking");
            List<Position> WalkingtrajetFromLastStationToEnd = GetTrajet(closestToEnd.position, client.getPosition(end), "foot-walking");
            List<Position> trajetFromFirstStationToLastStation = GetTrajet(closestToStart.position, closestToEnd.position, "cycling-regular");

            List<Position> WalkingtrajectFromBaseToEnd = GetTrajet(client.getPosition(start), client.getPosition(end), "foot-walking");
            return null;
        }

        public Boolean isWalkingFaster(List<Position> WalkingtrajetFromBaseToFirstStation, List<Position> trajetFromFirstStationToLastStation, List<Position> WalkingtrajetFromLastStationToEnd, List<Position> WalkingtrajectFromBaseToEnd)
        {
            double timeWalking = (Position.distance(WalkingtrajetFromBaseToFirstStation) + Position.distance(WalkingtrajetFromLastStationToEnd)) / walkSpeed;
            double timeBiking = Position.distance(trajetFromFirstStationToLastStation) / bikeSpeed;
            double timeWalkingFromBaseToEnd = Position.distance(WalkingtrajectFromBaseToEnd) / walkSpeed;
            return timeWalkingFromBaseToEnd < timeWalking + timeBiking;
        }


        public List<Position> GetTrajet(Position start, Position end, String mode)
        {
            List<Position> positions = client.getRoute(start, end, mode);
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

        List<Position> IService1.GetBestTrajet(string start, string end)
        {
            throw new NotImplementedException();
        }
    }
}
