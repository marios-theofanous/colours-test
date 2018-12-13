using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ColoursTest.Models;

namespace ColoursTest.Services
{
    public interface IPeopleService
    {
        IEnumerable<Person> Get();
        void Post(Person person);
        void Update(Person person);
    }
}