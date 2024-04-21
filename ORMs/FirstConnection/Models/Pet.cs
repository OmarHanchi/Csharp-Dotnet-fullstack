#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FirstConnection.Models;
public class Pet
{
    [Key]
    public int PetId { get; set; }
    public string PetName { get; set; } 
    public int Age { get; set; }
    public bool HasFur { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
                
