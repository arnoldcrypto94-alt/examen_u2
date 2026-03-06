using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.Services;

/// <summary>
/// Contrato para la orquestación de la creación de pedidos.
/// </summary>
public interface IPedidoService
{
    Task<int> CrearPedidoCompletoAsync(int idRestaurante, Pedido pedido, List<DetallePedido> detalles);
}
