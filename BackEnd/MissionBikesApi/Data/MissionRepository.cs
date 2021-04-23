using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
public class MissionRepository : BaseRepository, IRepository<Mission>
{

  public MissionRepository(IConfiguration configuration) : base(configuration) { }

  public async Task<IEnumerable<Mission>> GetAll()
  {
    using var connection = CreateConnection();
    return await connection.QueryAsync<Mission>("SELECT * FROM Missions;");

  }

  public async Task<Mission> Get(long id)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<Mission>("SELECT * FROM Missions WHERE Id = @Id;", new { Id = id });
  }

  public void Delete(long id)
  {
    using var connection = CreateConnection();
    connection.Execute("DELETE FROM Missions WHERE Id = @Id;", new { Id = id });
  }

  public async Task<Mission> Update(Mission mission)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<Mission>("UPDATE Missions SET Name = @Name, Location = @Location, Difficulty = @Difficulty, Task = @Task, Villain = @Villain WHERE Id = @Id RETURNING *", mission);
  }

  public async Task<Mission> Insert(Mission mission)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<Mission>("INSERT INTO Missions (Name, Location, Difficulty, Task, Villain) VALUES (@Name, @Location, @Difficulty, @Task, @Villain) RETURNING *;", mission);
  }

  public async Task<IEnumerable<Mission>> Search(string query, int limit, int page)
  {
    using var connection = CreateConnection();
    return await connection.QueryAsync<Mission>("SELECT * FROM Missions WHERE Name ILIKE @Query OR Location ILIKE @Query OR Difficulty::TEXT ILIKE @Query OR Task ILIKE @Query OR Villain ILIKE @Query LIMIT @Limit OFFSET @Offset;", new { Query = $"%{query}%", Limit = limit, Offset = (page - 1) * limit });
  }
}

