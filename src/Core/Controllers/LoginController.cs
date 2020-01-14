using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LibraCoffee.Core.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            return Ok(new string[] { "cxy", "ctr" });
        }
    }
}