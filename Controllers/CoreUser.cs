using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CoreUser
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet("")]
        public IEnumerable<User> List(int id)
        {
            UserMem mem = new UserMem();
            return mem.All();
        }
        
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {   
            UserMem mem = new UserMem();
            
            return Ok(mem.UserById(id));
        }
        
        [HttpPostAttribute("create")]
        public User Create()//int id, string firstname, string lastname, string email)
        {
            return new User{ID = 1, FirstName = "create", LastName = "create", Email = "email"};
        } 
            
    }
}
