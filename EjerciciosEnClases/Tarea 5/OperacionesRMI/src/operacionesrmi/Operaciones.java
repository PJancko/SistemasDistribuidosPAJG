/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package operacionesrmi;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

/**
 *
 * @author janck
 */
public class Operaciones extends UnicastRemoteObject implements IOperaciones {
    
    private int n;
    
    public Operaciones() throws RemoteException{
            super();
            this.n = n;
        }

    @Override
    public void SetN(int n) throws RemoteException {
        this.setN(n);
    }

    @Override
    public int calcularFactorial() throws RemoteException {
        int factorial = 1;
        for(int i = 2; i<=n; i++){
            factorial *= i;
        }
        return factorial;
    }

    @Override
    public int calcularSumatoria() throws RemoteException {
        int sum = 0;
        for(int i = 1; i <= n; i++){
            sum += i;
        }
        return sum;
    }

    @Override
    public int calcularFibonacci() throws RemoteException {
        if(n<=1) return n;
        int a = 0, b = 1, resultado = 0;
        for (int i = 2; i <= n; i++) {
            resultado = a + b;
            a = b;
            b = resultado;
        }
        return resultado;
    }

   public void setN(int n) {
        this.n = n;
    }
    
}
