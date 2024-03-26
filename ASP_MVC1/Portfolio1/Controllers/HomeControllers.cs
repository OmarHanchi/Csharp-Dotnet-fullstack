using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers;
public class HomeController : Controller 
{
    [HttpGet ]
    [Route("")]
    public string Index ()
    {
       return "Hello world from Index ";
    }
    [HttpGet("projects")]
    public string Projects ()
    {
        return "These are my projects";
    }
    [HttpGet ("contact")]
    public string Contact () 
    {
        return "This is my contact " ; 
    } 
}