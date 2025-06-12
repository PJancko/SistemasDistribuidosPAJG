<?php

use App\Http\Controllers\TituloController;
use App\Models\Titulo;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::apiResource('titulos', TituloController::class);
