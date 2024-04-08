using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        string message = " hello hello hello  hello hello hello hello hello hello ";
        return View("Index",message);
    }

    [HttpGet("nmbers")]
    public IActionResult Numbers()
    {
        List<int> SomeNumbers = new List<int>() {1,2,3,8,9,10,99};
        return View(SomeNumbers);
    }
     [HttpGet("user")]
    public IActionResult User()
    {
        User MyUser=new User()
        {
            FirstName="Omar",
            LastName="Hanchi"
        };
        return View("User",MyUser);
    }
     [HttpGet("users")]
    public IActionResult Users()
    {
        List<User> ListOfUsers = new List<User>(){
            new User(){FirstName="naruto",LastName="uzumaki"},
            new User(){FirstName="kakashi",LastName="sensei"},
            new User(){FirstName="sasuki",LastName="uchiha"}

        
        
        };
        return View(ListOfUsers);
    }

   

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
