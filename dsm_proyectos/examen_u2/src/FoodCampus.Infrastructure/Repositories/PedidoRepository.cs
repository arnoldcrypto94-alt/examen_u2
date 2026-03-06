using System.Data;
using Dapper;
using FoodCampus.Application.Interfaces;
using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Mappers;
using FoodCampus.Infrastructure.Models;

namespace FoodCampus.Infrastructure.Repositories;

/// <summary>
/// Implementación Dapper del repositorio de Pedidos con soporte transaccional.
/// </summary>
public class PedidoRepository(IDbConnection connection) : IPedidoRepository
{
    private readonly IDbConnection _connection = connection;

    public async Task<int> InsertarPedidoCompletoAsync(int idRestaurante, Pedido pedido, List<DetallePedido> detalles)
    {
        if (_connection.State != ConnectionState.Open) _connection.Open();
        
        using var transaction = _connection.BeginTransaction();
        try
        {
            // 1. Insertar el pedido maestro
            const string sqlPedido = @"
                INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio)
                VALUES (@IdUsuario, @FechaHora, @CostoEnvio);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            var pedidoDbo = pedido.ToDbo();
            int pedidoId = await _connection.ExecuteScalarAsync<int>(sqlPedido, pedidoDbo, transaction);

            // 2. Insertar los detalles del pedido
            const string sqlDetalle = @"
                INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal)
                VALUES (@IdPedido, @IdPlatillo, @Cantidad, @Subtotal);";

            foreach (var detalle in detalles)
            {
                var detalleDbo = detalle.ToDbo() with { IdPedido = pedidoId };
                await _connection.ExecuteAsync(sqlDetalle, detalleDbo, transaction);
            }

            transaction.Commit();
            return pedidoId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
