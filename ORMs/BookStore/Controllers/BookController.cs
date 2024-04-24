using Microsoft.AspNetCore.Mvc;
using BookStore.Models;

namespace BookStore.Controllers;

public class BookController : Controller
{    
    private readonly MyContext _context;
    public BookController( MyContext context)
    {        
        _context = context;    
    }  
    public IActionResult Index()
    {
        return View();
    }
}    