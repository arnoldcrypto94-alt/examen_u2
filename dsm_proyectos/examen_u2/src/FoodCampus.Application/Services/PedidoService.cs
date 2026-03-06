using FoodCampus.Application.Interfaces;
using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.Services;

/// <summary>
/// Orquestador de lógica de negocio para la gestión de Pedidos.
/// </summary>
/// <param name="pedidoRepo">Repositorio de pedidos.</param>
/// <param name="restauranteRepo">Repositorio de restaurantes para validación de horarios.</param>
public class PedidoService(
    IPedidoRepository pedidoRepo, 
    IRestauranteRepository restauranteRepo,
    IPlatilloRepository platilloRepo) : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepo = pedidoRepo;
    private readonly IRestauranteRepository _restauranteRepo = restauranteRepo;
    private readonly IPlatilloRepository _platilloRepo = platilloRepo;

    public async Task<int> CrearPedidoCompletoAsync(int idRestaurante, Pedido pedido, List<DetallePedido> detalles)
    {
        // 1. Obtener restaurante para validar horario
        var restaurantes = await _restauranteRepo.ObtenerTodosAsync();
        var restaurante = restaurantes.FirstOrDefault(r => r.Id == idRestaurante) 
                          ?? throw new KeyNotFoundException("El restaurante no existe.");

        // 2. Lógica de Validación de Horario
        var horaActual = TimeOnly.FromDateTime(DateTime.Now);
        
        if (horaActual < restaurante.HorarioApertura || horaActual > restaurante.HorarioCierre)
        {
            throw new InvalidOperationException($"El restaurante {restaurante.Nombre} está cerrado. Horario: {restaurante.HorarioApertura} a {restaurante.HorarioCierre}");
        }

        // 3. Validación de integridad de los detalles y cálculo de totales
        if (detalles == null || detalles.Count == 0)
            throw new ArgumentException("El pedido debe contener al menos un platillo.");

        // Recuperar el menú real para validación y precios
        var menu = await _platilloRepo.ObtenerPorRestauranteAsync(idRestaurante);
        var menuDict = menu.ToDictionary(p => p.IdPlatillo);

        foreach (var detalle in detalles)
        {
            if (!menuDict.TryGetValue(detalle.IdPlatillo, out var platillo))
            {
                throw new InvalidOperationException($"El platillo con ID {detalle.IdPlatillo} no pertenece al restaurante {restaurante.Nombre}.");
            }

            // Recalcular subtotal con el precio real de la DB para integridad
            detalle.Subtotal = platillo.Precio * detalle.Cantidad;
        }
        
        // 4. Persistir pedido
        return await _pedidoRepo.InsertarPedidoCompletoAsync(idRestaurante, pedido, detalles);
    }

    /// <summary>
    /// Consulta el menú disponible para un restaurante específico desde la base de datos.
    /// </summary>
    public async Task<List<Platillo>> ObtenerMenuAsync(int idRestaurante)
    {
        var result = await _platilloRepo.ObtenerPorRestauranteAsync(idRestaurante);
        return result.ToList();
    }
}
