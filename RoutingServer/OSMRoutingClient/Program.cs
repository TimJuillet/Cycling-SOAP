using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMRoutingClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OSMRoutingClient client = new OSMRoutingClient();
            Position start = client.getPosition("56 chemin de l'adrech 06530");
            Position end = client.getPosition("1 rue de la république 06530");
            
            Console.WriteLine("Start: " + start.getLatitudeString() + ", " + start.getLongitudeString());
        }
    }
}
