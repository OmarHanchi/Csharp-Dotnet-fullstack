#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace OTMDemo.Models;
public class MyContext : DbContext 
{   
    // This line will always be here. It is what constructs our context upon initialization  
    public MyContext(DbContextOptions options) : base(options) { }    
    
    public DbSet<Pet> Pets { get; set; } 
    public DbSet<Owner> Owners { get; set; } 

}
