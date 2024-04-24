#pragma warning disable CS8618

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace BookStore.Models;

public class Favourite
{  
    [Key]
    public int Id {get;set;}
    
    public int UserId {get; set;}

    public int BookId {get; set;}

    // Navigation Properties 
    public User ? Liker {get;set;}
    
    public Book ? LikedBook {get;set;}


    //======================= Created At & Updated At ====================    
    public DateTime CreatedAt {get;set;} = DateTime.Now ;
    public DateTime UpdatedAt {get;set;} = DateTime.Now ;    

}
