/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package sockettcp;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.ServerSocket;
import java.net.Socket;

/**
 *
 * @author janck
 */
public class ServerHolaMundo {
    public static void main(String[] Args){
        int port = 5555;
        ServerSocket server;
        try {
            // TODO code application logic here
            server = new ServerSocket(port);
            System.out.println("Se inicio el servidor con éxito");
            Socket client;
            PrintStream toClient;
            client = server.accept(); //conexion entre cliente y servidor para comunicacion bidireccional
            BufferedReader fromClient = new BufferedReader(new InputStreamReader(client.getInputStream())); // el lector
            System.out.println("Cliente se conecto");
            String recibido = fromClient.readLine();
            String reverseString = reverseInputString(recibido);
            System.out.println("El cliente envio el mensaje:"+recibido);
            toClient = new PrintStream(client.getOutputStream());
            toClient.println(reverseString);
        } catch (IOException ex) {
            System.out.print(ex.getMessage());
        }
    }

    private static String reverseInputString(String recibido) {
        if(recibido == null)
            return recibido;
        String reverseString = "";
        for(int i = recibido.length() - 1; i >= 0; i--){
            reverseString = reverseString + recibido.charAt(i);
        }
        return reverseString;
    }
}
