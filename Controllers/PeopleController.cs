using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IFavouriteColourService _favouriteColourService;

        public PeopleController(IPeopleService peopleService, IFavouriteColourService favouriteColourService)
        {
            _peopleService = peopleService;
            _favouriteColourService = favouriteColourService;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _peopleService.Get();
        }

        [HttpPost]
        public void Post([FromBody] Person person)
        {
            _peopleService.Post(person);
        }

        [HttpPut]
        public void Update([FromBody] Person person)
        {
            _peopleService.Update(person);
        }
    }
}