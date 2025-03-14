/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package rmi;

import java.net.MalformedURLException;
import java.rmi.AlreadyBoundException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.Naming;

/**
 *
 * @author janck
 */
public class ServidorAlcaldia {
    public static void main(String[] args)  throws RemoteException, AlreadyBoundException, MalformedURLException{
        Alcaldia alcaldia=new Alcaldia();
        LocateRegistry.createRegistry(1099); //levantar el servidor de alcaldia;
        Naming.bind("Alcaldia",alcaldia);
    }
}
