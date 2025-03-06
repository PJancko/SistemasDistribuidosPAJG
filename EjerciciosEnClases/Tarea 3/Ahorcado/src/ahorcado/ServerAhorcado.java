/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ahorcado;

import java.io.*;
import java.net.*;

/**
 *
 * @author janck
 */
public class ServerAhorcado {
    public static void main(String[] args) {
        try (ServerSocket serverSocket = new ServerSocket(5056)) {
            System.out.println("Servidor esperando a jugadores...");
    
            while (true) {
                Socket socket = serverSocket.accept();
                System.out.println("Jugador conectado: " + socket);
    
                // Crear un nuevo hilo para manejar al jugador
                Thread jugadorHandler = new JugadorHandler(socket);
                jugadorHandler.start();  // Inicia el hilo del jugador
            }
        } catch (IOException e) {
            e.printStackTrace();  // Imprimir el error si ocurre algún problema con la conexión del servidor
        }
    }
}

