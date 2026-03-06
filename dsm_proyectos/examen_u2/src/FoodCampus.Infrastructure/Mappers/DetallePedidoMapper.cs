using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Models;

namespace FoodCampus.Infrastructure.Mappers;

/// <summary>
/// Transformador manual entre la tabla DetallePedido y su entidad de negocio.
/// </summary>
public static class DetallePedidoMapper
{
    public static DetallePedido ToDomain(this DetallePedidoDbo dbo)
    {
        return new DetallePedido(
            dbo.IdDetalle,
            dbo.IdPedido,
            dbo.IdPlatillo,
            dbo.Cantidad,
            dbo.Subtotal
        );
    }

    public static DetallePedidoDbo ToDbo(this DetallePedido entity)
    {
        return new DetallePedidoDbo
        {
            IdDetalle = entity.IdDetalle,
            IdPedido = entity.IdPedido,
            IdPlatillo = entity.IdPlatillo,
            Cantidad = entity.Cantidad,
            Subtotal = entity.Subtotal
        };
    }

    public static IEnumerable<DetallePedido> ToDomainList(this IEnumerable<DetallePedidoDbo> dbos)
    {
        return dbos.Select(dbo => dbo.ToDomain());
    }
}
