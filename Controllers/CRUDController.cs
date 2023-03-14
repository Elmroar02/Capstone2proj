using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.DBContext;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CRUDController : ControllerBase
    {
        
        private readonly DatabaseContext _databaseContext;

        [HttpGet]
        
        public IActionResult GetUsers()
        {
            var users = _databaseContext.Users.ToList();
            return Ok(new { result = users, message = "success"});
        }

        [HttpPost]

        public IActionResult AddUsers(User user)
        {
            var users = _databaseContext.Add(user);
            _databaseContext.SaveChanges();
            return Ok(new { message = "success"});
        }

        [HttpPut]

        public IActionResult UpdateUsers(User user)
        {
            var users = _databaseContext.Update(user);
            _databaseContext.SaveChanges();
            return Ok(new { message = "success"});
        }
        
        [HttpDelete("{id}")]

        public IActionResult DeleteUsers(int id)
        {
            var user = _databaseContext.Users.SingleOrDefault(o => o.Id == id);
            if(user != null){
                var users = _databaseContext.Remove(user);
                _databaseContext.SaveChanges();
            }
            return Ok(new { message = "success"});
        }
    }
}
