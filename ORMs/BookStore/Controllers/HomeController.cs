using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Controllers;

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
        return View();
    }


    [HttpPost(template: "users/create")]   
    public IActionResult CreateUser(User newUser)    
    {        
        if(ModelState.IsValid)        
        {
            // Initializing a PasswordHasher object, providing our User class as its type            
            PasswordHasher<User> Hasher = new PasswordHasher<User>();   
            // Updating our newUser's password to a hashed version         
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);            
            //Save your user object to the database 
            _context.Add(newUser);
            _context.SaveChanges();  
            return RedirectToAction("Success");
                        
        } else {
            return View ("Index");     
        }   
    }


    public IActionResult Success()
    {
        return View("Success"); 
    }



    [HttpPost(template: "users/login")]   
    public IActionResult Login(LoginUser userSubmission)
    {
    if (ModelState.IsValid)
    {
        // If initial ModelState is valid, query for a user with the provided email
        User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);

        // If no user exists with the provided email
        if (userInDb == null)
        {
        // Add an error to ModelState and return to View!
        ModelState.AddModelError("Email", "Invalid Email/Password");
        return View("Index");
        }

        // Otherwise, we have a user, now we need to check their password
        // Initialize hasher object
        PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

        // Verify provided password against hash stored in db
        var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);

        // Result can be compared to 0 for failure
        if (result == 0)
        {
        // Handle failure (this should be similar to how "existing email" is handled)
        ModelState.AddModelError("Password", "Invalid Email/Password"); // Add specific error for password
        return View("Index"); // Return to the login view with errors
        }

        // Handle success (this should route to an internal page)
        //  Here you would typically redirect to a success page 
        return RedirectToAction("Index","Book"); // Example redirect to a Success action
    }
    else
    {
        // Handle else (ModelState is not valid)
        //  Here you would typically return the view with the validation errors
        return View("Index");
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
