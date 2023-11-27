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
            Position end = client.getPosition("930 Route des Colles 06410 Biot");
            
            List<Position> positions = client.getRoute(start, end);
            foreach (Position position in positions)
            {
                Console.WriteLine(position.getLatitudeString() + ", " + position.getLongitudeString());
            }
        }
    }
}
