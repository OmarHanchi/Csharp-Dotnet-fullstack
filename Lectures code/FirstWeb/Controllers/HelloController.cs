using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;   //? this is a service that brings in our mvc functionality
namespace FirstWeb.Controllers; //? be sure to use your own project namepace
public class HelloController : Controller //! remember inheritance 
{
    // Routing !!
    [HttpGet("")]
    //this goes to localhost : 5XXX/
    [Route("")]
    public string Index()
    {
        return "Hello from controllers";
        [HttpGet("user/more")]
    }
    
    public string User()
        {
            return"more information about user"
        }
        [HttpGet("User/{id}")]

    public string oneUser (int id )
        {
            return $"this user number is {id}";
        } 
} 