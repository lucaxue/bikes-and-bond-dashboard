using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

public class BaseRepository
{
    IConfiguration _configuration;

    public BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    // Generate new connection based on connection string
    private NpgsqlConnection SqlConnection()
    {
        var stringBuilder = new NpgsqlConnectionStringBuilder
        {
            Host = _configuration["PGHOST"],
            Database = _configuration["PGDATABASE"],
            Username = _configuration["PGUSER"],
            Port = Int32.Parse(_configuration["PGPORT"]),
            Password = _configuration["PGPASSWORD"],
            SslMode = SslMode.Require, // heroku specific setting https://stackoverflow.com/questions/37276821/connecting-to-heroku-postgres-database-with-asp-net
            TrustServerCertificate = true // heroku specific setting 
        };
        return new NpgsqlConnection(stringBuilder.ConnectionString);
    }

    // Open new connection and return it for use
    public IDbConnection CreateConnection()
    {
        var conn = SqlConnection();
        conn.Open();
        return conn;
    }
}

//  var stringBuilder = new NpgsqlConnectionStringBuilder
//         {
//             Host = "ec2-99-81-238-134.eu-west-1.compute.amazonaws.com", // e.g. ec2-1-2-3-4@eu-west-1.compute.amazonaws.com
//             Database = "ded4bdlpifphol", // e.g. ksdjfhsafnfas
//             Username = "syotqorcuaxgfr", // e.g. lksfhdslkfsdflk
//             Password = "3ea6c399b6a794be1b653659e2470d9ead6155381a6f3142fe133cdc880445ef",// e.g KJZDldfj34567dslkfjsdlfksdjflsdkfjsdlkfjsdl34567fkjdsgDRTYUI
//             Port = 5432, // e.g 5432
//             SslMode = Npgsql.SslMode.Require, // Heroku Specific Setting
//             TrustServerCertificate = true // Heroku Specific Setting
//         };