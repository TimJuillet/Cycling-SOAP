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
            //43.60469° N, 7.08211° E
            //Position start = new Position(43.60469, 7.08211);
            // 43.61184° N, 7.07862° E
            //Position end = new Position(43.61184, 7.07862);
            //Route route = client.getRoute(start, end);
            //Console.WriteLine(route.features[0].geometry.coordinates[0][0]);
            
            Route route = client.getPosition("Nice");
            Console.WriteLine(route.features[0].geometry.coordinates[0][0]);
        }
    }
}
