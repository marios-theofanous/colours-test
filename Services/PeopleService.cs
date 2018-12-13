using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ColoursTest.Models;
using ColoursTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ColoursTest.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IFavouriteColourService _favouriteColourService;
        private readonly string _connectionString;

        public PeopleService(IPeopleRepository peopleRepository, IFavouriteColourService favouriteColourService,
            IConfiguration configuration)
        {
            _peopleRepository = peopleRepository;
            _favouriteColourService = favouriteColourService;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Person> Get()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _peopleRepository.Read(connection);
            }
        }

        public Person Update(Person person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    _peopleRepository.Update(person, connection, transaction);
                    _favouriteColourService.UpdateColoursForPerson(person, connection, transaction);

                    transaction.Commit();
                }
                return person;
            }
        }
    }
}