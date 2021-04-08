using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
public class BikeRepository : BaseRepository, IRepository<Bike>
{

  public BikeRepository(IConfiguration configuration) : base(configuration) { }

  public async Task<IEnumerable<Bike>> GetAll()
  {
    using var connection = CreateConnection();
    return await connection.QueryAsync<Bike>("SELECT * FROM Bikes;");

  }

  public async Task<Bike> Get(long id)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<Bike>("SELECT * FROM Bikes WHERE Id = @Id;", new { Id = id });
  }

  public void Delete(long id)
  {
    using var connection = CreateConnection();
    connection.Execute("DELETE FROM Bikes WHERE Id = @Id;", new { Id = id });
  }

  public async Task<Bike> Update(Bike bike)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<Bike>("UPDATE Bikes SET Genre = @Genre, Author = @Author, Color = @Color, Title = @Title WHERE Id = @Id RETURNING *", bike);
  }

  public async Task<Bike> Insert(Bike bike)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<Bike>("INSERT INTO Bikes (Genre, Author, Color, Title) VALUES (@Genre, @Author, @Color, @Title) RETURNING *;", bike);
  }

  public async Task<IEnumerable<Bike>> Search(string query, int limit, int page)
  {
    using var connection = CreateConnection();
    return await connection.QueryAsync<Bike>("SELECT * FROM Bikes WHERE Genre ILIKE @Query OR Author ILIKE @Query OR Title ILIKE @Query OR Color ILIKE @Query LIMIT @Limit OFFSET @Offset;", new { Query = $"%{query}%", Limit = limit, Offset = (page - 1) * limit });
  }
}

