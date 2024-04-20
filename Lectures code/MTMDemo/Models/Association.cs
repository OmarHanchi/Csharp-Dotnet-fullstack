using System.ComponentModel.DataAnnotations;
namespace MTMDemo.Models;
public class Association 
{
    [Key]
    public int AssociationID {get;set;}
    // track the Id's of our joining models
    [Required]
    public int ActorId {get;set;}
    [Required]




    //? Navigation properties 
    public Actor? Actor {get;set;}
    public Movie? Movie {get;set;}




}