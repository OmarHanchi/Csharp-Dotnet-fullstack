using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers;
public class HelloController : Controller 
{
    [HttpGet ]
    [Route("")]
    public ViewResult Index ()
    {
       return View ("Index");
    }
}
