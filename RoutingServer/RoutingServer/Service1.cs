using OSMRoutingClient;
using RoutingServer.JCDecauxStationsProxy;
using System;
using System.Collections.Generic;
using System.IO;
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
            try
            {
                client = new OSMRoutingClient.OSMRoutingClient();
                JCDStationsProxyClient jCDStationsProxyClient = new JCDStationsProxyClient();
                LogError("call proxy", new Exception());
                allStations = jCDStationsProxyClient.GetallStations().ToList();
            } catch (Exception ex)
            {
                LogError("Error in Service1 constructor", ex);
            }
        }


        List<List<Position>> IService1.GetBestTrajet(String start, String end)
        {
            try
            {
                Station closestToStart = getClosestStationFromPlace(start);
                Station closestToEnd = getClosestStationFromPlace(end);

                Position startPostion = client.getPosition(start).Result;
                Position endPosition = client.getPosition(end).Result;

                List<Position> WalkingtrajetFromBaseToFirstStation = GetTrajet(startPostion, closestToStart.position, "foot-walking");
                List<Position> WalkingtrajetFromLastStationToEnd = GetTrajet(closestToEnd.position, endPosition, "foot-walking");
                List<Position> trajetFromFirstStationToLastStation = GetTrajet(closestToStart.position, closestToEnd.position, "cycling-regular");
                List<Position> WalkingtrajectFromBaseToEnd = GetTrajet(startPostion, endPosition, "foot-walking");

                if (isWalkingFaster(WalkingtrajetFromBaseToFirstStation, trajetFromFirstStationToLastStation, WalkingtrajetFromLastStationToEnd, WalkingtrajectFromBaseToEnd))
                {
                    return new List<List<Position>> { WalkingtrajectFromBaseToEnd };
                }
                else
                {
                    return new List<List<Position>> { WalkingtrajetFromBaseToFirstStation, trajetFromFirstStationToLastStation, WalkingtrajetFromLastStationToEnd };
                }
            }
            catch (Exception ex)
            {
                LogError("Error in GetBestTrajet method", ex);
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
            Station closestStation = null;
            Position placePosition = client.getPosition(place).Result;
            double minDistance = allStations[0].position.distance(placePosition);

            foreach (Station station in allStations)
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
}
