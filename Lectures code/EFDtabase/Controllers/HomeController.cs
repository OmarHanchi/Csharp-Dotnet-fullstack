using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFDtabase.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EFDtabase.Controllers;

public class HomeController : Controller
{
     
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;    

    public HomeController(ILogger<HomeController> logger, MyContext context)    
    {        
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context;    
    }    

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("song/create")]
    public IActionResult CreateSong(Song newSong)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newSong);
            _context.SaveChanges();
            // Redirect to another action or view upon successful submission
            return RedirectToAction("Index");
        }
        // If model state is not valid, return the view with the model to display validation errors
        return View("Index", newSong);
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
