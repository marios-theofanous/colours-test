using System.Collections;
using System.Collections.Generic;
using ColoursTest.Models;
using ColoursTest.Repositories;

namespace ColoursTest.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public IEnumerable<Person> Get()
        {
            return _peopleRepository.Read();
        }

        public bool Post(Person person)
        {
            return _peopleRepository.Create(person);
        }
    }
}