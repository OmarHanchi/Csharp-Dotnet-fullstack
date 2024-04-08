using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LogReg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LogReg.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

 private MyContext _context;         
    
    public HomeController(ILogger<HomeController> logger, MyContext context)    
    {        
        _logger = logger;
        
        _context = context;    
    }         
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("user/create")]
    public IActionResult CreateUser (User newUser) 
    {
        if (ModelState.IsValid)
        {
            //*hashing password 
            PasswordHasher<User> Hasher= new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser,newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId",newUser.UserId);


            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }
    [HttpGet ("Success")]
    public IActionResult Success ()
    {
        if (HttpContext.Session.GetInt32("UserId")== null)
        {
            return RedirectToAction ("Index");
        }
        return View ();
    }


    [HttpPost("/logout")]
    public IActionResult Logout ()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost("user/login")]
    public IActionResult LoginUser (User loginUser )
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Success");
        }
        else 
        {
            return View ("Index");
        }
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
public class SessionCheckAttribute : ActionFilterAttribute 
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            context.Result = new RedirectToActionResult("Index","Home", null);
        }
        
    }
} 
