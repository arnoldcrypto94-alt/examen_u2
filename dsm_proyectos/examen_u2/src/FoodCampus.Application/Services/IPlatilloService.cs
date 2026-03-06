using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.Services;

/// <summary>
/// Contrato para la orquestación de la gestión de Platillos.
/// </summary>
public interface IPlatilloService
{
    Task<int> AgregarPlatilloAsync(Platillo platillo);
    Task<bool> EliminarPlatilloAsync(int idPlatillo);
    Task<List<Platillo>> ListarPlatillosAsync(int idRestaurante);
}
