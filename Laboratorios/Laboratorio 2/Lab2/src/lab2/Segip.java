/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package lab2;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

/**
 *
 * @author janck
 */
public class Segip extends UnicastRemoteObject implements ISegip {

    public Segip() throws RemoteException {
        super();
    }

    @Override
    public Respuesta Verificar(String ci, String nombres, String primerApellido, String segundoApellido) throws RemoteException {

        if (ci.equals("1140506")) {
            return new Respuesta(true, "Los Datos son correctos");
        } else {
            return new Respuesta(false, "Los Datos del CI no son correctos");
        }
        
    }

}
