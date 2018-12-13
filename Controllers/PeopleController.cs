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
        public IActionResult Get()
        {
            return Ok(_peopleService.Get());
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            return Ok(_peopleService.Update(person));
        }
    }
}