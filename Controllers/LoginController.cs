using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using webapi.DBContext;
using webapi.Models;
using Models;
//using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        public LoginController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> LoginUser(Login User)
        {
            var findUser = _dbContext.Users
            .Where(e => e.Username == User.Username && e.Password == User.Password)
            .FirstOrDefault();

        if (_dbContext.Users != null)
        {
            if (findUser == null)
            {
                return BadRequest(new { message = "Invalid"});

            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, User.Username),
                new Claim(ClaimTypes.Name, User.Username)
            };
            ClaimsIdentity ci = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal cp = new ClaimsPrincipal(ci);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, cp);

        return StatusCode(200, new { message = "Logged in" });
    }   
        else{
        return BadRequest(new { message = "No credential"});
    }

    
    }
    
    }
}