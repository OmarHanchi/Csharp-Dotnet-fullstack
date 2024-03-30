using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;
public class HomeController : Controller 
{
    [HttpGet ("")]
    public IActionResult Index() 
    {
        //* return the index view 
        return View();
    }

    [HttpGet("result")] // Matches the route in the redirect
    public IActionResult Result(UserInfo userInfo)
    {
        if (userInfo != null)
        {
            return View(userInfo); // Pass the model data to the Result.cshtml view
        }
        return View(); // Handle cases where userInfo is null (e.g., display an error message)
    }



    [HttpPost ("result")]
    public IActionResult FormProcess (UserInfo userInfo)
    {
        //*redirect to result page && passing model data to result page 
        return RedirectToAction ("Result", userInfo);
    }


}