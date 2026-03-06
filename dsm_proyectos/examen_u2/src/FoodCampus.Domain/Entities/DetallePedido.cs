namespace FoodCampus.Domain.Entities;

/// <summary>
/// Entidad que detalla los platillos dentro de un pedido.
/// </summary>
/// <param name="idDetalle">ID único del detalle.</param>
/// <param name="idPedido">ID del pedido asociado.</param>
/// <param name="idPlatillo">ID del platillo seleccionado.</param>
/// <param name="cantidad">Número de unidades solicitadas.</param>
/// <param name="subtotal">Costo total de esta línea de pedido.</param>
public class DetallePedido(int idDetalle, int idPedido, int idPlatillo, int cantidad, decimal subtotal)
{
    public int IdDetalle { get; init; } = idDetalle;

    public int IdPedido { get; init; } = idPedido;

    public int IdPlatillo { get; init; } = idPlatillo;

    public int Cantidad { 
        get; 
        set {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(Cantidad), "La cantidad debe ser mayor a 0.");
            field = value;
        }
    } = cantidad;

    public decimal Subtotal { 
        get; 
        set {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(Subtotal), "El subtotal no puede ser negativo.");
            field = value;
        }
    } = subtotal;
}
