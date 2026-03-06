using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.Interfaces;

/// <summary>
/// Contrato de persistencia para Pedidos y sus detalles.
/// </summary>
public interface IPedidoRepository
{
    /// <summary>
    /// Inserta un pedido y todos sus detalles como una operación atómica.
    /// </summary>
    Task<int> InsertarPedidoCompletoAsync(int idRestaurante, Pedido pedido, List<DetallePedido> detalles);
}
