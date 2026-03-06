using FoodCampus.Application.Interfaces;
using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.Services;

/// <summary>
/// Orquestador de lógica de negocio para la gestión de Platillos.
/// </summary>
/// <param name="platilloRepo">Repositorio de platillos.</param>
/// <param name="restauranteRepo">Repositorio de restaurantes para validación.</param>
public class PlatilloService(IPlatilloRepository platilloRepo, IRestauranteRepository restauranteRepo) : IPlatilloService
{
    private readonly IPlatilloRepository _platilloRepo = platilloRepo;
    private readonly IRestauranteRepository _restauranteRepo = restauranteRepo;

    public async Task<int> AgregarPlatilloAsync(Platillo platillo)
    {
        // 1. Validar que el restaurante existe
        var restaurantes = await _restauranteRepo.ObtenerTodosAsync();
        if (!restaurantes.Any(r => r.Id == platillo.IdRestaurante))
        {
            throw new KeyNotFoundException($"El restaurante con ID {platillo.IdRestaurante} no existe.");
        }

        // 2. Validación de negocio (Precio ya se valida en el dominio, pero se puede reforzar)
        if (platillo.Precio <= 0)
            throw new ArgumentOutOfRangeException(nameof(platillo.Precio), "El precio debe ser mayor a 0.");

        // 3. Persistir
        return await _platilloRepo.InsertarAsync(platillo);
    }

    public async Task<bool> EliminarPlatilloAsync(int idPlatillo)
    {
        // Nota: Si el platillo tiene pedidos asociados, el FK en la DB (ON DELETE NO ACTION) 
        // lanzará una excepción de integridad referencial. Capturamos esto en la capa superior o dejamos que fluya.
        try
        {
            return await _platilloRepo.EliminarAsync(idPlatillo);
        }
        catch (System.Exception ex) when (ex.Message.Contains("FK_DetallePedido_Platillo"))
        {
            throw new InvalidOperationException("No se puede eliminar el platillo porque tiene pedidos asociados en el historial.");
        }
    }

    public async Task<List<Platillo>> ListarPlatillosAsync(int idRestaurante)
    {
        var result = await _platilloRepo.ObtenerPorRestauranteAsync(idRestaurante);
        return result.ToList();
    }
}
