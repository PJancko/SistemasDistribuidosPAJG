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
        return Factura::all();
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $request->validate([
            'ci' => 'required|string|max:255',
            'descripcion' => 'required|string|max:255',
            'monto' => 'required|numeric',
        ]);

        return Factura::create($request->all());
    }

    /**
     * Display the specified resource.
     */
    public function show(Factura $factura)
    {
        return $factura;
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, Factura $factura)
    {
        $factura->update($request->all());
        return $factura;
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Factura $factura)
    {
        $factura->delete();
        return response()->json(['message' => 'Factura deleted successfully']);
    }
}
