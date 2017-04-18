using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CoreUser
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // Get all Users
        [HttpGet("all")]
        public IEnumerable<User> ListAll()
        {
            return UserMem.All();
        }
        
        // Query user by id
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {   
            
            
            return Ok(UserMem.FindById(id));
        }
        
        //Create User
        [HttpPost("create")]
        public IActionResult Create([FromBody]User user)
        {
            bool success =  UserMem.Add(user);
            if(success != true){
                return BadRequest();
            }
            return StatusCode(201, user);
        } 

        // Delete User by id
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            bool success = UserMem.DeleteById(id);
            if (success == false){
                return NotFound();
            }
            return StatusCode(202);
        }   
    }
}