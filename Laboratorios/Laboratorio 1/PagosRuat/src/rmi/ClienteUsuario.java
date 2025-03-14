/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package rmi;

import java.rmi.Naming;
import java.util.ArrayList;
import java.util.Scanner;

/**
 *
 * @author janck
 */
public class ClienteUsuario {

    public static void main(String[] args) {
        try {
            IBanco banco = (IBanco) Naming.lookup("rmi://localhost/Banco");
            Scanner scanner = new Scanner(System.in);

            while (true) {
                System.out.println("\nSistema de Pagos RUAT");
                System.out.println("1. Consultar deudas");
                System.out.println("2. Pagar deuda");
                System.out.println("3. Salir");
                System.out.print("Seleccione una opción: ");
                int opcion = scanner.nextInt();

                switch (opcion) {
                    case 1: // Consultar deudas
                        System.out.print("Ingrese su CI: ");
                        String ci = scanner.next();
                        ArrayList<Deuda> deudas = banco.ObtenerDeuda(ci);

                        if (deudas.isEmpty()) {
                            System.out.println("No tienes deudas registradas.");
                        } else {
                            System.out.println("=== Deudas Encontradas ===");
                            for (int i = 0; i < deudas.size(); i++) {
                                System.out.println((i + 1) + ". " + deudas.get(i));
                            }
                        }
                        break;

                    case 2: // Pagar deuda
                        System.out.print("Ingrese su CI: ");
                        String ciPago = scanner.next();
                        ArrayList<Deuda> deudasPago = banco.ObtenerDeuda(ciPago);

                        if (deudasPago.isEmpty()) {
                            System.out.println("No tienes deudas registradas.");
                        } else {
                            System.out.println("=== Deudas Encontradas ===");
                            for (int i = 0; i < deudasPago.size(); i++) {
                                System.out.println((i + 1) + ". " + deudasPago.get(i));
                            }

                            System.out.print("Seleccione el número de la deuda a pagar: ");
                            int indice = scanner.nextInt() - 1;

                            if (indice >= 0 && indice < deudasPago.size()) {
                                boolean resultado = banco.Pagar(deudasPago.get(indice));
                                if (resultado) {
                                    System.out.println("Pago realizado con exito.");
                                } else {
                                    System.out.println("No se pudo procesar el pago (posible observacion en Alcaldia).");
                                }
                            } else {
                                System.out.println("Número inválido.");
                            }
                        }
                        break;

                    case 3: // Salir
                        System.out.println("Saliendo del sistema...");
                        break;

                    default: // Opción inválida
                        System.out.println("Opción inválida.");
                        break;
                }
                if(opcion == 3){
                    break;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

    }
}
