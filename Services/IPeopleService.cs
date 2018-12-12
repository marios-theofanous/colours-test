using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ColoursTest.Models;

namespace ColoursTest.Services
{
    public interface IPeopleService
    {
        IEnumerable<Person> Get();
        bool Post(Person person);
    }
}