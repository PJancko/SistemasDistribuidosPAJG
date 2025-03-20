/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package lab2;

import java.net.MalformedURLException;
import java.rmi.AlreadyBoundException;
import java.rmi.Naming;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author janck
 */
public class ServidorSegip {

    public static void main(String[] args) {
        try {
            // Iniciar el registro RMI en el puerto 1099 si no está corriendo
            try {
                LocateRegistry.createRegistry(1099);
                System.out.println("Registro RMI iniciado en el puerto 1099...");
            } catch (RemoteException e) {
                System.out.println("El registro RMI ya está en ejecución.");
            }

            // Crear la instancia del objeto Segip
            Segip segip = new Segip();

            // Registrar el objeto RMI
            Naming.rebind("rmi://localhost/Segip", segip);

            System.out.println("✅ Servidor Segip está listo...");
        } catch (Exception e) {
            System.err.println("❌ Error en el servidor RMI: " + e.getMessage());
            e.printStackTrace();
        }
    }
}

