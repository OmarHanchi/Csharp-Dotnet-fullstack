#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TheWall.Models;
public class LogUser
{
    [Required]
    [EmailAddress]
    public string LogEmail {get;set;}
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string LogPassword {get;set;}
}