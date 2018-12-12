using System;
using System.Collections.Generic;
using ColoursTest.Models;
using ColoursTest.Repositories;

namespace ColoursTest.Services
{
    public class ColourService : IColourService
    {
        private readonly IColourRepository _colourRepository;

        public ColourService(IColourRepository colourRepository)
        {
            _colourRepository = colourRepository;
        }

        public IEnumerable<Colour> Get()
        {
            return _colourRepository.Read();
        }
    }
}