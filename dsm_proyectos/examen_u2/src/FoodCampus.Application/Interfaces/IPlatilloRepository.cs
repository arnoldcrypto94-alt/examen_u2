using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.Interfaces;

/// <summary>
/// Contrato de persistencia para Platillos (Dapper).
/// </summary>
public interface IPlatilloRepository
{
    Task<IEnumerable<Platillo>> ObtenerPorRestauranteAsync(int idRestaurante);
    Task<int> InsertarAsync(Platillo platillo);
    Task<bool> EliminarAsync(int idPlatillo);
}
