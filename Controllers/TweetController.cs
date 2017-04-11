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
        [HttpGet("")]
        public IEnumerable<Tweet> List()
        {
            TweetMem mem = new TweetMem();
            return mem.All();
        }
    
        [HttpGetAttribute("{id}")]
        public IActionResult UserDetails(int id)
        {
            TweetMem mem = new TweetMem();
            return Ok(mem.TweetById(id));
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
