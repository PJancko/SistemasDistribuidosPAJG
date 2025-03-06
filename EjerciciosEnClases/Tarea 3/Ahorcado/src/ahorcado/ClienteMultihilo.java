/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ahorcado;

import java.io.*;
import java.net.*;
import java.util.Scanner;

/**
 *
 * @author janck
 */
public class ClienteMultihilo {

    public static void main(String[] args) throws IOException {
        Scanner scanner = new Scanner(System.in);

        // Conectarse al servidor
        InetAddress ip = InetAddress.getByName("localhost");
        Socket socket = new Socket(ip, 5056);

        // Establecer flujos de entrada y salida
        DataInputStream dis = new DataInputStream(socket.getInputStream());
        DataOutputStream dos = new DataOutputStream(socket.getOutputStream());

        try {
            String mensajeRecibido;
            // Leer el primer mensaje de bienvenida y el segundo mensaje del estado del juego
            mensajeRecibido = dis.readUTF();
            System.out.println(mensajeRecibido);  // Bienvenida
            mensajeRecibido = dis.readUTF();
            System.out.println(mensajeRecibido);  // Palabra e intentos restantes
            while (true) {
                // Solicitar una letra al jugador
                System.out.print("Ingresa una letra: ");
                String letra = scanner.nextLine();

                // Enviar la letra al servidor
                dos.writeUTF(letra);
                // Leer el mensaje del servidor
                mensajeRecibido = dis.readUTF();
                System.out.println(mensajeRecibido);

                // Si el juego terminó, salir del bucle
                if (mensajeRecibido.contains("Ganaste") || mensajeRecibido.contains("Perdiste")) {
                    break;
                }
                
            }
        } catch (EOFException e) {
            // El servidor cerró la conexión
            System.out.println("El servidor ha cerrado la conexión.");
        } catch (SocketException e) {
            // El servidor cerró la conexión abruptamente
            System.out.println("El servidor ha cerrado la conexión abruptamente.");
        } catch (IOException e) {
            System.out.println("Error de comunicación con el servidor.");
            e.printStackTrace();
        } finally {
            // Cerrar recursos
            dis.close();
            dos.close();
            socket.close();
            scanner.close();
        }
    }
}
