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
            Position start = new Position(48.853, 2.35);
            Position end = new Position(48.858, 2.294);
            Route route = client.getRoute(start, end);
            Console.WriteLine(route.features[0].geometry.coordinates[0][0]);
        }
    }
}
