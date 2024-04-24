#pragma warning disable CS8618

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace BookStore.Models;

public class Book
{  
    [Key]
    public int Id {get;set;}
    [Required (ErrorMessage ="You have to input the book title ! ")]
    [MinLength(3,ErrorMessage ="The title must be at least 3 chracters !")]
    public string Title {get; set;}
    public int PublicationYear {get; set;}

    [Display (Name ="Is Available ?")]
    public  bool IsAvailble {get;set;} = false ;
    public string? Description {get;set;}



    //============ Navigation Property ==================
    public User? Author{get; set;}
    



    //======================= Created At & Updated At ====================    
    public DateTime CreatedAt {get;set;} = DateTime.Now ;
    public DateTime UpdatedAt {get;set;} = DateTime.Now ;    

}
