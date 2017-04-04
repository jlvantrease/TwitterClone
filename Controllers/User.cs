using User;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace User
{
    [Route("api/[controller]")]

    public class UserController : Controller
    {
        [HttpGet("{all}")]
        public IEnumerable<User> List()
        {
            return new List<User>
            {
                new User{ FirstName = "Jason", LastName = "Vantrease", Email = "jlvantrease@gmail.com" }
            };
        }

        [HttpGetAttribute("{id}")]
        public IActionResult UserDetails(Guid id)
        {
            return Ok(new User{FirstName = "Test", LastName = "Test", Email = "test@a.com"});
        }
        /*
        [HttpPost("")]
        public IActionResult CreateUser(string firstName, string lastName, string email)
        {
            //new User{FirstName = firstName, LastName = lastName, Email = email};
            return Created(new Uri("/firstname = firstName"),new User{FirstName = firstName, LastName = lastName, Email = email});
        }
        */
    }
}
