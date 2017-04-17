using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
 
namespace CoreNotes
{
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        [HttpGet("")]
        public IEnumerable<Note> List(string username)
        {
            return new List<Note>{
                new Note{Title = "Shopping list", Contents="Some Apples"},
                new Note{Title = "Thoughts on .NET Core", Contents="To follow..."}
             };
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            if (id > 1)
            {
                return NotFound();
            }
            return Ok(new Note{Title = "one note", Contents = $"here's a note whose id is... {id}"});
        }

        [HttpGet("ping")]
        public Note Ping()
        {
            return new Note{Title = "pong", Contents = $"pong"};
        }
    }
}
