#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace OTMDemo.Models;
public class Owner 
{
    [Key]
    public int OwnerId {get;set;}
    [Required]
    public string Name {get;set;}


    //? Navigation property that lets us connect with pet model
    public List<Pet> PetsOwned {get;set;}= new List<Pet>();

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;


}