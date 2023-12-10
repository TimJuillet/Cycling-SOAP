using ClientTest.ServiceReference1;
using ClientTest.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Service1Client = ClientTest.ServiceReference2.Service1Client;

namespace ClientTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            try
            {
                Service1Client service1Client = new Service1Client();
                var positions = service1Client.GetBestTrajet("Lyon", "Toulouse");
                //print the coordinates of all positions
                foreach (var position in positions)
                {
                    foreach (var position2 in position)
                    {
                        Console.WriteLine(position2.latitude);
                        Console.WriteLine(position2.longitude);
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
                */

            try
            {
                Service1Client jCDStationsProxyClient = new Service1Client();
                var stations = jCDStationsProxyClient.GetStations();
                //print the coordinates of all positions
                foreach (var station in stations)
                {
                    Console.WriteLine(station.name);
                    Console.WriteLine(station.position.lat);
                    Console.WriteLine(station.position.lng);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }
    }
}
