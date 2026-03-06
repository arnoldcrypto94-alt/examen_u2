using FoodCampus.Application.Interfaces;
using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.Services;

/// <summary>
/// Orquestador de lógica de negocio para Restaurantes.
/// </summary>
/// <param name="repository">Repositorio de acceso a datos.</param>
public class RestauranteService(IRestauranteRepository repository) : IRestauranteService
{
    private readonly IRestauranteRepository _repository = repository;

    public async Task<IEnumerable<Restaurante>> ListarRestaurantesAsync()
    {
        return await _repository.ObtenerTodosAsync();
    }

    public async Task<int> RegistrarNuevoRestauranteAsync(Restaurante restaurante)
    {
        // El dominio ya valida el nombre y otros campos a través de 'field' en los setters.
        return await _repository.InsertarAsync(restaurante);
    }
}
