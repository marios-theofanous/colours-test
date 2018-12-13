using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ColoursTest.Models;

namespace ColoursTest.Services
{
    public interface IFavouriteColourService
    {
        void UpdateColoursForPerson(Person person, IDbConnection connection, IDbTransaction transaction);
    }
}