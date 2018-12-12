using System.Collections.Generic;
using ColoursTest.Models;

namespace ColoursTest.Repositories
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> Read();
        bool Create(Person person);
        bool Update(Person person);
    }
}