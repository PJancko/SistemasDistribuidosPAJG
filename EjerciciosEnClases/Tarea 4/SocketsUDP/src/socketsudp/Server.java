/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package socketsudp;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.SocketException;

/**
 *
 * @author Dell
 */
public class Server {

    public static void main(String[] Args) {
        int port = 6789;
        int n = 0;
        Operaciones operaciones = new Operaciones();
        
        try {

            DatagramSocket socketUDP = new DatagramSocket(port);
            byte[] bufer = new byte[1000];

            while (true) {
                // Construimos el DatagramPacket para recibir peticiones
                DatagramPacket peticion
                        = new DatagramPacket(bufer, bufer.length);

                // Leemos una petición del DatagramSocket
                socketUDP.receive(peticion);

                System.out.print("Datagrama recibido del host: "
                        + peticion.getAddress());
                System.out.println(" desde enl puerto remoto: "
                        + peticion.getPort());

                String cadena = String.valueOf(peticion.getData()).trim();
                System.out.println(" valor recibido: " + cadena);
                String[] partes = cadena.split("-");
                // Construimos el DatagramPacket para enviar la respuesta
                String accion = partes[0];
                String response = "";
                System.out.println(" Accion: " + accion);
                System.out.println(" Response antes del switch: " + response);
                switch(accion){
                    case "SetN":
                        n = Integer.parseInt(partes[1]);
                        response = "Valor n de actualizado a " + partes[1];
                        break;
                    case "Factorial":
                        response = String.valueOf(operaciones.calcularFactorial(n));
                        break;
                    case "Fibonacci":
                        response = String.valueOf(operaciones.calcularFibonacci(n));
                        break;
                    case "Sumatoria":
                        response = String.valueOf(operaciones.calcularSumatoria(n));
                        break;
                }
                System.out.println(" Response despues del switch: " + response);
                byte[] mensaje = response.getBytes();

                DatagramPacket respuesta
                        = new DatagramPacket(mensaje, response.length(),
                                peticion.getAddress(), peticion.getPort());

                // Enviamos la respuesta, que es un eco
                socketUDP.send(respuesta);
            }

        } catch (SocketException e) {
            System.out.println("Socket: " + e.getMessage());
        } catch (IOException e) {
            System.out.println("IO: " + e.getMessage());
        }

    }

}
