using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Models;

namespace FoodCampus.Infrastructure.Mappers;

/// <summary>
/// Transformador manual entre la tabla Pedido y su entidad de negocio.
/// </summary>
public static class PedidoMapper
{
    public static Pedido ToDomain(this PedidoDbo dbo)
    {
        return new Pedido(
            dbo.IdPedido,
            dbo.IdUsuario,
            dbo.FechaHora,
            dbo.CostoEnvio
        );
    }

    public static PedidoDbo ToDbo(this Pedido entity)
    {
        return new PedidoDbo
        {
            IdPedido = entity.IdPedido,
            IdUsuario = entity.IdUsuario,
            FechaHora = entity.FechaHora,
            CostoEnvio = entity.CostoEnvio
        };
    }

    public static IEnumerable<Pedido> ToDomainList(this IEnumerable<PedidoDbo> dbos)
    {
        return dbos.Select(dbo => dbo.ToDomain());
    }
}
