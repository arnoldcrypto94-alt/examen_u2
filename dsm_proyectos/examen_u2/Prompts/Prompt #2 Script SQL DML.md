<role>
Data Engineer experto en población de entornos Cloud (Somee).
</role>

<setup_instructions>
Verificación de Entorno:
Si por alguna razón la carpeta de scripts no existe, ejecútala ahora en la terminal:
> mkdir -p db-scripts
</setup_instructions>

<task>
Generar el script SQL DML (Seeding) para poblar FoodCampus.
</task>

<requirements>
1. Insertar 10 restaurantes (Pizza, Sushi, Tacos, etc.) con horarios de atención realistas.
2. Insertar 5 pedidos, garantizando que cada uno tenga exactamente 2 registros en DetallePedido (Relación Maestro-Detalle).
3. Usar variables de SQL (@IdRestaurante, etc.) o subconsultas para capturar los IDs generados y evitar errores de integridad referencial.
</requirements>

<file_system_instructions>
- Ubicación: /db-scripts/02_seed.sql
- Restricción: Este archivo debe ser el segundo en ejecutarse en el Query Analyzer de Somee.
</file_system_instructions>

<cli_execution_rules>
- Bloque de limpieza: Incluir DELETE FROM en orden inverso (DetallePedido -> Pedido -> Restaurante) para evitar errores de Foreign Key.
- Reinicio de contadores: Usar DBCC CHECKIDENT para resetear los campos Identity a 1.
</cli_execution_rules>

<output_format>
1. Comando de verificación de carpeta.
2. Script SQL organizado y comentado.
</output_format>