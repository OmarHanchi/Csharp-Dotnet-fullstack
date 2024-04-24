using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;

namespace ChefsDishes.Controllers;

public class HomeController : Controller
{    
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;         
    public HomeController(ILogger<HomeController> logger, MyContext context)    
    {        
        _logger = logger;
        _context = context;    
    }      


    public IActionResult Chefs()
    {
        return View();
    }


    [HttpPost("Chefs/create")]
    public IActionResult CreateChef (Chef newChef)
    {    
        if(ModelState.IsValid)
        {
            _context.Add(newChef);    
            _context.SaveChanges();
            return RedirectToAction("Chefs");
        } 
        else 
        {
            return View ("ChefForm");    
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
