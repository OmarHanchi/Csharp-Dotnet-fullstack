using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers;
public class HomeController : Controller 
{
    [HttpGet ]
    [Route("")]
    public IActionResult Index ()
    {
       return View();
    }
    [HttpGet("projects")]
    public IActionResult Projects ()
    {
        return View();
    }
    [HttpGet ("contact")]
    public IActionResult Contact () 
    {
        return View() ; 
    } 
}