using System.Data;
using Dapper;
using FoodCampus.Application.Interfaces;
using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Mappers;
using FoodCampus.Infrastructure.Models;

namespace FoodCampus.Infrastructure.Repositories;

/// <summary>
/// Implementación Dapper del repositorio de Restaurantes.
/// </summary>
public class RestauranteRepository(IDbConnection connection) : IRestauranteRepository
{
    private readonly IDbConnection _connection = connection;

    public async Task<IEnumerable<Restaurante>> ObtenerTodosAsync()
    {
        const string sql = "SELECT * FROM Restaurante";
        var dbos = await _connection.QueryAsync<RestauranteDbo>(sql);
        return dbos.ToDomainList();
    }

    public async Task<int> InsertarAsync(Restaurante restaurante)
    {
        const string sql = @"
            INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre)
            VALUES (@Nombre, @Especialidad, @HorarioApertura, @HorarioCierre);
            SELECT SCOPE_IDENTITY();";

        var dbo = restaurante.ToDbo();
        return await _connection.ExecuteScalarAsync<int>(sql, dbo);
    }
}
