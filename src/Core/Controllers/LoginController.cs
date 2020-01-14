using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LibraCoffee.Entities.Models;
using LibraCoffee.Services;

namespace LibraCoffee.Core.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;
        public LoginController(ICoffeeRepository coffeeRepository){
_coffeeRepository = coffeeRepository;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            IEnumerable<Coffee> coffees = _coffeeRepository.GetAsync().Result;
            return Ok(new string[] { "cxy", "ctr" });
        }
    }
}