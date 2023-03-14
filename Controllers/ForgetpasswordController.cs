using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using webapi.DBContext;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetpasswordController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        public ForgetpasswordController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Forget(Forgot User)
        {
            var findUser = _dbContext.Users
            .Where(e => e.Username == User.Username && e.Meal == User.Meal)
            .FirstOrDefault();

        if (_dbContext.Users != null)
        {
            if (findUser == null){
                return BadRequest( new { message = "Invalid ID"});
            }
            return StatusCode(200, new { Password = findUser.Password});
        }
        else{
            return BadRequest( new { message = "No Data"});
        }
    }
}
}