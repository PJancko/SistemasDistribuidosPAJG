/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ahorcado;

/**
 *
 * @author janck
 */
public class JuegoAhorcado {

    private String palabra;
    private String palabraMostrada;
    private int intentosRestantes;
    private boolean juegoTerminado;

    public JuegoAhorcado() {
        this.palabra = "distribuidos";
        this.palabraMostrada = "_".repeat(palabra.length());
        this.intentosRestantes = 7; // Permitir 7 errores
        this.juegoTerminado = false;
    }

    public void adivinarLetra(char letra) {
        if (palabra.contains(String.valueOf(letra))) {
            StringBuilder sb = new StringBuilder(palabraMostrada);
            for (int i = 0; i < palabra.length(); i++) {
                if (palabra.charAt(i) == letra) {
                    sb.setCharAt(i, letra);  // Si la letra es correcta, la reemplazamos
                }
            }
            palabraMostrada = sb.toString();
        } else {
            intentosRestantes--;  // Si la letra es incorrecta, restamos un intento
        }
        verificarJuegoTerminado();
    }
    

    private void verificarJuegoTerminado() {
        if (palabraMostrada.equals(palabra)) {
            juegoTerminado = true;  // El jugador ha ganado
        } else if (intentosRestantes == 0) {
            juegoTerminado = true;  // El jugador ha perdido
        }
    }

    // Métodos getters
    public String getPalabraMostrada() {
        return palabraMostrada;
    }

    public int getIntentosRestantes() {
        return intentosRestantes;
    }

    public String getPalabra() {
        return palabra;
    }

    public boolean isJuegoTerminado() {
        return juegoTerminado;
    }
}
