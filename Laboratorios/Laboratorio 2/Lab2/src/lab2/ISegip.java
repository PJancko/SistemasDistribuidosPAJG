/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package lab2;

import java.rmi.Remote;
import java.rmi.RemoteException;

/**
 *
 * @author janck
 */
public interface ISegip extends Remote {
    public Respuesta Verificar(String ci,String nombres,String primerApellido, String segunoApellido) throws RemoteException;
}
