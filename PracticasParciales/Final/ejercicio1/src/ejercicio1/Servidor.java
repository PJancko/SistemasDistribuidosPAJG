/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ejercicio1;

import java.io.*;
import java.net.*;
import java.util.concurrent.*;

/**
 *
 * @author janck
 */
public class Servidor {
    public static void main(String[] args){
        int puerto = 5056;
        ExecutorService pool = Executors.newCachedThreadPool();

        try (ServerSocket serverSocket = new ServerSocket(puerto)) {
            System.out.println("Servidor iniciado en el puerto " + puerto);

            while (true) {
                Socket cliente = serverSocket.accept();
                pool.execute(new ManejadorCliente(cliente));
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
