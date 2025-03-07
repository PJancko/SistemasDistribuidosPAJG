/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package socketsudp;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.util.Scanner;

/**
 *
 * @author Dell
 */
public class Cliente {

    public static void main(String[] Args) {
        int puerto = 6789;
        String dato = "";
        Scanner sc = new Scanner(System.in);
        while (true) {
            try {
                System.out.print("Menu");
                System.out.print("\n1. Cambiar el valor de n");
                System.out.print("\n2. Factorial");
                System.out.print("\n3. Fibonacci");
                System.out.print("\n4. Sumatoria");
                System.out.print("\n5. Salir");
                System.out.print("\nIntroduzca una opcion(1-5): ");
                int op = sc.nextInt();
                String ip = "localhost";

                switch (op) {
                    case 1:
                        System.out.print("\nIntroduzca un valor para n: ");
                        int n = sc.nextInt();
                        dato = "SetN-" + String.valueOf(n);
                        break;
                    case 2:
                        dato = "Factorial-";
                        break;
                    case 3:
                        dato = "Fibonacci-";
                        break;
                    case 4:
                        dato = "Sumatoria-";
                        break;
                    case 5:
                        break;
                }
                if(op == 5){
                    break;
                }

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

        }
    }

}
