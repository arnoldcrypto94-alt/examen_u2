<role>
Arquitecto de Software Senior experto en Clean Architecture y Patrones de Orquestación.
</role>

<setup_instructions>
Preparación de la Capa de Lógica de Aplicación:
Desde la raíz del proyecto, ejecuta:
> mkdir -p src/FoodCampus.Application/Services
</setup_instructions>

<task>
Generar los Casos de Uso (Servicios) 'RestauranteService' y 'PedidoService', incluyendo sus interfaces para Inyección de Dependencias.
</task>

<architecture_rules>
- Los servicios deben residir en: FoodCampus.Application.Services.
- Deben depender estrictamente de las INTERFACES de los repositorios (Application.Interfaces).
- Cero acoplamiento con Infraestructura o Dapper.
</architecture_rules>

<requirements_technical>
1. IRestauranteService / RestauranteService: 
   - ListarRestaurantesAsync(): Llama al repositorio y devuelve la lista de dominio.
   - RegistrarNuevoRestauranteAsync(Restaurante r): Valida y persiste.
2. IPedidoService / PedidoService: 
   - CrearPedidoCompletoAsync(...): Recibe el ID del restaurante, el objeto Pedido y la lista de DetallePedido.
3. Lógica de Validación: Implementar una validación previa a la inserción del pedido que verifique si la hora actual está dentro del rango 'HorarioApertura' y 'HorarioCierre' del restaurante.
</requirements_technical>

<coding_standards>
- Inyección de dependencias por constructor.
- Uso de programación asíncrona (Task/Await).
- Namespace: FoodCampus.Application.Services.
</coding_standards>

<output_format>
1. Comandos de creación de directorios.
2. Código C# separado por archivos: IRestauranteService.cs, RestauranteService.cs, etc.
3. Explicación de cómo el servicio actúa como "Puerta de Enlace" entre la UI y la Persistencia.
</output_format>