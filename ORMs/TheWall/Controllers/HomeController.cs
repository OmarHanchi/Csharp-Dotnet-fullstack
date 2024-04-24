using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace TheWall.Controllers;

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

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if(ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Dashboard");
        } else {
            return View("Index");
        }
    }

    [HttpPost("users/login")]
    public IActionResult LoginUser(LogUser returningUser)
    {
        if(ModelState.IsValid)
        {
            User? userInDB = _context.Users.FirstOrDefault(u => u.Email == returningUser.LogEmail);
            if(userInDB == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid login attempt");
                return View("Index");
            }
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
            var result = hasher.VerifyHashedPassword(returningUser, userInDB.Password, returningUser.LogPassword);
            if(result == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid login attempt");
                return View("Index");
            }
            HttpContext.Session.SetInt32("UserId", userInDB.UserId);
            return RedirectToAction("Dashboard");
        } else {
            return View("Index");
        }
    }

    [SessionCheck]
    [HttpGet("messages")]
    public IActionResult Dashboard()
    {
        ViewBag.Error = 0;
        MyViewModel MyModel = new MyViewModel()
        {
            LoggedInUser = _context.Users.FirstOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId")),
            AllMessages = _context.Messages.Include(w => w.Writer).Include(c => c.CommentsOnMessage).ThenInclude(c => c.Commenter).OrderByDescending(a => a.CreatedAt).ToList()
        };
        return View(MyModel);
    }

    [HttpPost("comments/create/{MessageId}")]
    public IActionResult CreateComment(Comment newComment, int MessageId)
    {
        if(ModelState.IsValid)
        {
            newComment.UserId = (int)HttpContext.Session.GetInt32("UserId");
            newComment.MessageId = MessageId;
            _context.Add(newComment);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        } else {
            ViewBag.Error = MessageId;
            MyViewModel MyModel = new MyViewModel()
            {
                LoggedInUser = _context.Users.FirstOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId")),
                AllMessages = _context.Messages.Include(w => w.Writer).Include(c => c.CommentsOnMessage).ThenInclude(c => c.Commenter).OrderByDescending(a => a.CreatedAt).ToList()
            };
            return View("Dashboard", MyModel);
        }
    }

    [SessionCheck]
    [HttpPost("messages/create")]
    public IActionResult CreateMessage(Message newMessage)
    {
        if(ModelState.IsValid)
        {
            newMessage.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(newMessage);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        } else {
            MyViewModel MyModel = new MyViewModel()
            {
                LoggedInUser = _context.Users.FirstOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId")),
                AllMessages = _context.Messages.Include(w => w.Writer).Include(c => c.CommentsOnMessage).ThenInclude(c => c.Commenter).OrderByDescending(a => a.CreatedAt).ToList()
            };
            return View("Dashboard", MyModel);
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if(userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}