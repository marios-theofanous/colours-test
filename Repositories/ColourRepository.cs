using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using ColoursTest.Models;
using Dapper;

namespace ColoursTest.Repositories
{
    public class ColourRepository : IColourRepository
    {
        private const string ConnectionString =
            "user id=sa;password=Password123;Data Source=localhost;Database=TechTest;";
        
        public IEnumerable<Colour> Read()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string sql = @"SELECT * FROM Colours";
                return connection.Query<Colour>(sql);
            }
        }
    }
}