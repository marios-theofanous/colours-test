using System.Collections;
using System.Collections.Generic;
using ColoursTest.Models;

namespace ColoursTest.Services
{
    public interface IColourService
    {
        IEnumerable<Colour> Get();
    }
}