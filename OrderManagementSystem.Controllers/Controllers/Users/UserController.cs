using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Controllers.Controllers.Users
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // POST: /api/users/register
        [HttpPost("register")]
        public IActionResult Register()
        {
            // TODO: Register a new user
            return Ok("User registered");
        }

        // POST: /api/users/login
        [HttpPost("login")]
        public IActionResult Login()
        {
            // TODO: Authenticate and return JWT token
            return Ok("JWT token");
        }
    }
}
