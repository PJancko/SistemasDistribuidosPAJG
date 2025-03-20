/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package lab2;

import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author janck
 */
public class Cliente {

    public static void main(String[] args) {
        IUniversidad universidad;
        Diploma diploma;

        try {
            // Conectarse al servidor RMI
            universidad = (IUniversidad) Naming.lookup("rmi://localhost/Universidad");

            // Llamar al método remoto para emitir el diploma
            diploma = universidad.EmitirDiploma("1140506", "Walter Jhamil", "Segovia", "Arellano", "11-02-1996", Carrera.CienciasComputacion);

            // Validar si se obtuvo un diploma válido
            if (diploma.getMensaje().isEmpty()) {
                System.out.println("✅ Diploma emitido con éxito:");
                System.out.println(diploma.toString());
            } else {
                System.out.println("❌ " + diploma.getMensaje());
            }

        } catch (NotBoundException ex) {
            System.out.println("Error: No se pudo encontrar el servicio de la Universidad en el servidor RMI.");
            Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
        } catch (MalformedURLException ex) {
            System.out.println("Error: La URL del servidor RMI es incorrecta.");
            Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
        } catch (RemoteException ex) {
            System.out.println("Error: Fallo en la comunicacion con el servidor RMI.");
            Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
