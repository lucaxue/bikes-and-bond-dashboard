using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
using System.Numerics;

public class MissionRepository : BaseRepository, IRepository<Mission>
{

    public MissionRepository(IConfiguration configuration) : base(configuration) { }

    public IEnumerable<Mission> GetAll()
    {
        using var connection = CreateConnection();
        IEnumerable<Mission> missions = connection.Query<Mission>("SELECT * FROM Missions;");
        return missions;
    }

    public async Task<Mission> Get(int id)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Mission>("SELECT * FROM Missions WHERE id = @ID;", new { ID = id });

    }

    // public async Task<Mission> Insert(Mission missionObject)
    // {
    //     using var connection = CreateConnection();
    //     return await connection.QuerySingleAsync<<Mission>>("INSERT INTO Missions (Title, Artist, SongLengthCode, Link, SuggestedBy) VALUES (@Title, @Artist, @SongLengthCode, @Link, @SuggestedBy); SELECT * FROM Missions LIMIT 1;", missionObject);
    // }

    // public async Task<Mission> Update(Mission aMission)
    // {
    //     using var connection = CreateConnection();
    //     return await connection.QuerySingleAsync<Mission>("UPDATE Missions SET Title = @Title, Artist = @Artist, SongLengthCode = @SongLengthCode, Link = @Link, SuggestedBy = @SuggestedBy WHERE Id = @Id;", aMission);
    // }
}