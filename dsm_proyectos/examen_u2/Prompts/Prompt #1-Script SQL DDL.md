<role>
Administrador de Bases de Datos senior experto en SQL Server y Normalización.
</role>

<setup_instructions>
Preparación de la Raíz del Proyecto:
Desde la terminal, asegura la carpeta para los scripts de base de datos:
> mkdir -p db-scripts
</setup_instructions>

<task>
Generar el script SQL DDL (creación de tablas) para el sistema FoodCampus, incluyendo la entidad de Menú.
</task>

<requirements_entidades>
1. Tabla Restaurante: Id (PK, Identity), Nombre (NVARCHAR 100, Req), Especialidad, Horarios (TIME).
2. Tabla Platillo: IdPlatillo (PK, Identity), IdRestaurante (FK), Nombre (Req), Precio (DECIMAL 18,2, CHECK > 0). 
   *Nota: Cada restaurante tiene su propio menú.*
3. Tabla Pedido: IdPedido (PK, Identity), IdUsuario, FechaHora, CostoEnvio (CHECK >= 0).
4. Tabla DetallePedido: IdDetalle (PK, Identity), IdPedido (FK), IdPlatillo (FK), Cantidad (CHECK > 0), Subtotal (DECIMAL 18,2).
</requirements_entidades>

<file_management>
- Ubicación: /db-scripts/01_schema.sql
- Formato: SQL puro compatible con el Query Analyzer de Somee.com.
</file_management>

<coding_standards>
- Usar CamelCase para consistencia con el código C#.
- Implementar Integridad Referencial (Foreign Keys) con 'ON DELETE CASCADE' donde sea lógico.
- Incluir bloques 'IF OBJECT_ID... DROP TABLE' al inicio para ejecuciones limpias.
</coding_standards>

<output_format>
1. Comando CLI para creación de carpeta.
2. Script SQL DDL completo y comentado técnicamente.
</output_format>