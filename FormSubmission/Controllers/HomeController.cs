using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index ()
    {
        return View();
    }

    [HttpPost ("register")]
    public IActionResult Register( User user)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction ("Success");
        }
        
        return View("Index",user);

        

    }
    [HttpGet("success")]
    public IActionResult Success()
    {
        return View ("Success");
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
