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
                Console.WriteLine(service1Client.GetBestTrajet("Lyon", "Marseille"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
                
        }
    }
}
