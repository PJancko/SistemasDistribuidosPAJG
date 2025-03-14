/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package rmi;

import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author janck
 */
public class Ruat extends UnicastRemoteObject implements IRuat {

    ArrayList<Deuda> deudas;
    IAlcaldia alcaldia;

    public Ruat() throws RemoteException {
        super();
        try {

            alcaldia = (IAlcaldia) Naming.lookup("rmi://localhost/Alcaldia");
            this.deudas = new ArrayList<>();
            this.deudas.add(new Deuda("1234567", 2022, Impuesto.vehiculo, 2451));
            this.deudas.add(new Deuda("1234567", 2022, Impuesto.inmueble, 2500));
            this.deudas.add(new Deuda("555587", 2021, Impuesto.vehiculo, 5000));
            this.deudas.add(new Deuda("333357", 2023, Impuesto.inmueble, 24547));

        } catch (NotBoundException ex) {
            Logger.getLogger(Banco.class.getName()).log(Level.SEVERE, null, ex);
        } catch (MalformedURLException ex) {
            Logger.getLogger(Banco.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public ArrayList<Deuda> Buscar(String ci) throws RemoteException {
        ArrayList<Deuda> deu = new ArrayList<>();
        for (Deuda d : this.deudas) {
            if (d.getCi().equals(ci)) {
                deu.add(d);
            }
        }
        return deu;
    }

    @Override
    public boolean Pagar(Deuda deuda) throws RemoteException {
        boolean tieneObservaciones = alcaldia.BuscarObservaciones(deuda.getCi());
        if (tieneObservaciones) {
            return false;
        }
        boolean deudaEliminada = this.deudas.remove(deuda);
        return deudaEliminada;
    }

}
