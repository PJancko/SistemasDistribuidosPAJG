/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package rmi;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;

/**
 *
 * @author janck
 */
public class Alcaldia extends UnicastRemoteObject implements IAlcaldia {
    
    public Alcaldia() throws RemoteException{
        super();
    }

    @Override
    public boolean BuscarObservaciones(String CI) throws RemoteException {
        if ("1234567".equals(CI)) {
            return true;
        }
        return false;
    }
    
}
