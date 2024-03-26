using Microsoft.AspNetCore.Mvc;

namespace RazorFun.Controllers;
public class RazorFun : Controller
{
    [HttpGet ("")]
    public IActionResult Index()
    {
        return View ("Index");
    }
}