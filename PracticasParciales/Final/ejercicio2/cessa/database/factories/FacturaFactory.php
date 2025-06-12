<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Factura>
 */
class FacturaFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [
            'empresa' => $this->faker->company,
            'nro_factura' => 'F-' . $this->faker->unique()->randomNumber(6),
            'ci' => $this->faker->numerify('########'),
            'nombre_completo' => $this->faker->name,
            'periodo' => $this->faker->date('Y-m', 'now'),
            'monto' => $this->faker->randomFloat(2, 100, 1000),
            'estado' => 'pendiente', // Estado por defecto
        ];
    }
}
