using Microsoft.AspNetCore.Mvc;

public class PortfolioController : Controller 
{
    [HttpGet("")]
    public IActionResult Home()
    {
        return View ();
    }
    [HttpGet()]
    public IActionResult Projects ()
    {
        List<Dictionary<string,string>>
        return View ();
    }
}
