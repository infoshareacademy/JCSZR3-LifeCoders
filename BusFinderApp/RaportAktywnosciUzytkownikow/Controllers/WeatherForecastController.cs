using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RaportAktywnosciUzytkownikow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaportAktywnosciUzytkownikow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static List<User> users = new List<User>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Past([FromBody] User user)
        {
            users.Add(user);
            return Ok(user);
        }
    }
}
