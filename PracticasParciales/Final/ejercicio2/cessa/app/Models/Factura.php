<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Factura extends Model
{
    /** @use HasFactory<\Database\Factories\FacturaFactory> */
    use HasFactory;
    protected $fillable = [
        'empresa',
        'nro_factura',
        'ci',
        'nombre_completo',
        'periodo',
        'monto',
        'estado',
    ];
}
