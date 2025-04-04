/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pagosruat;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author janck
 */
public class ClienteUsuario {

    public static void main(String[] args) {
        try {
            String paquete;
            String result;
            Scanner scanner = new Scanner(System.in);
            ArrayList<Deuda> deudas = new ArrayList();
            int port = 5002;
            Socket client;
            client = new Socket("localhost", port);
            PrintStream toServer = new PrintStream(client.getOutputStream());
            BufferedReader fromServer = new BufferedReader(
                    new InputStreamReader(client.getInputStream()));

            while (true) {
                System.out.println("\nSistema de Pagos RUAT");
                System.out.println("1. Consultar deudas");
                System.out.println("2. Pagar deuda");
                System.out.println("3. Salir");
                System.out.print("Seleccione una opción: ");
                int opcion = scanner.nextInt();
                switch (opcion) {
                    case 1:
                        System.out.print("Ingrese su CI: ");
                        String ci = scanner.next();

                        paquete = "Deuda:" + ci;
                        toServer.println(paquete);
                        result = fromServer.readLine();

                        
                        if (result.isEmpty()) {
                            System.out.println("No tienes deudas registradas.");
                        } else {
                            System.out.println("=== Deudas Encontradas ===");
                            if (result.startsWith("Deudas:")) {
                                String[] datos = result.substring(7).split(",");
                                for (int i = 0; i < datos.length; i++) {
                                    int anio = Integer.parseInt(datos[i]);
                                    String imp = datos[i + 1];
                                    Impuesto impuesto;
                                    if (imp.equals(Impuesto.inmueble)) {
                                        impuesto = Impuesto.inmueble;
                                    } else {
                                        impuesto = Impuesto.vehiculo;
                                    }
                                    double monto = Double.parseDouble(datos[i + 2]);

                                    deudas.add(new Deuda(ci, anio, impuesto, monto));
                                }
                            }

                        }

                        System.out.println("Deudas encontradas:");
                        for (int i = 0; i < deudas.size(); i++) {
                            System.out.println(i + ". " + "CI: " + deudas.get(i).getCi() + "-" + "Monto: " + deudas.get(i).getMonto());
                        }
                        break;
                    case 2:
                        System.out.print("Ingrese que cuenta desea pagar: ");
                        int op = scanner.nextInt();

                        paquete = "Pagar:" +deudas.get(op).getCi()+","+deudas.get(op).getAnio()+","+deudas.get(op).getImpuesto()+","+deudas.get(op).getMonto();
                        toServer.println(paquete);
                        result = fromServer.readLine();

                        if (result.isEmpty()) {
                            System.out.println("No existe esa opcion.");
                        } else {
                            if(result.startsWith("transaccion:")){
                                String[] datos = result.substring(12).split(",");
                                if(datos[1] == "true"){
                                    System.out.println("Pago realizado con exito");
                                }else{
                                    System.out.println("No se puedo realizar el pago");
                                }
                            }
                        }
                        break;
                }
            }
        } catch (IOException ex) {
            Logger.getLogger(ClienteUsuario.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
