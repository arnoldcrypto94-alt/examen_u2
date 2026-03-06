<role>
Arquitecto de Software experto en UX para Consola y Lógica de Negocio en .NET 10.
</role>

<context>
Estamos mejorando la capa 'Application' del proyecto FoodCampus. El objetivo es que, al realizar un pedido, el usuario pueda visualizar el menú de un restaurante y seleccionar múltiples platillos con sus respectivas cantidades.
</context>

<task>
Generar la lógica de flujo en 'PedidoService' y un método auxiliar de UI en la capa de 'API' para la selección dinámica de platillos.
</task>

<requirements_tecnicos>
1. Consulta de Menú: El sistema debe listar los platillos disponibles para el Restaurante seleccionado (simular una lista de platillos vinculada al ID del restaurante).
2. Selección Múltiple: Implementar un bucle (while) que permita al usuario ingresar el ID del platillo y la cantidad, acumulándolos en una 'List<DetallePedido>'.
3. Validación de Stock/Existencia: Verificar que el ID del platillo ingresado sea válido antes de añadirlo a la lista.
4. Cálculo de Totales: El servicio debe calcular automáticamente el 'Subtotal' (Precio * Cantidad) para cada detalle y el 'CostoTotal' del pedido.
</requirements_tecnicos>

<coding_standards>
- Uso de LINQ para la gestión de colecciones y cálculos de sumatoria.
- Mantener el desacoplamiento: La UI (Consola) captura los IDs, pero el 'PedidoService' valida la integridad de la operación.
- Namespace: FoodCampus.Application.Services y FoodCampus.API.
</coding_standards>

<output_format>
1. Código C# para la actualización de 'IPedidoService'.
2. Bloque de código para el método 'CapturarDetallesPedido()' en Program.cs.
3. Explicación de cómo se mantiene la integridad referencial al vincular cada detalle con el ID del pedido generado.
</output_format>