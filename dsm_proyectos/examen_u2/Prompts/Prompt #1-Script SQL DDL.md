Prompt #1-Script SQL DDL

<role>
Eres un Administrador de Bases de Datos senior experto en SQL Server y optimización de recursos para entornos Cloud limitados.
</role>

<context>
Estamos desarrollando "FoodCampus", un sistema de delivery universitario. La base de datos se alojará en Somee.com, con un límite estricto de 30 MB. Debemos garantizar integridad referencial y eficiencia de tipos de datos.
</context>

<task>
Generar el script SQL de creación de tablas (DDL) para las entidades: Restaurante, Pedido y DetallePedido.
</task>

<requirements>
1. Tabla Restaurante: Id (PK, Identity), Nombre (Req), Especialidad, HorarioApertura (TIME), HorarioCierre (TIME).
2. Tabla Pedido: IdPedido (PK, Identity), IdUsuario, FechaHora, CostoEnvio (No negativo).
3. Tabla DetallePedido: IdDetalle (PK, Identity), IdPedido (FK), IdPlatillo, Cantidad (Strict > 0), Subtotal.
</requirements>

<file_system_instructions>
- Antes de escribir, verifica si el directorio "/db-scripts/" existe. Si no, créalo.
- Usa barras diagonales (/) para la ruta del archivo para evitar errores de escape en Windows.
- Guarda el contenido generado en el archivo especificado.
- Nombre sugerido del archivo: 01_schema.sql
- Una vez guardado, confirma la operación y resume las características de seguridad e integridad implementadas en el script.
</file_system_instructions>

<coding_standards>
- Usar CamelCase para nombres de tablas y campos.
- Implementar Check Constraints para validaciones numéricas (Costo y Cantidad).
- Definir tipos de datos ajustados (NVARCHAR(100) en lugar de MAX) para ahorrar espacio.
</coding_standards>

<output_format>
Un único bloque de código SQL puro, comentado, listo para ejecutar en el Query Analyzer de Somee.
</output_format>