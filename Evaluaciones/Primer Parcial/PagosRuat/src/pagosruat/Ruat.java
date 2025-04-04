/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pagosruat;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.net.UnknownHostException;
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

    public Ruat() throws RemoteException {
        super();
        this.deudas = new ArrayList<>();
        this.deudas.add(new Deuda("1234567", 2022, Impuesto.vehiculo, 2451));
        this.deudas.add(new Deuda("1234567", 2022, Impuesto.inmueble, 2500));
        this.deudas.add(new Deuda("555587", 2021, Impuesto.vehiculo, 5000));
        this.deudas.add(new Deuda("333357", 2023, Impuesto.inmueble, 24547));
    }

    @Override
    public ArrayList<Deuda> buscar(String ci) throws RemoteException {
        ArrayList<Deuda> deu = new ArrayList<>();
        for (Deuda d : this.deudas) {
            if (d.getCi().equals(ci)) {
                deu.add(d);
            }
        }
        return deu;
    }

    @Override
    public boolean pagar(Deuda deuda) throws RemoteException {

        try {
            DatagramSocket socket = new DatagramSocket();

            InetAddress address = InetAddress.getByName("localhost");
            String consulta = "consulta:" + deuda.getCi();
            byte[] buffer = consulta.getBytes();
            DatagramPacket packet = new DatagramPacket(buffer, buffer.length, address, 6789);
            socket.send(packet);

            
            buffer = new byte[1024];
            packet = new DatagramPacket(buffer, buffer.length);
            socket.receive(packet);
            String resultado = new String(packet.getData(), 0, packet.getLength()).trim();

            System.out.println("Respuesta de Alcaldia: " + resultado);
            if (resultado.startsWith("respuesta:")) {
                String dato = resultado.substring(10);
                if(dato.equals("true")){
                    boolean deudaEliminada = this.deudas.remove(deuda);
                    return deudaEliminada;
                }
            }

        } catch (SocketException ex) {
            Logger.getLogger(Ruat.class.getName()).log(Level.SEVERE, null, ex);
        } catch (UnknownHostException ex) {
            Logger.getLogger(Ruat.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(Ruat.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }

}
