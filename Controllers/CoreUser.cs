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
            //UserMem mem = new UserMem();
            return UserMem.All();
        }
        
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {   
            //UserMem mem = new UserMem();
            return Ok(UserMem.UserById(id));
        }
        
        [HttpPost("create")]
        public IActionResult Create([FromBody]User user)//int id, string firstname, string lastname, string email)
        {
            //UserMem mem = new UserMem();
            UserMem.Add(user);
            return Json(UserMem.All());
        } 

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(UserMem.DeleteById(id));
        }   
    }
}
