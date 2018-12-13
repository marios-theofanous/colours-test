using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ColoursTest.Models;
using Dapper;

namespace ColoursTest.Repositories
{
    public class ColourRepository : IColourRepository
    {
        public IEnumerable<Colour> Read(IDbConnection connection)
        {
            const string sql = @"SELECT * FROM Colours";
            return connection.Query<Colour>(sql);
        }
    }
}