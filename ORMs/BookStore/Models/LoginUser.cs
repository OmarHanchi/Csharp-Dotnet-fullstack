#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginAndRegistration.Models;public class LoginUser
{
    [Required]
    [EmailAddress]    
    public string Email { get; set; }  


    [Required]    
    [DataType(DataType.Password)]
    public string Password { get; set; } 
}