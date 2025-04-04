/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pagosruat;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.MalformedURLException;
import java.net.ServerSocket;
import java.net.Socket;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author janck
 */
public class ServidorBanco {

    public static void main(String[] args) {

        //Servidor Banco (TCP) y (RMI)
        try {
            //TCP
            int puerto = 5002;
            ServerSocket server = new ServerSocket(puerto);
            String respuesta = "";

            //RMI
            IRuat ruat;
            ruat = (IRuat) Naming.lookup("rmi://localhost/Ruat");

            while (true) {
                // TODO code application logic here

                Socket client;
                PrintStream toClient;
                client = server.accept(); //conexion entre cliente y servidor para comunicacion bidireccional

                BufferedReader fromClient = new BufferedReader(new InputStreamReader(client.getInputStream())); // el lector
                System.out.println("Cliente se conecto");

                String operacion = fromClient.readLine();
                System.out.println("Mensaje recibido del cliente " + operacion);

                if (operacion.startsWith("Deuda:")) {
                    ArrayList<Deuda> deudas = new ArrayList();
                    String ci = operacion.substring(7);
                    deudas = ruat.buscar(ci);
                    respuesta = "Deudas:";
                    for (Deuda deuda : deudas) {
                        respuesta = respuesta + deuda.getAnio() + "," + deuda.getImpuesto() + "," + deuda.getMonto();
                        respuesta += ";";
                    }

                } else if (operacion.startsWith("Pagar:")) {
                    String[] datos = operacion.substring(7).split(",");
                    String ci = datos[0];
                    int anio = Integer.parseInt(datos[1]);
                    String imp = datos[2];
                    Impuesto impuesto;
                    if (imp.equals(Impuesto.inmueble)) {
                        impuesto = Impuesto.inmueble;
                    } else {
                        impuesto = Impuesto.vehiculo;
                    }
                    double monto = Double.parseDouble(datos[3]);
                    Deuda deuda = new Deuda(ci, anio, impuesto, monto);
                    boolean res = ruat.pagar(deuda);
                    if(res){
                        respuesta = "transaccion:true";
                    }else{
                        respuesta = "transaccion:false";
                    }

                }
                toClient = new PrintStream(client.getOutputStream());
                toClient.println("respuesta:" + respuesta);
            }

        } catch (IOException ex) {
            Logger.getLogger(ServidorBanco.class.getName()).log(Level.SEVERE, null, ex);
        } catch (NotBoundException ex) {
            Logger.getLogger(ServidorBanco.class.getName()).log(Level.SEVERE, null, ex);
        }

    }
}
