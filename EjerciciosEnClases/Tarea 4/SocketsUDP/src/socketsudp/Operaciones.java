/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package socketsudp;

/**
 *
 * @author janck
 */
public class Operaciones {
    
    public int calcularFibonacci(int n){
        if(n<=1) return n;
        return calcularFibonacci(n-1) + calcularFibonacci(n-2);
    }
    
    public int calcularFactorial(int n){
        int factorial = 1;
        for(int i = 2; i<=n; i++){
            factorial *= i;
        }
        return factorial;
    }
    
    public int calcularSumatoria(int n){
        int sum = 0;
        for(int i = 1; i <= n; i++){
            sum += i;
        }
        return sum;
    }
    
}
