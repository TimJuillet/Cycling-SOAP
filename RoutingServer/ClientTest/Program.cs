using ClientTest.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                
        }
    }
}
