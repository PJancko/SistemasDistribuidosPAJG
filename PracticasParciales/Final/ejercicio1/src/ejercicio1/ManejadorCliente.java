/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ejercicio1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

/**
 *
 * @author janck
 */
public class ManejadorCliente implements Runnable {
    private Socket socket;

        public ManejadorCliente(Socket socket) {
            this.socket = socket;
        }

        @Override
        public void run() {
            int acumulado = 0;
            int contador = 0;

            try (
                BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
            ) {
                String input;
                while ((input = in.readLine()) != null) {
                    int numero = Integer.parseInt(input);
                    if (numero == 0) {
                        out.println("Cantidad de veces: " + contador + ", Acumulado: " + acumulado);
                        break;
                    } else {
                        acumulado += numero;
                        contador++;
                        out.println("Acumulado: " + acumulado);
                    }
                }
            } catch (IOException | NumberFormatException e) {
                System.out.println("Error con cliente: " + e.getMessage());
            } finally {
                try {
                    socket.close();
                } catch (IOException e) { }
            }
        }
}
