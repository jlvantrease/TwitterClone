using Microsoft.AspNetCore.Mvc;
 
public class RootController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return Ok("I AM GROOT"); 
    }
}
