using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

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
            return Ok();//(mem.TweetById(id));
        }
        
        [HttpPost("")]
        public IActionResult CreateUser(Tweet tweet)
        {
            TweetMem.Add(tweet);
            return StatusCode(201);
        }
            
    }
    
}
