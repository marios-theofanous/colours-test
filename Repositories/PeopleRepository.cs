using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using ColoursTest.Models;
using Dapper;

namespace ColoursTest.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        public IEnumerable<Person> Read(IDbConnection connection)
        {
            var tempStorage = new Dictionary<int, Person>();

            return connection.Query<Person, Colour, Person>(
                    @"SELECT * 
                          FROM People p 
                          INNER JOIN FavouriteColours fc ON p.PersonId = fc.PersonId 
                          INNER JOIN Colours c ON fc.ColourId = c.ColourId",
                    (person, colour) =>
                    {
                        if (!tempStorage.TryGetValue(person.PersonId, out var personEntry))
                        {
                            personEntry = person;
                            personEntry.FavouriteColours = new List<Colour>();
                            tempStorage.Add(person.PersonId, personEntry);
                        }

                        personEntry.FavouriteColours.Add(colour);
                        return personEntry;
                    }, splitOn: "PersonId, ColourId")
                .Distinct()
                .ToList();
        }

        public void Create(Person person)
        {
            throw new NotImplementedException();
            // To be implemented
//            const string sql = @"INSERT [dbo].[People] (
//                        [FirstName], [LastName], [IsAuthorised], [IsValid], [IsEnabled]) 
//                        VALUES (@FirstName, @LastName, @IsAuthorised, @IsValid, @IsEnabled)";
//
//            using (var connection = new SqlConnection(ConnectionString))
//            {
//                var affectedLines = connection.Execute(sql, person);
//            }
        }

        public void Update(Person person, IDbConnection connection, IDbTransaction transaction)
        {
            const string sql = @"UPDATE People
                                SET FirstName = @FirstName, LastName = @LastName, IsAuthorised = @IsAuthorised, IsValid = @IsValid, IsEnabled = @IsEnabled
                                WHERE PersonId = @PersonId";

            connection.Execute(sql, person, transaction);
        }
    }
}