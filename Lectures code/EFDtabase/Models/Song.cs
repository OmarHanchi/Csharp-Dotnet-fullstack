#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace EFDtabase.Models;
public class Song
{
    //* we need an id 
    //* make sure that the key is like this :   "model name + id"
    [Key]
    public int SongId { get; set; }
    [Required]
    public string Name { get; set; } 
    [Required]
    public string Genre { get; set; } 
    [Required]
    public int Year { get; set; }

    //* we always include a created at and updated at because it's good practice
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
                
