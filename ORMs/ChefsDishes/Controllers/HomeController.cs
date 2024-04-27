using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

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


    //*============All routes related to chef ================
  public IActionResult Chefs()
{
        ViewBag.AllChefs = _context.Chefs.Include(c => c.CreatedDishes).ToList(); ;
  
  return View();
}




    

    [HttpGet("chefs/new")]
    public IActionResult ChefForm()
    {

        return View();
    }



    [HttpPost("chefs/new/process")]
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





    //*============All routes related to chef ================
    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        ViewBag.AllDishes = _context.Dishes.Include(d => d.Chef).ToList();
        return View();
    }

     [HttpPost("dishes/new/process")]
    public IActionResult CreateDish (Dish newDish)
    {    
        if(ModelState.IsValid)
        {
            _context.Add(newDish);    
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        } 
        else 
        {
            return View ("DishForm");    
        }
    }    

   [HttpGet("dishes/new")]
    public IActionResult DishForm()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View();
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
