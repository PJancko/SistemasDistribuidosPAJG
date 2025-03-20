/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package lab2;

import java.net.MalformedURLException;
import java.rmi.AlreadyBoundException;
import java.rmi.RemoteException;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.rmi.Naming;
import java.rmi.registry.LocateRegistry;

/**
 *
 * @author janck
 */
public class ServidorUniversidad {
    public static void main(String[] args){
        try {
            // Crear la instancia del objeto Segip
            Universidad universidad = new Universidad();

            // Registrar el objeto RMI
            Naming.rebind("rmi://localhost/Universidad", universidad);

            System.out.println("Servidor Universidad está listo...");
        } catch (Exception e) {
            System.err.println("Error en el servidor RMI: " + e.getMessage());
            e.printStackTrace();
        }
    }
}
