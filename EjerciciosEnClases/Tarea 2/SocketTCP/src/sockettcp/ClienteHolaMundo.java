/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package sockettcp;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.Socket;
import java.util.Scanner;

/**
 *
 * @author janck
 */
public class ClienteHolaMundo {
    public static void main(String[] Args){
        
        int port = 5555;
        Scanner sc = new Scanner(System.in);
        
        try {
            Socket client = new Socket("localhost", port);
            PrintStream toServer = new PrintStream(client.getOutputStream());
            BufferedReader fromServer = new BufferedReader(
                    new InputStreamReader(client.getInputStream()));
            //toServer.println("Hola Mundo desde el Cliente");
            System.out.println("Introduzca una palabra");
            String palabra = sc.nextLine();
            toServer.println(palabra);
            String result = fromServer.readLine();
            System.out.println("cadena devuelta por el servidor es: " + result);
        } catch (IOException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
