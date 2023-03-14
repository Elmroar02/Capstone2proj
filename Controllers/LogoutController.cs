using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using webapi.DBContext;
//using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        public LogoutController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    public async Task<IActionResult> LogoutUser()
    {
        await HttpContext.SignOutAsync();
        return StatusCode(200, new { message = "Logout Successfully"});
    }
        
    }
}