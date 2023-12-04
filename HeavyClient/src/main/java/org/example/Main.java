package org.example;

import org.tempuri.IService1;
import org.tempuri.Service1;

public class Main {
    public static void main(String[] args) {
        try {
            System.out.println("Hello world!");
            Service1 service = new Service1();
            IService1 port = service.getBasicHttpBindingIService1();
            port.getBestTrajet("Lyon", "Paris");
            System.out.println("ui");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}