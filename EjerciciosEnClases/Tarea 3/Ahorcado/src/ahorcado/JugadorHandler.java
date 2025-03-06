/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ahorcado;

import java.io.*;
import java.net.*;

/**
 *
 * @author janck
 */
public class JugadorHandler extends Thread {

    private Socket socket;
    private DataInputStream dis;
    private DataOutputStream dos;
    private JuegoAhorcado juego;

    public JugadorHandler(Socket socket) throws IOException {
        this.socket = socket;
        this.dis = new DataInputStream(socket.getInputStream());
        this.dos = new DataOutputStream(socket.getOutputStream());
        this.juego = new JuegoAhorcado();  // Creamos una instancia del juego para este jugador
    }

    @Override
    public void run() {
        try {
            dos.writeUTF("Bienvenido al Ahorcado! Adivina la palabra.");
            while (!juego.isJuegoTerminado()) {
                // Enviar estado del juego en un solo mensaje
                dos.writeUTF(
                        "Palabra: " + juego.getPalabraMostrada()
                        + "\nIntentos restantes: " + juego.getIntentosRestantes()
                );

                // Leer la letra del cliente
                String letra = dis.readUTF().toLowerCase();

                // Validar la letra
                if (letra.length() != 1 || !Character.isLetter(letra.charAt(0))) {
                    dos.writeUTF("Error: Ingresa una letra válida.");
                    continue;
                }

                // Procesar la letra
                juego.adivinarLetra(letra.charAt(0));
                

                // Verificar si el juego terminó
                if (juego.isJuegoTerminado()) {
                    if (juego.getPalabraMostrada().equals(juego.getPalabra())) {
                        dos.writeUTF("¡Ganaste! La palabra era: " + juego.getPalabra());
                    } else {
                        dos.writeUTF("Perdiste. La palabra era: " + juego.getPalabra());
                    }
                    break; // Salir del bucle una vez que el juego ha terminado
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                // Cerrar recursos
                dis.close();
                dos.close();
                socket.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

}
