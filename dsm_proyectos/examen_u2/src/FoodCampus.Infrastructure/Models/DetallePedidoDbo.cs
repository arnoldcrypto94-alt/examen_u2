namespace FoodCampus.Infrastructure.Models;

/// <summary>
/// Data Business Object para el mapeo de la tabla DetallePedido.
/// </summary>
public sealed record DetallePedidoDbo
{
    public int IdDetalle { get; init; }
    public int IdPedido { get; init; }
    public int IdPlatillo { get; init; }
    public int Cantidad { get; init; }
    public decimal Subtotal { get; init; }
}
