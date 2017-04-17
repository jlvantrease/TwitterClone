using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CoreUser
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        //TODO: add query parameters
        [HttpGet("Users")]
        public IEnumerable<User> List(int id)
        {
            //UserMem mem = new UserMem();
            return UserMem.All();
        }
        
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {   
            return Ok(UserMem.FindById(id));
        }
        
        [HttpPost("create")]
        public IActionResult Create([FromBody]User user)//int id, string firstname, string lastname, string email)
        {
            UserMem.Add(user);
            //return CreatedAtAction("Created", user);
            return StatusCode(201);
        } 

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            bool success = UserMem.DeleteById(id);
            if (success != false){
                return NotFound();
            }
            return StatusCode(202);
        }   
    }
}
