﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProxyCachev3
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class JCDStationsProxy : IJCDStationsProxy
    {
        public List<Station> GetallStations()
        {
            throw new NotImplementedException();
        }
    }
    [DataContract]
    public class Station
    {
        [DataMember(Name = "position")]
        public Position position { get; set; }

        [DataMember(Name = "number")]
        public int number { get; set; }

        [DataMember(Name = "contractName")]
        public string contractName { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "address")]
        public string address { get; set; }

        [DataMember(Name = "banking")]
        public bool banking { get; set; }

        [DataMember(Name = "bonus")]
        public bool bonus { get; set; }

        [DataMember(Name = "status")]
        public string status { get; set; }

        [DataMember(Name = "connected")]
        public bool connected { get; set; }

        [DataMember(Name = "overflow")]
        public bool overflow { get; set; }

        [DataMember(Name = "shape")]
        public object shape { get; set; }

        [DataMember(Name = "totalStands")]
        public TotalStands totalStands { get; set; }

        [DataMember(Name = "mainStands")]
        public MainStands mainStands { get; set; }

        [DataMember(Name = "overflowStands")]
        public object overflowStands { get; set; }
    }

    [DataContract]
    public class Availabilities
    {
        [DataMember(Name = "bikes")]
        public int Bikes { get; set; }

        [DataMember(Name = "stands")]
        public int Stands { get; set; }

        [DataMember(Name = "mechanicalBikes")]
        public int MechanicalBikes { get; set; }

        [DataMember(Name = "electricalBikes")]
        public int ElectricalBikes { get; set; }

        [DataMember(Name = "electricalInternalBatteryBikes")]
        public int ElectricalInternalBatteryBikes { get; set; }

        [DataMember(Name = "electricalRemovableBatteryBikes")]
        public int ElectricalRemovableBatteryBikes { get; set; }
    }

    [DataContract]
    public class TotalStands
    {
        [DataMember(Name = "availabilities")]
        public Availabilities Availabilities { get; set; }

        [DataMember(Name = "capacity")]
        public int Capacity { get; set; }
    }

    [DataContract]
    public class MainStands
    {
        [DataMember(Name = "availabilities")]
        public Availabilities Availabilities { get; set; }

        [DataMember(Name = "capacity")]
        public int Capacity { get; set; }
    }


    [DataContract]
    public class Position
    {
        [DataMember(Name = "latitude")]
        public double latitude { get; set; }
        [DataMember(Name = "longitude")]
        public double longitude { get; set; }
    }
}