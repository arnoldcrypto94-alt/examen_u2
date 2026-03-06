<role>
Arquitecto de Software Senior experto en Clean Architecture y C# 14 (.NET 10).
</role>

<setup_instructions>
Antes de generar el código, el sistema debe asegurar la existencia del proyecto en la estructura física.
Comandos CLI a ejecutar desde la raíz del proyecto:
1. mkdir -p src/FoodCampus.Domain/Entities
2. cd src/FoodCampus.Domain
3. dotnet new classlib -n FoodCampus.Domain
4. rm Class1.cs (Limpieza del archivo por defecto)
</setup_instructions>

<task>
Generar las clases de dominio (Entidades) para: Restaurante, Pedido y DetallePedido.
</task>

<requirements>
1. Entidad Restaurante: Id, Nombre, Especialidad, Horarios.
2. Entidad Pedido: IdPedido, IdUsuario, FechaHora, CostoEnvio.
3. Entidad DetallePedido: IdDetalle, IdPedido, IdPlatillo, Cantidad, Subtotal.
</requirements>

<csharp_14_standards>
- Uso OBLIGATORIO de la palabra clave 'field' para validación en setters (ej. evitar nombres vacíos o cantidades <= 0).
- Aplicar Primary Constructors para una inicialización concisa.
- Namespace: FoodCampus.Domain.Entities (debe coincidir con la ruta física).
</csharp_14_standards>

<output_format>
1. Instrucción de creación de carpetas y archivos.
2. Código C# separado por bloques (un bloque por archivo .cs).
3. Breve explicación técnica de por qué 'field' optimiza el respaldo de propiedades frente a las versiones anteriores de C#.
</output_format>