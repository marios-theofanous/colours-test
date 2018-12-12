using System;
using System.Collections.Generic;
using ColoursTest.Models;
using ColoursTest.Repositories;
using ColoursTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ColoursTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _peopleService.Get();
        }

        [HttpPost]
        public bool Post([FromBody] Person person)
        {
            return _peopleService.Post(person);
        }
    }
}