using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionDemo.Models;

namespace SessionDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpPost ("Login")]
    public IActionResult Login()
    {
        return RedirectToAction("Privacy");
    }
    [HttpPost ("Logout")]
    public IActionResult Logout ()
    {
        HttpContext.Session.Clear();
        return View ("Index");
    }
    

    public IActionResult Index()
    {
        //! making session 
        HttpContext.Session.SetString("Username","Omar");
        HttpContext.Session.SetInt32("Age",27);
       
       
        return View();
    }



    public IActionResult Privacy()
    {
        string? InSession = HttpContext.Session.GetString ("Username");
        int? NumINSession = HttpContext.Session.GetInt32 ("Age");

        if (InSession == null ) 
        {
            return RedirectToAction("Index");
        }

       
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
