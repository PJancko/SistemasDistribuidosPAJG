/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package statesynccluster;

import org.jgroups.JChannel;
import org.jgroups.Message;
import org.jgroups.ReceiverAdapter;
import org.jgroups.View;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class SistemaVotacion extends ReceiverAdapter {

    private JChannel canal;
    private List<String> opciones = new ArrayList<>();
    private List<Integer> votos = new ArrayList<>();
    private boolean esIniciador = false;

    public void start() throws Exception {
        canal = new JChannel();
        canal.setReceiver(this);
        canal.connect("GrupoVotacion");
        System.out.println("Conectado al grupo 'GrupoVotacion'");

        BufferedReader lector = new BufferedReader(new InputStreamReader(System.in));
        System.out.println("¿Eres el iniciador de la votacion? (s/n): ");
        String respuesta = lector.readLine().trim().toLowerCase();

        if (respuesta.equals("s")) {
            esIniciador = true;
            iniciarVotacion(lector);
        } else {
            esperarVotos(lector);
        }
    }

    private void iniciarVotacion(BufferedReader lector) throws Exception {
        System.out.println("Introduce la pregunta de la votacion:");
        String pregunta = lector.readLine();
        System.out.println("Introduce las opciones separadas por comas:");
        String[] opcionesIngresadas = lector.readLine().split(",");

        for (String opcion : opcionesIngresadas) {
            opciones.add(opcion.trim());
            votos.add(0);
        }

        String mensaje = "VOTACION:" + pregunta + ":" + String.join(",", opciones);
        canal.send(new Message(null, mensaje));

        // Solo los participantes (no el iniciador) esperan votos
        if (!esIniciador) {
            esperarVotos(lector);
        }
    }

    private void esperarVotos(BufferedReader lector) throws Exception {
        while (true) {
            System.out.println("Opciones disponibles: " + opciones);
            System.out.println("Escribe tu voto:");
            String voto = lector.readLine().trim();

            int indice = opciones.indexOf(voto);
            if (indice != -1) {
                canal.send(new Message(null, "VOTO_EMITIDO:" + voto));
            } else {
                System.out.println("Opción no válida. Inténtalo de nuevo.");
            }
        }
    }

    @Override
    public void receive(Message msg) {
        String contenido = msg.getObject().toString();

        if (contenido.startsWith("VOTACION:")) {
            String[] partes = contenido.split(":");
            System.out.println("Nueva votación: " + partes[1]);
            System.out.println("Opciones: " + partes[2]);
            String[] opcionesRecibidas = partes[2].split(",");

            for (String opcion : opcionesRecibidas) {
                opciones.add(opcion.trim());
                votos.add(0);
            }
        } else if (contenido.startsWith("VOTO_EMITIDO:")) {
            String voto = contenido.split(":")[1];
            int indice = opciones.indexOf(voto);
            if (indice != -1) {
                votos.set(indice, votos.get(indice) + 1);
                System.out.println("Voto recibido: " + voto);
                mostrarResultados();
            }
        }
    }

    private void mostrarResultados() {
        System.out.println("Resultados actuales:");
        for (int i = 0; i < opciones.size(); i++) {
            System.out.println(opciones.get(i) + ": " + votos.get(i) + " votos");
        }
    }

    @Override
    public void viewAccepted(View vista) {
        System.out.println("Nuevos miembros en el grupo: " + vista.getMembers());
    }

    public static void main(String[] args) {
        try {
            new SistemaVotacion().start();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
