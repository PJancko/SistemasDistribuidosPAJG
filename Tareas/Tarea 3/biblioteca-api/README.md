# Habilitar apis
php artisan install:api

# Hacer correr las migraciones
php artisan migrate

# Crear modelo, migracion, seeder, factory y controller para api
php artisan make:model Libro -msfc --api

# Luego de crear el modelo
# En la migracion crear los campos
# Crear los seeder
# Enlazar el seeder al databaseSeeder
# Hacer correr las migraciones y seeder