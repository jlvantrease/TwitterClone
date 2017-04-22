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
            UserSql userSql = new UserSql();
            return userSql.All();
        }
        
        // Query user by id
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {   
            UserSql userSql = new UserSql();
            
            User user = userSql.FindById(id);

            if(user == null){
                return StatusCode(404,"User not found");
            }
            
            return Ok(user);
        }
        
        //Create User
        [HttpPost("create")]
        public IActionResult Create([FromBody]User user)
        {
            UserSql userSql = new UserSql();
            
            bool success =  userSql.Add(user);
            if(success != true){
                return BadRequest();
            }
            
            return StatusCode(201, user);
        } 

        // Delete User by id
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            UserSql userSql = new UserSql();
            bool success = userSql.DeleteById(id);
            
            if (success == false){
                return StatusCode(404,"User not found");
            }
            
            return Ok("User deleted");
        }

        //Update User by id 
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody]User user )
        {
            UserSql userSql = new UserSql();
            var u = userSql.UpdateById(id, user);
            if(u == null){
                return StatusCode(404);
            }
            return Ok("User (id = "  + id +") updated");
        }  
    }
}
