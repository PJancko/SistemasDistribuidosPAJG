<?php

namespace App\Http\Controllers;

use App\Models\Factura;
use Illuminate\Http\Request;

class FacturaController extends Controller
{
    /**
     * Display a listing of the resource.
     */

    public function index()
    {
        $facturas = Factura::all();
        return response()->json($facturas);
    }

     // GET /facturas/{ci}
    public function obtenerPorCI(Request $request, $ci)
    {
        $facturas = Factura::where('ci', $ci)->get();
        return response()->json($facturas);
    }

    // PUT /facturas/{nro_factura}
    public function pagarFactura(Request $request, $nro_factura)
    {
        $factura = Factura::where('nro_factura', $nro_factura)->first();

        if (!$factura) {
            return response()->json(['message' => 'Factura no encontrada'], 404);
        }

        // Actualizar el estado de la factura a 'pagada'
        $factura->estado = 'pagada';
        $factura->save();

        return response()->json(['message' => 'Factura pagada exitosamente']);
    }
}
