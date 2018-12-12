using System.Collections.Generic;
using ColoursTest.Models;

namespace ColoursTest.Repositories
{
    public interface IColourRepository
    {
        IEnumerable<Colour> Read();
    }
}