using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Models;

namespace FoodCampus.Infrastructure.Mappers;

/// <summary>
/// Transformador manual entre la tabla Restaurante y su entidad de negocio.
/// </summary>
public static class RestauranteMapper
{
    public static Restaurante ToDomain(this RestauranteDbo dbo)
    {
        return new Restaurante(
            dbo.Id,
            dbo.Nombre,
            dbo.Especialidad ?? string.Empty,
            TimeOnly.FromTimeSpan(dbo.HorarioApertura),
            TimeOnly.FromTimeSpan(dbo.HorarioCierre)
        );
    }

    public static RestauranteDbo ToDbo(this Restaurante entity)
    {
        return new RestauranteDbo
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Especialidad = entity.Especialidad,
            HorarioApertura = entity.HorarioApertura.ToTimeSpan(),
            HorarioCierre = entity.HorarioCierre.ToTimeSpan()
        };
    }

    public static IEnumerable<Restaurante> ToDomainList(this IEnumerable<RestauranteDbo> dbos)
    {
        return dbos.Select(dbo => dbo.ToDomain());
    }
}
