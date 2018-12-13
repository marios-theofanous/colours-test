using System.Collections.Generic;
using System.Data;
using ColoursTest.Models;
using ColoursTest.Repositories;

namespace ColoursTest.Services
{
    class FavouriteColourService : IFavouriteColourService
    {
        private readonly IFavouriteColourRepository _favouriteColourRepository;

        public FavouriteColourService(IFavouriteColourRepository favouriteColourRepository)
        {
            _favouriteColourRepository = favouriteColourRepository;
        }

        public void UpdateColoursForPerson(Person person, IDbConnection connection, IDbTransaction transaction)
        {
            _favouriteColourRepository.UpdateColoursForPerson(person, connection, transaction);
        }
    }
}