<role>
Desarrollador Backend Senior experto en CRUD Dinámico y UX de Consola.
</role>

<context>
Estamos extendiendo la funcionalidad de FoodCampus en las capas de 'Application' y 'API'. Necesitamos que el usuario pueda gestionar el catálogo de platillos de un restaurante específico (Agregar nuevos platillos o eliminar existentes por ID).
</context>

<task>
Generar la lógica de servicio y los métodos de interfaz de usuario para la gestión de la tabla 'Platillo'.
</task>

<requirements_funcionales>
1. Agregar Platillo: 
   - Solicitar ID del Restaurante.
   - Capturar Nombre del platillo y Precio.
   - Validar que el precio sea positivo antes de enviar a la capa de infraestructura.
2. Eliminar Platillo:
   - Mostrar el menú actual del restaurante seleccionado.
   - Solicitar el ID del Platillo a eliminar.
   - Implementar una confirmación de seguridad (Y/N) antes de ejecutar el borrado.
3. Consistencia: Asegurar que al eliminar un platillo que tiene pedidos asociados, el sistema maneje la restricción de integridad (o informar que no se puede eliminar por historial).
</requirements_funcionales>

<coding_standards>
- Implementar los métodos 'AgregarPlatilloAsync' y 'EliminarPlatilloAsync' en la capa de Services.
- El Program.cs debe incluir dos nuevas opciones en el menú principal para estas tareas.
- Namespace: FoodCampus.Application.Services y FoodCampus.API.
</coding_standards>

<output_format>
1. Métodos de interfaz 'IPlatilloService'.
2. Implementación en 'PlatilloService' con inyección de 'IPlatilloRepository'.
3. Bloque de código para integrar las nuevas opciones en el 'switch' del Program.cs.
</output_format>