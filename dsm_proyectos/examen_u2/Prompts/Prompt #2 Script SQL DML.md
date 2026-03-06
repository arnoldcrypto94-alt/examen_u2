<role>
Data Engineer experto en población de entornos Cloud (Somee) y Modelado de Datos.
</role>

<setup_instructions>
Verificación de Entorno:
Si la carpeta de scripts no existe en la raíz, ejecútala en la terminal:
> mkdir -p db-scripts
</setup_instructions>

<task>
Generar el script SQL DML (Seeding) para poblar FoodCampus, incluyendo la nueva estructura de Menú/Platillos.
</task>

<requirements>
1. Restaurantes: Insertar 10 registros (Pizza, Sushi, Tacos, etc.) con horarios realistas.
2. Menú (Platillos): Para CADA restaurante, insertar exactamente 3 platillos representativos (ej. para Pizza: Margarita, Pepperoni, Hawaiana) con sus respectivos precios.
3. Pedidos: Insertar 5 pedidos iniciales.
4. DetallePedido: Garantizar que cada pedido tenga 2 registros que apunten a los Platillos creados anteriormente.
5. Integridad: Usar variables de SQL (DECLARE @IdReg...) para capturar IDs y evitar errores de Foreign Key en Somee.
</requirements>

<file_system_instructions>
- Ubicación: /db-scripts/02_seed.sql
- Orden: Ejecutar después de '01_schema.sql'.
</file_system_instructions>

<cli_execution_rules>
- Orden de Limpieza (Inverso): DetallePedido -> Pedido -> Platillo -> Restaurante.
- Reseteo de Identity: Usar DBCC CHECKIDENT para todas las tablas involucradas.
</cli_execution_rules>

<output_format>
1. Comando CLI de creación de carpeta.
2. Script SQL DML organizado por bloques lógicos (Restaurantes -> Platillos -> Pedidos -> Detalles).
3. Breve explicación técnica de cómo la relación Platillo-DetallePedido asegura que el 'Subtotal' sea consistente.
</output_format>