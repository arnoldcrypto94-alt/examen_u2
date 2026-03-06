<role>
Desarrollador Senior experto en Patrones de Diseño (Data Mapper) y Desacoplamiento.
</role>

<setup_instructions>
Preparación de la subcapa de Mapeo:
Desde la carpeta 'src/FoodCampus.Infrastructure', ejecuta:
> mkdir Mappers
</setup_instructions>

<task>
Generar Mappers manuales (Métodos de Extensión) para convertir objetos entre la capa de Dominio y la capa de Infraestructura (DBOs).
</task>

<context_technical>
- Origen (Dominio): FoodCampus.Domain.Entities
- Destino (Persistencia): FoodCampus.Infrastructure.Models
- Transformador: FoodCampus.Infrastructure.Mappers
</context_technical>

<requirements>
1. Implementar métodos de extensión 'ToDomain()' para DBO -> Entidad.
2. Implementar métodos de extensión 'ToDbo()' para Entidad -> DBO.
3. El mapeo debe invocar los Primary Constructors de las Entidades de Dominio para asegurar que se disparen las validaciones 'field' de C# 14.
4. Incluir soporte para mapear colecciones: 'IEnumerable<RestauranteDbo>.ToDomainList()'.
</requirements>

<coding_standards>
- Uso de clases estáticas y métodos de extensión ('this RestauranteDbo dbo').
- Namespace: FoodCampus.Infrastructure.Mappers.
- Rendimiento: Mapeo manual directo propiedad por propiedad (Cero reflexión).
</coding_standards>

<output_format>
1. Comando de creación de carpeta.
2. Código C# separado por archivos (RestauranteMapper.cs, etc.).
3. Explicación de por qué el mapeo manual es preferible a AutoMapper en sistemas de alto rendimiento o exámenes técnicos.
</output_format>