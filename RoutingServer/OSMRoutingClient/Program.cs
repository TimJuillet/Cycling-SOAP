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
            Position start = new Position(43.61570, 7.07136);
            Position end = new Position(43.58998, 7.12431);
            Route route = client.getRoute(start, end);
            Console.WriteLine(route.features[0].geometry.coordinates[0][0]);
        }
    }
}
