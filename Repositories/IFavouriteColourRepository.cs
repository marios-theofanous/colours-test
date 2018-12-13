using System.Collections.Generic;
using System.Data;
using ColoursTest.Models;

namespace ColoursTest.Repositories
{
    public interface IFavouriteColourRepository
    {
        void UpdateColoursForPerson(Person person, IDbConnection connection, IDbTransaction transaction);
    }
}