using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
//using System.Data.SqlClient;

namespace ViewController
{

    public class ViewController : Controller
    {
        [Route("home/tweets")]
        public IActionResult Tweets(){
            return View();
        }

    }
    
}