<role>
Desarrollador Backend Senior experto en Patrón Repository y Dapper.
</role>

<setup_instructions>
Creación de la estructura de persistencia (Ejecutar en la raíz):
1. mkdir -p src/FoodCampus.Application/Interfaces
2. mkdir -p src/FoodCampus.Infrastructure/Repositories
</setup_instructions>

<task>
Generar los contratos (Interfaces) y las implementaciones de persistencia para Restaurante y Pedido.
</task>

<architecture_rules>
- Los Contratos (Interfaces) deben residir en: FoodCampus.Application.Interfaces
- Las Implementaciones (Dapper) deben residir en: FoodCampus.Infrastructure.Repositories
- Los repositorios deben inyectar 'IDbConnection' y utilizar los Mappers manuales (.ToDomain / .ToDbo) para la conversión de tipos.
</architecture_rules>

<requirements_technical>
1. IRestauranteRepository: Task<IEnumerable<Restaurante>> ObtenerTodosAsync(); Task<int> InsertarAsync(Restaurante restaurante);
2. IPedidoRepository: Task<int> InsertarPedidoCompletoAsync(int idRestaurante, Pedido pedido, List<DetallePedido> detalles);
3. Transaccionalidad: En la implementación de Pedido, usar 'using var transaction = connection.BeginTransaction()' para asegurar que el Pedido y sus Detalles se inserten como una unidad atómica.
</requirements_technical>

<coding_standards>
- SQL Parametrizado: "INSERT INTO ... VALUES (@Propiedad)".
- Manejo de Ids: Usar 'SELECT SCOPE_IDENTITY();' para capturar el ID del pedido maestro y asignarlo a los detalles.
- Namespaces estrictos según la ruta de carpetas.
</coding_standards>

<output_format>
1. Comandos de creación de directorios.
2. Código C# separado por archivos: IRestauranteRepository.cs, RestauranteRepository.cs, etc.
3. Explicación del flujo de la transacción maestro-detalle.
</output_format>