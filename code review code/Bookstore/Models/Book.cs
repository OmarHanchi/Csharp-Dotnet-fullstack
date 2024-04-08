#pragma warning disable CS8618

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Bookstore.Models;

public class Book
{  
    [Key]
    public int BookId {get;set;}
    [Required (ErrorMessage ="You have to input the book title ! ")]
    [MinLength(3,ErrorMessage ="The title must be at least 3 chracters !")]
    public string Title {get; set;}

    [MinLength(3,ErrorMessage ="The Author must be at least 3 chracters !")]
    public string Author{get; set;}
    public int PublicationYear {get; set;}
    [Display (Name ="Is Available ?")]
    public  bool IsAvailble {get;set;} = false ;
    public string? Description {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now ;
    public DateTime UpdatedAt {get;set;} = DateTime.Now ;    

}
