using System.Diagnostics;
using Microsoft.AspNetCore.Identity; // Consider using Identity for robust user management
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models; // Replace with your models namespace
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace LoginAndRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }



        //*================ Registration with password hashing =============

        public IActionResult Index()
        {
            return View();
        }


        //*================ Registration with password hashing =============
        [HttpPost("users/create")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                // Password hashing (consider using Identity for built-in hashing)
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);

                _context.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            else
            {
                return View("Index");
            }
        }


        
        //*================ Redirecting to success view =============

        [SessionCheck] // Custom attribute for session check
        [HttpGet("Success")]
        public IActionResult Success()
        {
            return View();
        }


        
        //*================ Logout Action =============
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }




        //*================ Login Action  =============
        [HttpPost("users/login")]
        public IActionResult Login(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);

                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }

                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);

                if (result == PasswordVerificationResult.Success)
                {
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId); // Set session with user ID
                    return RedirectToAction("Success");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }






    //*================ Session check attribute  =============
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
