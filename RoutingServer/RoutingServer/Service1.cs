using OSMRoutingClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1 { 

        public static OSMRoutingClient.OSMRoutingClient client = new OSMRoutingClient.OSMRoutingClient();

        public Route GetTrajet(String start, String end)
        {
            return client.getRoute(new Position(43.61570, 7.07136), new Position(43.58998, 7.12431));
        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
