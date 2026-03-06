namespace FoodCampus.Infrastructure.Models;

/// <summary>
/// Data Business Object para el mapeo de la tabla Restaurante.
/// </summary>
public sealed record RestauranteDbo
{
    public int Id { get; init; }
    public string Nombre { get; init; } = string.Empty;
    public string? Especialidad { get; init; }
    public TimeSpan HorarioApertura { get; init; }
    public TimeSpan HorarioCierre { get; init; }
}
