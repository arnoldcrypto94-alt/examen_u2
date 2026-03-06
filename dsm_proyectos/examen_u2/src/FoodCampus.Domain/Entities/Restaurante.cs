namespace FoodCampus.Domain.Entities;

/// <summary>
/// Entidad que representa un establecimiento de comida.
/// </summary>
/// <param name="id">ID único del restaurante.</param>
/// <param name="nombre">Nombre oficial.</param>
/// <param name="especialidad">Tipo de cocina dominante.</param>
/// <param name="horarioApertura">Hora de apertura.</param>
/// <param name="horarioCierre">Hora de cierre.</param>
public class Restaurante(int id, string nombre, string especialidad, TimeOnly horarioApertura, TimeOnly horarioCierre)
{
    public int Id { get; init; } = id;

    public string Nombre { 
        get; 
        set {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("El nombre no puede estar vacío.");
            field = value;
        }
    } = nombre;

    public string Especialidad { get; set; } = especialidad;

    public TimeOnly HorarioApertura { get; set; } = horarioApertura;

    public TimeOnly HorarioCierre { get; set; } = horarioCierre;
}
