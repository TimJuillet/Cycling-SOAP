package org.example;

import org.tempuri.IService1;
import org.tempuri.Service1;

public class Main {
    public static void main(String[] args) {
        System.out.println("Hello world!");
        Service1 service = new Service1();
        IService1 port = service.getBasicHttpBindingIService1();
        org.datacontract.schemas._2004._07.osmroutingclient.ArrayOfArrayOfPosition pos = port.getBestTrajet("Lyon", "Paris");
        System.out.println(pos);
    }
}