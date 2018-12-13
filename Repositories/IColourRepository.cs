using System.Collections.Generic;
using System.Data;
using ColoursTest.Models;

namespace ColoursTest.Repositories
{
    public interface IColourRepository
    {
        IEnumerable<Colour> Read(IDbConnection connection);
    }
}