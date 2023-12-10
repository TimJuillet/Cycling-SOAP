using OSMRoutingClient;
using RoutingServer.ServiceReference1;
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
        private static double bikeSpeed = 50;
        private static double walkSpeed = 5;

        public Service1()
        {
            try
            {
                client = new OSMRoutingClient.OSMRoutingClient();
                JCDStationsProxyClient jCDStationsProxyClient = new JCDStationsProxyClient();
                // LogError("call proxy", new Exception());
                allStations = jCDStationsProxyClient.GetallStations().ToList();
            } catch(Exception e) {
                LogError("Error in init ", e);
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
                List<Position> trajetFromFirstStationToLastStation = GetTrajet(closestToStart.position, closestToEnd.position, "cycling-road");

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

        public bool isWalkingFaster(List<Position> WalkingtrajetFromBaseToFirstStation, List<Position> trajetFromFirstStationToLastStation, List<Position> WalkingtrajetFromLastStationToEnd, List<Position> WalkingtrajectFromBaseToEnd)
        {
            // Calculate distances in meters
            double distanceWalking = Position.distance(WalkingtrajetFromBaseToFirstStation) + Position.distance(WalkingtrajetFromLastStationToEnd);
            double distanceBiking = Position.distance(trajetFromFirstStationToLastStation);

            // Calculate times in hours
            double timeWalking = distanceWalking / walkSpeed; // in hours
            double timeBiking = distanceBiking / bikeSpeed;   // in hours

            double distanceWalkingFromBaseToEnd = Position.distance(WalkingtrajectFromBaseToEnd);

            // Calculate time in hours
            double timeWalkingFromBaseToEnd = distanceWalkingFromBaseToEnd / walkSpeed; // in hours

            // Compare times
            return timeWalkingFromBaseToEnd < (timeWalking + timeBiking);
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
            Position placePosition = client.getPosition(place).Result;
            Station closestStation = allStations.OrderBy(station => station.position.distance(placePosition)).First();
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
