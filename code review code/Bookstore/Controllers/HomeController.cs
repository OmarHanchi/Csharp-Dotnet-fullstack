using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;

namespace Bookstore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;         
    // Here we can "inject" our context service into the constructor 
    // The "logger" was something that was already in our code, we're just adding around it   
    public HomeController(ILogger<HomeController> logger, MyContext context)    
    {        
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context;    
    }         

    public IActionResult Index()
    {
        List<Book> all_Books = _context.Books.ToList();
        return View();
    }
    
    [HttpGet("books/{BookId}")]
    public IActionResult GetOneBook (int bookId)
    {
        Book book = _context.Books.FirstOrDefault(b=>b.Id == BookId);
        return View ("GetOneBook");
    }

    //? Display add book action
    [HttpGet("books/new")]
    public IActionResult AddBookForm()
    {

        return View();   
    }

    //? post request action : Add book form
    [HttpPost]
    public IActionResult AddBook (Book newBook)
    {
        if (ModelState.IsValid )
        {
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return RedirectToAction ("Index");
        
        }
        else
        {
            return View ("AddBookForm");
        }   
    }

    public IActionResult EditBookForm(int ID )
    {
        Book book = _context.Books.FirstOrDefault(b=>b.BookId == ID);
        return View("EditBookForm");
    }


    [HttpGet("books/{ID}/edit")]
    public IActionResult UpdateBook (int bID , Book editBook)

    {
        Book? OldBook = _context.Books.FirstOrDefault(b=>b.BookId == bID);
        OldBook.Title = editBook.Title;
        OldBook.Author = editBook.Author;
        OldBook.PublicationYear = editBook.PublicationYear;
        OldBook.Description = editBook.Description;
        OldBook.IsAvailble = editBook.IsAvailble;
        OldBook.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("GetOneBook");
    }

    public IActionResult DeleteBook (int bookId)
    {
    Book BookToDelete = _context.Books.FirstOrDefault(b=>b.BookId == bID);
    _context.Books.Remove(BookToDelete);
    _context.SaveChanges();
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
