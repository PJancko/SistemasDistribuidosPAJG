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
public class ServidorRuat {

    public static void main(String[] args) throws RemoteException, AlreadyBoundException, MalformedURLException {
        Ruat ruat = new Ruat();

        //LocateRegistry.createRegistry(1099);
        Naming.rebind("rmi://localhost/Ruat", ruat);
    }
}
