/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package operacionesrmi;

import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author janck
 */
public class Cliente {

    public static void main(String[] args) {
        IOperaciones operaciones;
        Scanner sc = new Scanner(System.in);
        try {
            operaciones = (IOperaciones) Naming.lookup("rmi://localhost/O");
            while (true) {
                System.out.print("\nMenu");
                System.out.print("\n1. Cambiar el valor de n");
                System.out.print("\n2. Factorial");
                System.out.print("\n3. Fibonacci");
                System.out.print("\n4. Sumatoria");
                System.out.print("\n5. Salir");
                System.out.print("\nIntroduzca una opcion(1-5): ");
                int op = sc.nextInt();
                switch (op) {
                    case 1:
                        System.out.print("\nIntroduzca un valor para n: ");
                        int n = sc.nextInt();
                        operaciones.SetN(n);
                        System.out.println("\nValor de n actualizado");
                        break;
                    case 2:
                        System.out.print(operaciones.calcularFactorial());
                        break;
                    case 3:
                        System.out.print(operaciones.calcularFibonacci());
                        break;
                    case 4:
                        System.out.print(operaciones.calcularSumatoria());
                        break;
                    case 5:
                        break;
                }
                if (op == 5) {
                    break;
                }
            }

        } catch (NotBoundException ex) {
            Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
        } catch (MalformedURLException ex) {
            Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
        } catch (RemoteException ex) {
            Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
