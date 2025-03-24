
import org.jgroups.JChannel;
import org.jgroups.Message;
import org.jgroups.ReceiverAdapter;
import org.jgroups.View;

public class StateSyncCluster {

    private JChannel channel;
    private int state = 0; // Estado inicial (un contador)

    public void start() throws Exception {
        // Crear el canal y unirse al grupo
        channel = new JChannel(); // Usa la configuración por defecto (UDP)
        channel.setReceiver(new ReceiverAdapter() {
            @Override
            public void receive(Message msg) {
                // Manejar mensajes recibidos
                System.out.println("Mensaje recibido: " + msg.getObject());
                System.out.println("Estado: " + state);

            }

            @Override
            public void viewAccepted(View view) {
                // Manejar cambios en la membresía del grupo
                state++;
                System.out.println("Miembros del grupo: " + view.getMembers());
            }
        });
        channel.connect("StateSyncCluster"); // Conectar al grupo
        Message msg = new Message(null, "conectado");
        channel.send(msg);
        System.out.println("Conectado al grupo 'StateSyncCluster'");
    }

    public static void main(String[] args) {
        try {
            StateSyncCluster example = new StateSyncCluster();
            example.start();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
