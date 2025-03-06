/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package soquetstcp;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author janck
 */
public class ClientHandler extends Thread {

    Operaciones op = new Operaciones();
    final DataInputStream dis;
    final DataOutputStream dos;
    final Socket s;

    // Constructor
    public ClientHandler(Socket s, DataInputStream dis, DataOutputStream dos) {
        this.s = s;
        this.dis = dis;
        this.dos = dos;
    }

    @Override
    public void run() {
        while (true) {
            try {

                // Ask user what he wants
                dos.writeUTF("Menú de Operaciones:\n"
                        + "1. Calcular Fibonacci\n"
                        + "2. Calcular Factorial\n"
                        + "3. Calcular Sumatoria\n"
                        + "4. Salir\n"
                        + "Ingrese su opción:");
                // receive the answer from client
                int opcion = dis.readInt();

                if (opcion == 4) {
                    System.out.println("Client " + this.s + " sends exit...");
                    System.out.println("Closing this connection.");
                    this.s.close();
                    System.out.println("Connection closed");
                    break;
                }
                dos.writeUTF("Ingrese un numero");
                int n = dis.readInt();
                // write on output stream based on the
                // answer from the client
                
                int resultadoInt = 0;
                
                switch (opcion) {

                    case 1:
                        resultadoInt = op.calcularFibonacci(n);
                        dos.writeInt(resultadoInt);
                        break;

                    case 2:
                        resultadoInt = op.calcularFactorial(n);
                        dos.writeInt(resultadoInt);
                        break;

                    case 3:
                        resultadoInt = op.calcularSumatoria(n);
                        dos.writeInt(resultadoInt);
                        break;
                        
                    default:
                        dos.writeUTF("Invalid input");
                        break;
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        try {
            // closing resources
            this.dis.close();
            this.dos.close();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    
}
