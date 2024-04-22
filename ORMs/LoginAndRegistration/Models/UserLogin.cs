#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginAndRegistration.Models;public class LoginUser
{
    // No other fields!
    [Required]    
    public string Email { get; set; }    
    [Required]    
    public string Password { get; set; } 
}