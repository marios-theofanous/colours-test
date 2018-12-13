using System.Data;
using ColoursTest.Models;
using Dapper;

namespace ColoursTest.Repositories
{
    class FavouriteColourRepository : IFavouriteColourRepository
    {
        private const string InsertSql = @"INSERT INTO FavouriteColours 
                                       (PersonId, ColourId) 
                                       VALUES (@PersonId, @ColourId);";

        private const string DeleteSql = @"DELETE FROM favouritecolours
                        WHERE PersonId = @personId";

        public void UpdateColoursForPerson(Person person, IDbConnection connection, IDbTransaction transaction)
        {
            DeleteColoursForPersonId(person.PersonId, connection, transaction);
            foreach (var colour in person.FavouriteColours)
            {
                InsertColourForPersonId(person.PersonId, colour.ColourId, connection, transaction);
            }
        }

        private int InsertColourForPersonId(int personId, int colourId, IDbConnection connection,
            IDbTransaction transaction)
        {
            return connection.Execute(InsertSql, new {PersonId = personId, ColourId = colourId}, transaction);
        }

        private static int DeleteColoursForPersonId(int personId, IDbConnection connection, IDbTransaction transaction)
        {
            return connection.Execute(DeleteSql, new {personId}, transaction);
        }
    }
}