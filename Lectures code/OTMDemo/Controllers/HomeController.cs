using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OTMDemo.Models;

namespace OTMDemo.Controllers;

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
        MyViewModel MyModel = new MyViewModel
        {
            AllOwners = _context.Owners.ToList()
        };
        return View();
    }

    [HttpPost("owner/add")]
    public IActionResult OwnerAdd (Owner newOwner)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newOwner);
            _context.SaveChanges();
            return RedirectToAction ("Index");
        }
        else
        {
            ViewBag.AllOwners = _context.Owners.ToList();
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
