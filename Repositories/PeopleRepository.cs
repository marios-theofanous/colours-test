using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using ColoursTest.Models;
using Dapper;

namespace ColoursTest.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private const string ConnectionString =
            "user id=sa;password=Password123;Data Source=localhost;Database=TechTest;";

        private readonly Dictionary<int, Person> _tempStorage = new Dictionary<int, Person>();

        public IEnumerable<Person> Read()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Person, Colour, Person>(
                        @"SELECT * 
                          FROM People p 
                          INNER JOIN FavouriteColours fc ON p.PersonId = fc.PersonId 
                          INNER JOIN Colours c ON fc.ColourId = c.ColourId",
                        (person, colour) =>
                        {
                            if (!_tempStorage.TryGetValue(person.PersonId, out var personEntry))
                            {
                                personEntry = person;
                                personEntry.FavouriteColours = new List<Colour>();
                                _tempStorage.Add(person.PersonId, personEntry);
                            }

                            personEntry.FavouriteColours.Add(colour);
                            return personEntry;
                        }, splitOn: "PersonId, ColourId")
                    .Distinct()
                    .ToList();
            }
        }

        public bool Create(Person person)
        {
            throw new NotImplementedException();
            // To be implemented
            const string sql = @"INSERT [dbo].[People] (
                        [FirstName], [LastName], [IsAuthorised], [IsValid], [IsEnabled]) 
                        VALUES (@FirstName, @LastName, @IsAuthorised, @IsValid, @IsEnabled)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var affectedLines = connection.Execute(sql, person);
                return affectedLines == 1;
            }
        }

        public bool Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}