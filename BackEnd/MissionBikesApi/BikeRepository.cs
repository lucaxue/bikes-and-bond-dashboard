using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
using System.Numerics;

public class BikeRepository : BaseRepository, IRepository<Bike>
{

    public BikeRepository(IConfiguration configuration) : base(configuration) { }

    public IEnumerable<Bike> Search(string search)
    {
        using var connection = CreateConnection();
        IEnumerable<Bike> bikes = connection.Query<Bike>("SELECT * FROM Bikes WHERE Genre ILIKE @Search OR Author ILIKE @Search OR Title ILIKE @Search OR Color ILIKE @Search;", new { Search = $"%{search}%" });
        return bikes;
    }

    public IEnumerable<Bike> GetAll()
    {
        using var connection = CreateConnection();
        IEnumerable<Bike> bikes = connection.Query<Bike>("SELECT * FROM Bikes;");
        return bikes;
    }

    public async Task<Bike> Get(int id)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Bike>("SELECT * FROM Bikes WHERE id = @ID;", new { ID = id });

    }

    public async Task<Bike> Insert(Bike bikeObject)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Bike>("INSERT INTO Bikes (Title, Artist, SongLengthCode, Link, SuggestedBy) VALUES (@Title, @Artist, @SongLengthCode, @Link, @SuggestedBy); SELECT * FROM Songs LIMIT 1;", bikeObject);
    }

    public async Task<Bike> Update(Bike aBike)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Bike>("UPDATE Bikes SET Title = @Title, Artist = @Artist, SongLengthCode = @SongLengthCode, Link = @Link, SuggestedBy = @SuggestedBy WHERE Id = @Id;", aBike);
    }
}