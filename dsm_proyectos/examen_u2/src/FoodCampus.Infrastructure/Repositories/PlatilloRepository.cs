using System.Data;
using Dapper;
using FoodCampus.Application.Interfaces;
using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Mappers;
using FoodCampus.Infrastructure.Models;

namespace FoodCampus.Infrastructure.Repositories;

/// <summary>
/// Implementación Dapper del repositorio de Platillos.
/// </summary>
public class PlatilloRepository(IDbConnection connection) : IPlatilloRepository
{
    private readonly IDbConnection _connection = connection;

    public async Task<IEnumerable<Platillo>> ObtenerPorRestauranteAsync(int idRestaurante)
    {
        const string sql = "SELECT * FROM Platillo WHERE IdRestaurante = @idRestaurante";
        var dbos = await _connection.QueryAsync<PlatilloDbo>(sql, new { idRestaurante });
        return dbos.ToDomainList();
    }

    public async Task<int> InsertarAsync(Platillo platillo)
    {
        const string sql = @"
            INSERT INTO Platillo (IdRestaurante, Nombre, Precio)
            VALUES (@IdRestaurante, @Nombre, @Precio);
            SELECT SCOPE_IDENTITY();";

        var dbo = platillo.ToDbo();
        return await _connection.ExecuteScalarAsync<int>(sql, dbo);
    }

    public async Task<bool> EliminarAsync(int idPlatillo)
    {
        const string sql = "DELETE FROM Platillo WHERE IdPlatillo = @idPlatillo";
        int rowsAffected = await _connection.ExecuteAsync(sql, new { idPlatillo });
        return rowsAffected > 0;
    }
}
