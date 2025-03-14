/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package rmi;

import java.net.MalformedURLException;
import java.rmi.AlreadyBoundException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;

/**
 *
 * @author janck
 */
public class ServidorBanco {
    public static void main(String[] args) throws RemoteException, AlreadyBoundException, MalformedURLException, NotBoundException{
        Banco banco = new Banco();
        //LocateRegistry.createRegistry(1099);
        Naming.rebind("rmi://localhost/Banco", banco);
    }
    
}
