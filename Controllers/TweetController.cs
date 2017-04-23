using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Tweet
{
    [Route("api/[controller]")]
    public class TweetController : Controller
    {
        // Get all Tweets
        [HttpGet("all")]
        public IEnumerable<Tweet> List()
        {
            TweetSql tweetSql = new TweetSql();
            return tweetSql.All();
        }
        
        //Get Tweet by id
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {   
            TweetSql tweetSql = new TweetSql();
            Tweet tweet = tweetSql.FindById(id);

            if(tweet == null){
                return StatusCode(404,"Tweet not found");
            }
            return Ok(tweet);
        }
        
        //Create Tweet
        [HttpPost("create")]
        public IActionResult Create([FromBody]Tweet tweet)
        {
            TweetSql tweetSql = new TweetSql();
            bool success = tweetSql.Add(tweet);
            if(success != true){
                return BadRequest();
            }
            return StatusCode(201, "Tweet created");
        }

        // Delete Tweet by id
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            TweetSql tweetSql = new TweetSql();
            bool success = (tweetSql.DeleteById(id));
            
            if(success == false){
                return NotFound();
            }
            return StatusCode(202);
        }    
    }
    
}
