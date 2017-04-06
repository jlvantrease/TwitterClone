using Tweet;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Tweet
{
    [Route("api/[controller]")]

    public class TweetController : Controller
    {
        [HttpGet("{all}")]
        public IEnumerable<Tweet> List()
        {
            return new List<Tweet>
            {
                new Tweet{ TweetID = 1, TweetOwner = 1, Message = "first tweet" }
            };
        }
        /* 
        [HttpGetAttribute("{id}")]
        public IActionResult UserDetails(Guid id)
        {
            return Ok(new User{FirstName = "Test", LastName = "Test", Email = "test@a.com"});
        }
        
        [HttpPost("")]
        public IActionResult CreateUser(string firstName, string lastName, string email)
        {
            //new User{FirstName = firstName, LastName = lastName, Email = email};
            return Created(new Uri("/firstname = firstName"),new User{FirstName = firstName, LastName = lastName, Email = email});
        }
        */    
    }
    
}
