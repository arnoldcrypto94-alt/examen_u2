using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.Interfaces;

/// <summary>
/// Contrato de persistencia para Restaurantes.
/// </summary>
public interface IRestauranteRepository
{
    Task<IEnumerable<Restaurante>> ObtenerTodosAsync();
    Task<int> InsertarAsync(Restaurante restaurante);
}
