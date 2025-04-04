/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pagosruat;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;


/**
 *
 * @author janck
 */
public interface IRuat extends Remote {
    public ArrayList<Deuda> buscar(String ci) throws RemoteException;
    public boolean pagar(Deuda deuda) throws RemoteException;
}
