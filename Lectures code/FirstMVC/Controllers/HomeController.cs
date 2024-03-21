using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static List<Pet> Pets = new List<Pet>();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
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

    /*
    [HttpPost("Process")]
    public IActionResult Process(string Name,string Species,int Age)

    {
        Console.WriteLine($"Name   : {Name}");
        Console.WriteLine($"Species   : {Species}");
        Console.WriteLine($"Age   : {Age}");
        return View("success");
    }
    */
    [HttpPost("Pet/Create")] 
    public IActionResult Create(Pet newPet)
    {
        if(ModelState.IsValid)
        {
            // add that pet 
            Pets.Add(newPet);
            return RedirectToAction("AllPets");
        } else
        {
            return View("Index");
        }

            
    } 


    [HttpGet ("AllPets")]
    public IActionResult AllPets()
    {
        return View ("AllPets",Pets);
    }


    [HttpGet("success")]
    public ViewResult Success()
    {
        return View();
    }
}
