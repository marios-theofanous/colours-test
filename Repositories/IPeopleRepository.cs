using System.Collections.Generic;
using System.Data;
using ColoursTest.Models;

namespace ColoursTest.Repositories
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> Read(IDbConnection connection);
        void Create(Person person);
        void Update(Person person, IDbConnection connection, IDbTransaction transaction);
    }
}