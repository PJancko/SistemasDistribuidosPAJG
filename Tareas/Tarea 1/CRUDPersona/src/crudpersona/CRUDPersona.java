/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package crudpersona;


/**
 *
 * @author janck
 */
public class CRUDPersona {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        PersonaDAO dao = new PersonaDAO();
        // Insertar una persona
        Persona nuevaPersona0 = new Persona("Pedro new", 45, "pedronew@email.com");
        dao.insertarPersona(nuevaPersona0);
        
        //Persona nuevaPersona1 = new Persona("Carlos", 20, "carlos@email.com");
        //dao.insertarPersona(nuevaPersona1);
        
        //Persona nuevaPersona2 = new Persona("Roberto", 26, "roberto@email.com");
        //dao.insertarPersona(nuevaPersona2);

        // Actualizar persona (suponiendo que el ID 1 existe)
        //Persona personaActualizada = new Persona(2, "Juan actualizado otra vez", 70, "carlos_updated_otravez@email.com");
        //dao.actualizarPersona(personaActualizada);

        // Eliminar persona (suponiendo que el ID 2 existe)
        //dao.eliminarPersona(5);
        
        //Mostrar todas las personas
        System.out.println("Lista de personas:");
        for (Persona p : dao.obtenerPersonas()) {
            System.out.println(p);
        }
        
        
    }
    
}
