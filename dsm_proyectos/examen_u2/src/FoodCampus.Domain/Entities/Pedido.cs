namespace FoodCampus.Domain.Entities;

/// <summary>
/// Entidad que representa una orden de compra.
/// </summary>
/// <param name="idPedido">ID de la orden.</param>
/// <param name="idUsuario">ID del cliente.</param>
/// <param name="fechaHora">Marca de tiempo de la orden.</param>
/// <param name="costoEnvio">Tarifa de entrega.</param>
public class Pedido(int idPedido, int idUsuario, DateTime fechaHora, decimal costoEnvio)
{
    public int IdPedido { get; init; } = idPedido;

    public int IdUsuario { get; init; } = idUsuario;

    public DateTime FechaHora { get; init; } = fechaHora;

    public decimal CostoEnvio { 
        get; 
        set {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(CostoEnvio), "El costo de envío no puede ser negativo.");
            field = value;
        }
    } = costoEnvio;
}
