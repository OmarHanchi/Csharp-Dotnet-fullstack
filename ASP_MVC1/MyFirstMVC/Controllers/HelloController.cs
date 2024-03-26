using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers;
public class HelloController : Controller 
{
    [HttpGet ]
    [Route("")]
    public string Index ()
    {
       return "Hello world from Index ";
    }
    [HttpGet("greet/{name}")]
    public string Greet (string name)
    {
        return $"Hello  {name}";
    }
}