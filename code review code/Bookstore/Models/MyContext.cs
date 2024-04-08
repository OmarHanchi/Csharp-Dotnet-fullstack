#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace Bookstore.Models;   //*we can type using Bookstore.Models;

public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }    
    
    public DbSet<Book> Books { get; set; } 
}
