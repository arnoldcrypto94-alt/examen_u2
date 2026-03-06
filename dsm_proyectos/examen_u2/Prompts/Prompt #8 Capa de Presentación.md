<role>
Líder Técnico Senior .NET experto en Inyección de Dependencias y Arquitectura Limpia.
</role>

<context>
Este es el punto de entrada (Entry Point) del sistema FoodCampus. Debemos orquestar la conexión entre las 4 capas del proyecto y presentar la interfaz de usuario.
</context>

<setup_instructions>
CABLEADO DE REFERENCIAS (Ejecutar en la terminal desde la carpeta /src):
Para "ordenar el caos", vincula los proyectos con estos comandos:
1. dotnet add FoodCampus.API/FoodCampus.API.csproj reference FoodCampus.Application/FoodCampus.Application.csproj
2. dotnet add FoodCampus.API/FoodCampus.API.csproj reference FoodCampus.Infrastructure/FoodCampus.Infrastructure.csproj
3. dotnet add FoodCampus.Application/FoodCampus.Application.csproj reference FoodCampus.Domain/FoodCampus.Domain.csproj
4. dotnet add FoodCampus.Infrastructure/FoodCampus.Infrastructure.csproj reference FoodCampus.Application/FoodCampus.Application.csproj
</setup_instructions>

<task>
Generar el código completo del 'Program.cs' para la capa FoodCampus.API.
</task>

<database_configuration>
Implementar la conexión real a Somee.com mediante una constante:
- Connection String: "Server=test_utm_kaea.mssql.somee.com;Database=test_utm_kaea;User Id=Arnold_SQLLogin_1;Password=cqxojzcyk4;TrustServerCertificate=True;"
- Registrar 'IDbConnection' como Scoped usando 'SqlConnection(connectionString)'.
</database_configuration>

<requirements_di_csharp14>
1. Registro de Servicios: Vincular interfaces con implementaciones (ej. IRestauranteService -> RestauranteService).
2. Rigor C# 14: Demostrar el registro de genéricos no vinculados usando: 
   'services.AddScoped(typeof(IRepository<>), typeof(Repository<>));' e incorporar el operador 'nameof()' en los comentarios de documentación del registro.
</requirements_di_csharp14>

<ui_and_resilience>
1. Interfaz: Menú interactivo con (1) Registrar Restaurante, (2) Listar, (3) Pedido Maestro-Detalle, (4) Salir.
2. Resiliencia: El programa debe estar envuelto en un 'while(true)' con un bloque 'try-catch' global para que fallos de red en Somee o errores de teclado no detengan la ejecución.
3. Feedback: Usar 'Console.ForegroundColor' para mostrar errores en Rojo y confirmaciones en Verde.
</ui_and_resilience>

<output_format>
1. Lista de comandos CLI para asegurar