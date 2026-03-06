using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using FoodCampus.Application.Interfaces;
using FoodCampus.Application.Services;
using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Repositories;

namespace FoodCampus.API;

public class Program
{
    private const string ConnectionString = "Server=test_utm_kaea.mssql.somee.com;Database=test_utm_kaea;User Id=Arnold_SQLLogin_1;Password=cqxojzcyk4;TrustServerCertificate=True;";

    public static async Task Main(string[] args)
    {
        // 1. Configuración de Inyección de Dependencias
        var serviceProvider = new ServiceCollection()
            // Infraestructura: Registro de conexión a base de datos
            .AddScoped<IDbConnection>(_ => new SqlConnection(ConnectionString))
            
            // Repositorios
            .AddScoped<IRestauranteRepository, RestauranteRepository>()
            .AddScoped<IPedidoRepository, PedidoRepository>()
            .AddScoped<IPlatilloRepository, PlatilloRepository>()
            
            // Servicios de Aplicación
            .AddScoped<IRestauranteService, RestauranteService>()
            .AddScoped<IPedidoService, PedidoService>()
            .AddScoped<IPlatilloService, PlatilloService>()
            
            .BuildServiceProvider();

        var restauranteService = serviceProvider.GetRequiredService<IRestauranteService>();
        var pedidoService = serviceProvider.GetRequiredService<IPedidoService>();
        var platilloService = serviceProvider.GetRequiredService<IPlatilloService>();

        Console.Clear();
        Console.WriteLine("=== SISTEMA FOODCAMPUS - BIENVENIDO ===");

        // 2. Resiliencia: Bucle infinito con Try-Catch Global
        while (true)
        {
            try
            {
                MostrarMenu();
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        await RegistrarRestauranteUI(restauranteService);
                        break;
                    case "2":
                        await ListarRestaurantesUI(restauranteService);
                        break;
                    case "3":
                        await CrearPedidoUI(pedidoService);
                        break;
                    case "4":
                        await AgregarPlatilloUI(platilloService);
                        break;
                    case "5":
                        await EliminarPlatilloUI(platilloService);
                        break;
                    case "6":
                        Console.WriteLine("Saliendo del sistema...");
                        return;
                    default:
                        MostrarError("Opción no válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MostrarError($"ERROR CRÍTICO: {ex.Message}");
                Console.WriteLine("Presione cualquier tecla para reintentar...");
                Console.ReadKey();
            }
        }
    }

    private static void MostrarMenu()
    {
        Console.ResetColor();
        Console.WriteLine("\n--- MENU PRINCIPAL ---");
        Console.WriteLine("1. Registrar Restaurante");
        Console.WriteLine("2. Listar Restaurantes");
        Console.WriteLine("3. Crear Pedido (Maestro-Detalle)");
        Console.WriteLine("4. Agregar Platillo al Menú");
        Console.WriteLine("5. Eliminar Platillo del Menú");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
    }

    private static async Task AgregarPlatilloUI(IPlatilloService service)
    {
        Console.WriteLine("\n--- AGREGAR PLATILLO ---");
        Console.Write("ID Restaurante: ");
        if (!int.TryParse(Console.ReadLine(), out int idRest)) return;
        
        Console.Write("Nombre del Platillo: ");
        string nombre = Console.ReadLine() ?? "";
        
        Console.Write("Precio: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal precio)) return;

        var platillo = new Platillo(0, idRest, nombre, precio);
        int id = await service.AgregarPlatilloAsync(platillo);
        MostrarExito($"Platillo agregado con ID: {id}");
    }

    private static async Task EliminarPlatilloUI(IPlatilloService service)
    {
        Console.WriteLine("\n--- ELIMINAR PLATILLO ---");
        Console.Write("ID Restaurante para ver menú: ");
        if (!int.TryParse(Console.ReadLine(), out int idRest)) return;

        var menu = await service.ListarPlatillosAsync(idRest);
        if (menu.Count == 0)
        {
            Console.WriteLine("El restaurante no tiene platillos registrados.");
            return;
        }

        Console.WriteLine("\n--- MENÚ ACTUAL ---");
        foreach (var p in menu)
        {
            Console.WriteLine($"[{p.IdPlatillo}] {p.Nombre} - ${p.Precio}");
        }

        Console.Write("\nID del Platillo a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int idPlat)) return;

        Console.Write("¿Está seguro de eliminar este platillo? (Y/N): ");
        string confirm = Console.ReadLine()?.ToUpper() ?? "N";
        
        if (confirm == "Y")
        {
            bool eliminado = await service.EliminarPlatilloAsync(idPlat);
            if (eliminado) MostrarExito("Platillo eliminado exitosamente.");
            else MostrarError("No se pudo eliminar el platillo (ID no encontrado).");
        }
        else
        {
            Console.WriteLine("Operación cancelada.");
        }
    }

    private static async Task RegistrarRestauranteUI(IRestauranteService service)
    {
        Console.WriteLine("\n--- NUEVO RESTAURANTE ---");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Especialidad: ");
        string especialidad = Console.ReadLine() ?? "";
        
        var restaurante = new Restaurante(0, nombre, especialidad, new TimeOnly(9, 0), new TimeOnly(21, 0));
        
        int id = await service.RegistrarNuevoRestauranteAsync(restaurante);
        MostrarExito($"Restaurante registrado con ID: {id}");
    }

    private static async Task ListarRestaurantesUI(IRestauranteService service)
    {
        Console.WriteLine("\n--- LISTADO DE RESTAURANTES ---");
        var lista = await service.ListarRestaurantesAsync();
        foreach (var r in lista)
        {
            Console.WriteLine($"[{r.Id}] {r.Nombre} - {r.Especialidad} ({r.HorarioApertura} - {r.HorarioCierre})");
        }
    }

    private static async Task CrearPedidoUI(IPedidoService service)
    {
        Console.WriteLine("\n--- CREAR NUEVO PEDIDO ---");
        Console.Write("ID Restaurante: ");
        if (!int.TryParse(Console.ReadLine(), out int idRest)) return;
        
        // 1. Mostrar Menú del Restaurante
        var menu = await service.ObtenerMenuAsync(idRest);

        if (menu.Count == 0)
        {
            MostrarError("El restaurante seleccionado no tiene platillos en su menú. Regresando al menú principal...");
            return;
        }

        Console.WriteLine("\n--- MENÚ DISPONIBLE ---");
        foreach (var p in menu)
        {
            Console.WriteLine($"[{p.IdPlatillo}] {p.Nombre} - ${p.Precio}");
        }

        Console.Write("\nID Usuario: ");
        if (!int.TryParse(Console.ReadLine(), out int idUser)) return;

        // 2. Captura Dinámica de Detalles
        var detalles = CapturarDetallesPedido(menu);
        
        if (detalles.Count == 0)
        {
            MostrarError("No se seleccionaron platillos. Pedido cancelado.");
            return;
        }

        var pedido = new Pedido(0, idUser, DateTime.Now, 15.00m);
        
        int idPedido = await service.CrearPedidoCompletoAsync(idRest, pedido, detalles);
        MostrarExito($"Pedido Maestro-Detalle creado exitosamente con ID: {idPedido}");
        
        decimal total = detalles.Sum(d => d.Subtotal) + pedido.CostoEnvio;
        Console.WriteLine($"Total a Pagar (inc. envío): ${total}");
    }

    private static List<DetallePedido> CapturarDetallesPedido(List<Platillo> menu)
    {
        var detalles = new List<DetallePedido>();
        bool continuar = true;

        while (continuar)
        {
            Console.Write("\nIngrese ID del platillo (o '0' para finalizar): ");
            if (!int.TryParse(Console.ReadLine(), out int idPlat) || idPlat == 0) break;

            var platillo = menu.FirstOrDefault(p => p.IdPlatillo == idPlat);
            if (platillo == null)
            {
                MostrarError("ID de platillo no válido. Intente de nuevo.");
                continue;
            }

            Console.Write($"Cantidad para '{platillo.Nombre}': ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
            {
                MostrarError("Cantidad no válida.");
                continue;
            }

            decimal subtotal = platillo.Precio * cantidad;
            detalles.Add(new DetallePedido(0, 0, idPlat, cantidad, subtotal));
            Console.WriteLine($"Agregado: {platillo.Nombre} x{cantidad} = ${subtotal}");
        }

        return detalles;
    }

    private static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }

    private static void MostrarExito(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
}
