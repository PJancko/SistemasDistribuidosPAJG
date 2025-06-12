<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Titulo;

class TituloController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return Titulo::all();
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        // se esta enviando la fecha)emision como string, se debe convertir a fecha
        $request->merge([
            'fecha_emision' => date('Y-m-d', strtotime($request->fecha_emision))
        ]);
        $request->validate([
            'ci' => 'required|string|max:255',
            'nombres' => 'required|string|max:255',
            'primerApellido' => 'required|string|max:255',
            'segundoApellido' => 'required|string|max:255',
            'titulo' => 'required|string|max:255',
            'fecha_emision' => 'required|date',
        ]);

        return Titulo::create($request->all());

    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        return Titulo::findOrFail($id);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        $titulo = Titulo::findOrFail($id);
        $titulo->update($request->all());
        return $titulo;
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $titulo = Titulo::findOrFail($id);
        $titulo->delete();
        return response()->json(['message' => 'Titulo eliminado']);
    }
}
