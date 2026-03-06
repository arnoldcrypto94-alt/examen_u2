<role>
Experto en Acceso a Datos y Micro-ORMs (Dapper/SQL Server).
</role>

<setup_instructions>
Preparación de la Capa de Infraestructura:
Si el proyecto no existe, ejecuta estos comandos en la terminal desde la raíz:
1. mkdir -p src/FoodCampus.Infrastructure/Models
2. cd src/FoodCampus.Infrastructure
3. dotnet new classlib -n FoodCampus.Infrastructure
4. dotnet add package Dapper
5. dotnet add package Microsoft.Data.SqlClient
</setup_instructions>

<task>
Generar los modelos de persistencia (DBOs) para Dapper: RestauranteDbo, PedidoDbo y DetallePedidoDbo.
</task>

<requirements>
1. Las propiedades deben mapear 1:1 con las columnas del script DDL (Restaurante, Pedido, DetallePedido).
2. Usar 'TimeSpan' para columnas SQL de tipo TIME (Horarios).
3. Usar 'decimal' para Subtotales y Costos.
</requirements>

<coding_standards>
- Implementar como 'public sealed class' o 'public record' para optimizar la inmutabilidad y ligereza.
- Namespace: FoodCampus.Infrastructure.Models.
- Seguir la convención PascalCase.
</coding_standards>

<file_management>
- Ubicación: src/FoodCampus.Infrastructure/Models/
- Nota: Estas clases son puramente para transferencia de datos entre SQL y C#.
</file_management>

<output_format>
1. Comandos CLI para instalar dependencias y crear carpetas.
2. Código C# limpio separado por archivos.
3. Breve explicación de cómo Dapper utiliza la reflexión para unir estas propiedades con el ResultSet de SQL.
</output_format>