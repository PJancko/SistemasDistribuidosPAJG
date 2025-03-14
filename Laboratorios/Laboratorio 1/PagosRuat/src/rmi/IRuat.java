/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package rmi;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

/**
 *
 * @author janck
 */
public interface IRuat extends Remote {
    public ArrayList<Deuda> Buscar(String ci) throws RemoteException;
    public boolean Pagar(Deuda deuda) throws RemoteException;
}
