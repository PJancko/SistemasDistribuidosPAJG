/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package lab2;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.SocketException;

/**
 *
 * @author janck
 */
public class ServidorSereci {

    public static void main(String[] args) {
        int port = 6789;

        try {
            DatagramSocket socketUDP = new DatagramSocket(port);
            byte[] buffer = new byte[1000];

            System.out.println("Servidor SERECI iniciado en el puerto " + port);

            while (true) {
                // Construimos el DatagramPacket para recibir peticiones
                DatagramPacket peticion = new DatagramPacket(buffer, buffer.length);

                // Leemos una petición del DatagramSocket
                socketUDP.receive(peticion);

                // Convertimos los datos recibidos a String
                String cadena = new String(peticion.getData(), 0, peticion.getLength()).trim();
                System.out.println("Solicitud recibida: " + cadena);

                String response;

                // Verificar si los datos son correctos
                if (cadena.equals("Ver-fecha:Walter Jhamil,Segovia Arellano,11-02-1996")) {
                    response = "si:verificación correcta";
                } else {
                    response = "no:error fecha nacimiento no correcta";
                }

                // Convertimos la respuesta a bytes
                byte[] mensaje = response.getBytes();

                // Construimos el DatagramPacket para enviar la respuesta
                DatagramPacket respuesta = new DatagramPacket(mensaje, mensaje.length,
                        peticion.getAddress(), peticion.getPort());

                // Enviamos la respuesta
                socketUDP.send(respuesta);
            }

        } catch (SocketException e) {
            System.out.println("Socket: " + e.getMessage());
        } catch (IOException e) {
            System.out.println("IO: " + e.getMessage());
        }

    }
}
