namespace FoodCampus.Domain.Entities;

/// <summary>
/// Entidad que representa un platillo dentro del menú de un restaurante.
/// </summary>
/// <param name="idPlatillo">ID único del platillo.</param>
/// <param name="idRestaurante">ID del restaurante al que pertenece.</param>
/// <param name="nombre">Nombre del platillo.</param>
/// <param name="precio">Precio unitario.</param>
public class Platillo(int idPlatillo, int idRestaurante, string nombre, decimal precio)
{
    public int IdPlatillo { get; init; } = idPlatillo;
    public int IdRestaurante { get; init; } = idRestaurante;

    public string Nombre { 
        get; 
        set {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("El nombre del platillo no puede estar vacío.");
            field = value;
        }
    } = nombre;

    public decimal Precio { 
        get; 
        set {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(Precio), "El precio debe ser mayor a 0.");
            field = value;
        }
    } = precio;
}
