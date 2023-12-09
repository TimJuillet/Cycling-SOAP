using JCDecauxClient;
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

        public static OSMRoutingClient.OSMRoutingClient client;
        public static List<Station> allStations;
        private static double bikeSpeed = 15;
        private static double walkSpeed = 5;

        public Service1()
        {
            InitializeAsync().Wait(); // Wait synchronously for initialization
        }

        private async Task InitializeAsync()
        {
            client = new OSMRoutingClient.OSMRoutingClient();
            JCDecauxClient.JCDecauxClient jcDecauxClient = new JCDecauxClient.JCDecauxClient();
            allStations = await jcDecauxClient.GetAllStationsFromAllContracts();
        }

        List<List<Position>> IService1.GetBestTrajet(String start, String end)
        {
        
            try
            {

                Station closestToStart =  getClosestStationFromPlace(start);
                Station closestToEnd =  getClosestStationFromPlace(end);

                List<Position> WalkingtrajetFromBaseToFirstStation =  GetTrajet(client.getPosition(start).Result, closestToStart.position, "foot-walking");
                List<Position> WalkingtrajetFromLastStationToEnd =  GetTrajet(closestToEnd.position, client.getPosition(end).Result, "foot-walking");
                List<Position> trajetFromFirstStationToLastStation =  GetTrajet(closestToStart.position, closestToEnd.position, "cycling-regular");
                List<Position> WalkingtrajectFromBaseToEnd =  GetTrajet(client.getPosition(start).Result, client.getPosition(end).Result, "foot-walking");

                if (isWalkingFaster(WalkingtrajetFromBaseToFirstStation, trajetFromFirstStationToLastStation, WalkingtrajetFromLastStationToEnd, WalkingtrajectFromBaseToEnd))
                {
                    return new List<List<Position>> { WalkingtrajectFromBaseToEnd };
                }
                else
                {
                    return new List<List<Position>> { WalkingtrajetFromBaseToFirstStation, trajetFromFirstStationToLastStation, WalkingtrajetFromLastStationToEnd };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace.ToString());
                return new List<List<Position>> { };
            }
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
            List<Position> positions = client.getRoute(start, end, mode).Result;
            return positions;
        }

        public Station getClosestStationFromPlace(String place)
        {
            // get the position of the place
            // compare the position of the place with the position of all the stations
            // return the closest station
            double minDistance = 0;
            Station closestStation = null;
            Position placePosition = client.getPosition(place).Result;

            foreach(Station station in allStations)
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
    }
}
