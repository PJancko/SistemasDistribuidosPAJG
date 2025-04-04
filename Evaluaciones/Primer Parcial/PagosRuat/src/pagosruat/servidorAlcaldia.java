/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pagosruat;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.SocketException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author janck
 */
public class servidorAlcaldia {

    public static void main(String[] args) {
        try {
            DatagramSocket socketUDP = new DatagramSocket(6789);
            byte[] buffer = new byte[1000];
            System.out.println("Servidor Alcaldia iniciado en el puerto " + 6789);

            while (true) {
                // Construimos el DatagramPacket para recibir peticiones
                DatagramPacket peticion = new DatagramPacket(buffer, buffer.length);

                // Leemos una petición del DatagramSocket
                socketUDP.receive(peticion);

                // Convertimos los datos recibidos a String
                String cadena = new String(peticion.getData(), 0, peticion.getLength()).trim();
                System.out.println("Solicitud recibida: " + cadena);
                String response = "";
                
                if(cadena.startsWith("consulta:")){
                    String dato = cadena.substring(9);
                    if("1234567".equals(dato)){
                        response = "respuesta:true";
                    }else{
                        response = "respuesta:false";
                    }
                }

                // Convertimos la respuesta a bytes
                byte[] mensaje = response.getBytes();

                // Construimos el DatagramPacket para enviar la respuesta
                DatagramPacket respuesta = new DatagramPacket(mensaje, mensaje.length,
                        peticion.getAddress(), peticion.getPort());

                // Enviamos la respuesta
                socketUDP.send(respuesta);
            }

        } catch (SocketException ex) {
            Logger.getLogger(servidorAlcaldia.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(servidorAlcaldia.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
