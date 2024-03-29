using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers;
public class HomeController : Controller 
{
    
    [HttpGet ("")]
    public IActionResult Index()
        {
            DateTime TargetDate = new DateTime(2024, 4, 1, 10, 0, 0);
            ViewBag.TargetDate = TargetDate; // Set ViewBag.TargetDate
            TimeSpan RemainingTime = TargetDate - DateTime.Now;
            if (RemainingTime <= TimeSpan.Zero)
            {
                ViewBag.CountDownFinished = true;
            }
            else
            {
                ViewBag.CountDownFinished = false;
            }
            string FormattedTime = $"{RemainingTime.Days} Day(s) {RemainingTime.Hours} Hour(s) {RemainingTime.Minutes} Minute(s)";
            ViewBag.FormattedTime = FormattedTime ;
            return View();
        }
}
