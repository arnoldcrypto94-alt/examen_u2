using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Models;

namespace FoodCampus.Infrastructure.Mappers;

/// <summary>
/// Transformador entre Entidades de Dominio y Modelos Dapper (DBO).
/// </summary>
public static class PlatilloMapper
{
    public static Platillo ToDomain(this PlatilloDbo dbo) =>
        new(dbo.IdPlatillo, dbo.IdRestaurante, dbo.Nombre, dbo.Precio);

    public static PlatilloDbo ToDbo(this Platillo domain) => new()
    {
        IdPlatillo = domain.IdPlatillo,
        IdRestaurante = domain.IdRestaurante,
        Nombre = domain.Nombre,
        Precio = domain.Precio
    };

    public static List<Platillo> ToDomainList(this IEnumerable<PlatilloDbo> dbos) =>
        dbos.Select(d => d.ToDomain()).ToList();
}
