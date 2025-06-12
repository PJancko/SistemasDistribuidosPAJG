/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ejercicio1;

import java.io.*;
import java.net.*;
import java.util.Scanner;

/**
 *
 * @author janck
 */
public class Cliente {
    public static void main(String[] args) {
        String host = "localhost";
        int puerto = 5056;

        try (
            Socket socket = new Socket(host, puerto);
            BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
            Scanner scanner = new Scanner(System.in);
        ) {
            String respuesta;
            while (true) {
                System.out.print("Ingresa un número (0 para terminar): ");
                int numero = scanner.nextInt();
                out.println(numero);

                respuesta = in.readLine();
                System.out.println("Servidor: " + respuesta);

                if (numero == 0) break;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
