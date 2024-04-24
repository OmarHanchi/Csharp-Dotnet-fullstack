#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginAndRegistration.Models;public class LoginUser
{


    //* ===========  Email validation ===============
    [Required]    
    public string LoginEmail { get; set; }  


    //* ======= Login Pssword validation ============
    [Required]
    [DataType(DataType.Password)]
    public string LoginPassword { get; set; } 
}


