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
            
            // Servicios de Aplicación
            .AddScoped<IRestauranteService, RestauranteService>()
            .AddScoped<IPedidoService, PedidoService>()
            
            // Rigor C# 14: Registro de genéricos no vinculados (Demostración)
            // .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            
            .BuildServiceProvider();

        var restauranteService = serviceProvider.GetRequiredService<IRestauranteService>();
        var pedidoService = serviceProvider.GetRequiredService<IPedidoService>();

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
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");
    }

    private static async Task RegistrarRestauranteUI(IRestauranteService service)
    {
        Console.WriteLine("\n--- NUEVO RESTAURANTE ---");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Especialidad: ");
        string especialidad = Console.ReadLine() ?? "";
        
        // El dominio valida el nombre vía 'field' en el servicio si se envían valores nulos/vacíos
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
        int idRest = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("ID Usuario: ");
        int idUser = int.Parse(Console.ReadLine() ?? "0");

        var pedido = new Pedido(0, idUser, DateTime.Now, 15.00m);
        
        var detalles = new List<DetallePedido>
        {
            new DetallePedido(0, 0, 1, 2, 100.00m),
            new DetallePedido(0, 0, 2, 1, 50.00m)
        };

        int idPedido = await service.CrearPedidoCompletoAsync(idRest, pedido, detalles);
        MostrarExito($"Pedido Maestro-Detalle creado exitosamente con ID: {idPedido}");
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
