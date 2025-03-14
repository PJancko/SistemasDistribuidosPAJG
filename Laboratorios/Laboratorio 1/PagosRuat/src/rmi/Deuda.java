/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package rmi;

import java.io.Serializable;
import java.util.Objects;

/**
 *
 * @author janck
 */
public class Deuda implements Serializable {

    String ci;
    int anio;
    Impuesto impuesto;
    double monto;

    public Deuda(String ci, int anio, Impuesto impuesto, double monto) {
        this.ci = ci;
        this.anio = anio;
        this.impuesto = impuesto;
        this.monto = monto;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null || getClass() != obj.getClass()) {
            return false;
        }
        Deuda deuda = (Deuda) obj;
        return this.getCi().equals(deuda.getCi()) && this.getAnio() == deuda.getAnio() && this.getImpuesto() == deuda.getImpuesto();
    }

    @Override
    public int hashCode() {
        return Objects.hash(getCi(), getAnio(), getImpuesto());
    }

    public String getCi() {
        return ci;
    }

    public void setCi(String ci) {
        this.ci = ci;
    }

    public int getAnio() {
        return anio;
    }

    public void setAnio(int anio) {
        this.anio = anio;
    }

    public Impuesto getImpuesto() {
        return impuesto;
    }

    public void setImpuesto(Impuesto impuesto) {
        this.impuesto = impuesto;
    }

    public double getMonto() {
        return monto;
    }

    public void setMonto(double monto) {
        this.monto = monto;
    }

    @Override
    public String toString() {
        return "Deuda{" + "ci=" + ci + ", anio=" + anio + ", impuesto=" + impuesto + ", monto=" + monto + '}';
    }

}
