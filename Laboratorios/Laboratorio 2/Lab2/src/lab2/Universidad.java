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
        String fechaSinGuiones = fecha_nacimiento.replace("-", "");
        String rude = nombres.substring(0, 2) + primerApellido.substring(0, 2) + segundoApellido.substring(0, 2) + fechaSinGuiones;
        boolean datosCorrectos = false;

        //Llamar a Segip(codigo del cliente RMI)
        try {

            ISegip segip;
            segip = (ISegip) Naming.lookup("rmi://localhost/Segip");

            Respuesta respuestaSegip = segip.Verificar(ci, nombres, primerApellido, segundoApellido);

            // Comprobar si los datos son correctos o no
            if (!respuestaSegip.isEstado()) {
                return new Diploma("", null, "", "Los Datos del CI no son correctos");
            } else {
                System.out.println("SEGIP: " + respuestaSegip.getMensaje());
                datosCorrectos = true;
            }
            
        } catch (Exception e) {
            System.out.println("Error al conectar con SEGIP: " + e.getMessage());
        }

        //Llamar a Seduca(codigo del cliente TCP)
        boolean esBachiller = false;
        try {
            int port = 5002;
            Socket client;
            client = new Socket("localhost", port);
            PrintStream toServer = new PrintStream(client.getOutputStream());
            BufferedReader fromServer = new BufferedReader(
                    new InputStreamReader(client.getInputStream()));
            toServer.println("verificar-" + rude);
            String result = fromServer.readLine();

            System.out.println("Respuesta de seduca: " + result);

            // Procesar la respuesta
            String[] respuesta = result.split(":");
            if (respuesta.length >= 3 && respuesta[1].equals("si")) {
                esBachiller = true;
            } else {
                esBachiller = false;
            }
            String mensajeSeduca = respuesta.length >= 3 ? respuesta[2] : "Error en la respuesta de Seduca";

            if (esBachiller) {
                System.out.println("Bachiller verificado: " + mensajeSeduca);
            } else {
                System.out.println("No es bachiller: " + mensajeSeduca);
                return new Diploma("", null, "", mensajeSeduca);
            }

        } catch (IOException ex) {
            Logger.getLogger(Universidad.class.getName()).log(Level.SEVERE, null, ex);
        }

        // Llamar a Sereci (código del cliente UDP)
        int puerto = 6789;
        String dato = "Ver-fecha:" + nombres + "," + primerApellido + " " + segundoApellido + "," + fecha_nacimiento;
        boolean fechaCorrecta = false;

        try {
            String ip = "localhost";
            DatagramSocket socketUDP = new DatagramSocket();
            byte[] mensaje = dato.getBytes();
            InetAddress hostServidor = InetAddress.getByName(ip);

            // Construimos un datagrama para enviar el mensaje al servidor
            DatagramPacket peticion = new DatagramPacket(mensaje, mensaje.length, hostServidor, puerto);

            // Enviamos el datagrama
            socketUDP.send(peticion);

            // Construimos el DatagramPacket que contendrá la respuesta
            byte[] buffer = new byte[1000];
            DatagramPacket respuesta = new DatagramPacket(buffer, buffer.length);

            // Recibimos la respuesta del servidor
            socketUDP.receive(respuesta);
            String resultado = new String(respuesta.getData(), 0, respuesta.getLength()).trim();

            // Imprimimos la respuesta
            System.out.println("Respuesta de SERECI: " + resultado);

            if (resultado.equals("si:verificación correcta")) {
                fechaCorrecta = true;
            } else {
                return new Diploma("", null, "", "Error: fecha de nacimiento no coincide con el registro de SERECI");
            }

            // Cerramos el socket
            socketUDP.close();

        } catch (SocketException e) {
            System.out.println("Socket: " + e.getMessage());
        } catch (IOException e) {
            System.out.println("IO: " + e.getMessage());
        }

        emitir = datosCorrectos && fechaCorrecta && esBachiller;

        // Si todas las verificaciones pasaron, se emite el diploma
        if (emitir) {
            diplomaAux = new Diploma(ci, carrera, rude, "");
        } else {
            return new Diploma("", null, "", "No se pudo emitir el diploma");
        }

        return diplomaAux;
    }

}
