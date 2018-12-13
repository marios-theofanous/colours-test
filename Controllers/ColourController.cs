using System.Collections.Generic;
using ColoursTest.Models;
using ColoursTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ColoursTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly IColourService _colourService;

        public ColourController(IColourService colourService)
        {
            _colourService = colourService;
        }

        [HttpGet]
        public IEnumerable<Colour> Get()
        {
            return _colourService.Get();
        }
    }
}