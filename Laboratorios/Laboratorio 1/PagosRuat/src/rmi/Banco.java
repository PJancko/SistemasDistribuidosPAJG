/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package rmi;

import java.net.MalformedURLException;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author janck
 */
public class Banco extends UnicastRemoteObject implements IBanco {
    
    IRuat ruat;
    
    public Banco() throws RemoteException{
        super();
        try {
            
            ruat = (IRuat) Naming.lookup("rmi://localhost/Ruat");
            
        } catch (NotBoundException ex) {
            Logger.getLogger(Banco.class.getName()).log(Level.SEVERE, null, ex);
        } catch (MalformedURLException ex) {
            Logger.getLogger(Banco.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public ArrayList<Deuda> ObtenerDeuda(String ci) throws RemoteException {
        return ruat.Buscar(ci);
    }

    @Override
    public boolean Pagar(Deuda deuda) throws RemoteException {
        return ruat.Pagar(deuda);
    }
    
}
