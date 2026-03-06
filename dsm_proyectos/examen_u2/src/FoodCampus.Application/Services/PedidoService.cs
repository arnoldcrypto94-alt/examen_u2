using FoodCampus.Application.Interfaces;
using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.Services;

/// <summary>
/// Orquestador de lógica de negocio para la gestión de Pedidos.
/// </summary>
/// <param name="pedidoRepo">Repositorio de pedidos.</param>
/// <param name="restauranteRepo">Repositorio de restaurantes para validación de horarios.</param>
public class PedidoService(IPedidoRepository pedidoRepo, IRestauranteRepository restauranteRepo) : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepo = pedidoRepo;
    private readonly IRestauranteRepository _restauranteRepo = restauranteRepo;

    public async Task<int> CrearPedidoCompletoAsync(int idRestaurante, Pedido pedido, List<DetallePedido> detalles)
    {
        // 1. Obtener restaurante para validar horario
        var restaurantes = await _restauranteRepo.ObtenerTodosAsync();
        var restaurante = restaurantes.FirstOrDefault(r => r.Id == idRestaurante) 
                          ?? throw new KeyNotFoundException("El restaurante no existe.");

        // 2. Lógica de Validación de Horario
        var horaActual = TimeOnly.FromDateTime(DateTime.Now);
        
        // Verificamos si la hora actual está dentro del rango operativo
        if (horaActual < restaurante.HorarioApertura || horaActual > restaurante.HorarioCierre)
        {
            throw new InvalidOperationException($"El restaurante {restaurante.Nombre} está cerrado. Horario: {restaurante.HorarioApertura} a {restaurante.HorarioCierre}");
        }

        // 3. Persistir pedido
        return await _pedidoRepo.InsertarPedidoCompletoAsync(idRestaurante, pedido, detalles);
    }
}
