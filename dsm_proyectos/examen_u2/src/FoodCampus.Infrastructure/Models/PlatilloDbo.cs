namespace FoodCampus.Infrastructure.Models;

/// <summary>
/// Modelo de datos para la tabla Platillo.
/// </summary>
public class PlatilloDbo
{
    public int IdPlatillo { get; set; }
    public int IdRestaurante { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
}
