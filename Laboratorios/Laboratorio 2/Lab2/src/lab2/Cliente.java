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
            universidad = (IUniversidad) Naming.lookup("rmi://localhost/Universidad");
            diploma = universidad.EmitirDiploma("1140506", "Walter Jhamil", "Segovia", "Arellano", "11-02-1996", Carrera.CienciasComputacion);
            if(diploma.getMensaje().equals("")){
                System.out.println(diploma);
            }
        } catch (NotBoundException ex) {
            Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
        } catch (MalformedURLException ex) {
            Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
        } catch (RemoteException ex) {
            Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
