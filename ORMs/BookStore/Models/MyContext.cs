#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace BookStore.Models;
public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }    


    //! Don't forget to add all tables here :
    public DbSet<User> Users { get; set; } 
    public DbSet<Book> Books { get; set; } 
    public DbSet<Favourite> Favourites { get; set; } 


}