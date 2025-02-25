/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package crudpersona;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author janck
 */
public class PersonaDAO {
    private final String URL = "jdbc:postgresql://localhost:5432/PrimeraPracticaSD";
    private final String USUARIO = "postgres";
    private final String PASSWORD = "1234";
    
    // Método para obtener la conexión a la base de datos
    private Connection conectar() throws SQLException {
        return DriverManager.getConnection(URL, USUARIO, PASSWORD);
    }
    
    // Método para insertar una persona en la base de datos
    public void insertarPersona(Persona persona) {
        String sql = "INSERT INTO \"Persona\" (nombre, edad, correo) VALUES (?, ?, ?)";
        
        try (Connection conn = conectar();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setString(1, persona.getNombre());
            stmt.setInt(2, persona.getEdad());
            stmt.setString(3, persona.getCorreo());

            stmt.executeUpdate();
            System.out.println("Persona insertada correctamente.");
        } catch (SQLException e) {
            System.out.println("Error al insertar persona: " + e.getMessage());
        }
    }
    
    // Método para obtener todas las personas
    public List<Persona> obtenerPersonas() {
        List<Persona> lista = new ArrayList<>();
        String sql = "SELECT * FROM \"Persona\"";

        try (Connection conn = conectar();
             Statement stmt = conn.createStatement();
             ResultSet rs = stmt.executeQuery(sql)) {

            while (rs.next()) {
                Persona persona = new Persona(
                        rs.getInt("id"),
                        rs.getString("nombre"),
                        rs.getInt("edad"),
                        rs.getString("correo")
                );
                lista.add(persona);
            }
        } catch (SQLException e) {
            System.out.println("Error al obtener personas: " + e.getMessage());
        }
        return lista;
    }

    // Método para actualizar una persona
    public void actualizarPersona(Persona persona) {
        String sql = "UPDATE \"Persona\" SET nombre=?, edad=?, correo=? WHERE id=?";
        
        try (Connection conn = conectar();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setString(1, persona.getNombre());
            stmt.setInt(2, persona.getEdad());
            stmt.setString(3, persona.getCorreo());
            stmt.setInt(4, persona.getId());

            stmt.executeUpdate();
            System.out.println("Persona actualizada correctamente.");
        } catch (SQLException e) {
            System.out.println("Error al actualizar persona: " + e.getMessage());
        }
    }

    // Método para eliminar una persona por ID
    public void eliminarPersona(int id) {
        String sql = "DELETE FROM \"Persona\" WHERE id=?";
        
        try (Connection conn = conectar();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, id);
            stmt.executeUpdate();
            System.out.println("Persona eliminada correctamente.");
        } catch (SQLException e) {
            System.out.println("Error al eliminar persona: " + e.getMessage());
        }
    }
}
