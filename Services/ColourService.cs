using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ColoursTest.Models;
using ColoursTest.Repositories;
using Microsoft.Extensions.Configuration;

namespace ColoursTest.Services
{
    public class ColourService : IColourService
    {
        private readonly IColourRepository _colourRepository;
        private readonly string _connectionString;

        public ColourService(IColourRepository colourRepository, IConfiguration configuration)
        {
            _colourRepository = colourRepository;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Colour> Get()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _colourRepository.Read(connection);
            }
        }
    }
}