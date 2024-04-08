#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LogReg.Models;
public class LoginUser
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [MinLength(2,ErrorMessage ="User Name must be at least 2 characters ")]
    public string UserName { get; set; } 
    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }
    [Required]
    [MinLength(8,ErrorMessage = "Password should be at least 8 characters ")]
    [DataType(DataType.Password)]
    public string Password {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

   
    public string Confirm {get;set;}
}