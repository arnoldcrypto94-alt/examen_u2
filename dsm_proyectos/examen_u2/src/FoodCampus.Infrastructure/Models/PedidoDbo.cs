namespace FoodCampus.Infrastructure.Models;

/// <summary>
/// Data Business Object para el mapeo de la tabla Pedido.
/// </summary>
public sealed record PedidoDbo
{
    public int IdPedido { get; init; }
    public int IdUsuario { get; init; }
    public DateTime FechaHora { get; init; }
    public decimal CostoEnvio { get; init; }
}
