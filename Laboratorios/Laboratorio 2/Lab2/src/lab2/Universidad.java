/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package lab2;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.MalformedURLException;
import java.net.Socket;
import java.net.SocketException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author janck
 */
public class Universidad extends UnicastRemoteObject implements IUniversidad {

    public Universidad() throws RemoteException {
        super();
    }

    @Override
    public Diploma EmitirDiploma(String ci, String nombres, String primerApellido, String segundoApellido, String fecha_nacimiento, Carrera carrera) throws RemoteException {
        
        Diploma diplomaAux = null;
        boolean emitir = false;
        String rude = nombres.substring(0, 2) + primerApellido.substring(0, 2) + segundoApellido.substring(0, 2) + fecha_nacimiento;
        
        
        
        //Llamar a Segip(codigo del cliente RMI)
        try {
            
            ISegip segip;
            segip = (ISegip) Naming.lookup("rmi://localhost/Segip");

        } catch (NotBoundException ex) {
            Logger.getLogger(Universidad.class.getName()).log(Level.SEVERE, null, ex);
        } catch (MalformedURLException ex) {
            Logger.getLogger(Universidad.class.getName()).log(Level.SEVERE, null, ex);
        }

        
        
        
        //Llamar a Seduca(codigo del cliente TCP)
        try {
            int port = 5002;
            Socket client;
            client = new Socket("localhost", port);
            PrintStream toServer = new PrintStream(client.getOutputStream());
            BufferedReader fromServer = new BufferedReader(
                    new InputStreamReader(client.getInputStream()));
            toServer.println("verificar-" + rude);
            String result = fromServer.readLine();
        } catch (IOException ex) {
            Logger.getLogger(Universidad.class.getName()).log(Level.SEVERE, null, ex);
        }

        
        
        
        //Llamar a Sereci(codigo del cliente UDP)
        int puerto = 6789;
        String dato = "";
        while (true) {
            try {

                String ip = "localhost";

                DatagramSocket socketUDP = new DatagramSocket();
                byte[] mensaje = dato.getBytes();
                InetAddress hostServidor = InetAddress.getByName(ip);

                // Construimos un datagrama para enviar el mensaje al servidor
                DatagramPacket peticion
                        = new DatagramPacket(mensaje, dato.length(), hostServidor,
                                puerto);

                // Enviamos el datagrama
                socketUDP.send(peticion);

                // Construimos el DatagramPacket que contendrá la respuesta
                byte[] bufer = new byte[1000];
                DatagramPacket respuesta
                        = new DatagramPacket(bufer, bufer.length);
                socketUDP.receive(respuesta);

                // Enviamos la respuesta del servidor a la salida estandar
                System.out.println("Respuesta: " + new String(respuesta.getData()));

                // Cerramos el socket
                socketUDP.close();

            } catch (SocketException e) {
                System.out.println("Socket: " + e.getMessage());
            } catch (IOException e) {
                System.out.println("IO: " + e.getMessage());
            }
            return diplomaAux;
        }

    }

}
