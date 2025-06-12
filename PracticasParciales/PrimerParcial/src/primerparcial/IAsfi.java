/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package primerparcial;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

/**
 *
 * @author janck
 */
public interface IAsfi extends Remote {
    public ArrayList<Cuenta> ConsultarCuentas(String ci, String nombres,String apellidos) throws RemoteException;
    public boolean RetenerMonto(Cuenta cuenta, int MontoBs, String glosa) throws RemoteException;
}
