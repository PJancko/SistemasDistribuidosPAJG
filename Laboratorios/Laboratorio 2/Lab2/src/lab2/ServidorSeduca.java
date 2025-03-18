/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package lab2;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author janck
 */
public class ServidorSeduca {
    public static void main(String[] args){
            int port = 5002;
        ServerSocket server;
        String rude="";
        String mensaje="";
        
        try {
            server = new ServerSocket(port);
            System.out.println("Se inicio el servidor con éxito");
            while (true) {
                // TODO code application logic here

                Socket client;
                PrintStream toClient;
                client = server.accept(); //conexion entre cliente y servidor para comunicacion bidireccional

                BufferedReader fromClient = new BufferedReader(new InputStreamReader(client.getInputStream())); // el lector
                System.out.println("Cliente se conecto");
                String operacion = fromClient.readLine(); //'verificar-rude'
                String[] comandos=operacion.split("-");
                rude=comandos[1];
                ///logica para ver si tiene titulo de bachiler
                
                System.out.println("Mensaje enviado "+operacion);
                
                
                toClient = new PrintStream(client.getOutputStream());
                toClient.println("respuesta:"+mensaje);
            }
        } catch (IOException ex) {
            System.out.print(ex.getMessage());
        }
    }
}
