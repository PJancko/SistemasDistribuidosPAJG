/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package operacionesrmi;

import java.rmi.Remote;
import java.rmi.RemoteException;

/**
 *
 * @author janck
 */
public interface IOperaciones extends Remote {
    public void SetN(int n) throws RemoteException;
    public int calcularFibonacci() throws RemoteException;
    public int calcularFactorial() throws RemoteException;
    public int calcularSumatoria() throws RemoteException;
    
}
