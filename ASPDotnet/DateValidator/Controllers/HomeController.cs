using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateValidator.Models;

namespace DateValidator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult ValidateDate(DateModel model)
    {
        if (ModelState.IsValid)
        {
            // Date is valid (in the past or null if not required)
            // Process the validated date here
            return RedirectToAction("Success");
        }

        // If validation fails, return the view with validation errors
        return View("Index");
    }
    [HttpGet] 
    public IActionResult Success ()
    {
        return View ();
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
