using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.Services;

/// <summary>
/// Contrato para la orquestación de la lógica de negocio de Restaurantes.
/// </summary>
public interface IRestauranteService
{
    Task<IEnumerable<Restaurante>> ListarRestaurantesAsync();
    Task<int> RegistrarNuevoRestauranteAsync(Restaurante restaurante);
}
