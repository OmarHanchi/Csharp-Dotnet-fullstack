#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace SessionWorkshop.Models;
public class Player 
{
    [Required]
    [MinLength(3,ErrorMessage ="Name length should be more than 2 characters ! ")]
    public string Name {get;set;}
}
