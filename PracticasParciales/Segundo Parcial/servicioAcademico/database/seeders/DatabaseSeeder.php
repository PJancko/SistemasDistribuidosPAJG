<?php

namespace Database\Seeders;

use App\Models\Titulo;
use App\Models\User;
// use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        // User::factory(10)->create();
        Titulo::factory()->create([
            'ci' => '12345678',
            'nombres' => 'Juan',
            'primerApellido' => 'Pérez',
            'segundoApellido' => 'Gómez',
            'titulo' => 'Ingeniero de Sistemas',
            'fecha_emision' => now(),
        ]);
        Titulo::factory()->create([
            'ci' => '87654321',
            'nombres' => 'María',
            'primerApellido' => 'López',
            'segundoApellido' => 'Martínez',
            'titulo' => 'Licenciada en Matemáticas',
            'fecha_emision' => now(),
        ]);

        User::factory()->create([
            'name' => 'Test User',
            'email' => 'test@example.com',
        ]);
    }
}
