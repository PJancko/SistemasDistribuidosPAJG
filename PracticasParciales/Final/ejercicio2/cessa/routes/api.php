<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\FacturaController;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::get('/facturas', [FacturaController::class, 'index']);
Route::get('/facturas/{ci}', [FacturaController::class, 'obtenerPorCI']);
Route::put('/facturas/{nro_factura}', [FacturaController::class, 'pagarFactura']);
