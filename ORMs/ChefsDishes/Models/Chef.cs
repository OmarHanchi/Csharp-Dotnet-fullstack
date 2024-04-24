#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsDishes.Models;
public class Chef
{   

    [Key]        
    public int UserId { get; set; }
    





    //* ======= First Name validation ============
    [Required(ErrorMessage = "First Name  is required")]
    [MinLength(2,ErrorMessage ="First name must be at least 2 characters")]     
    public string FirstName { get; set; }
    







    //* ======= Last Name validation ============
    [Required(ErrorMessage = "Last Name  is required")]
    [MinLength(2,ErrorMessage ="Last name must be at least 2 characters")]      
    public string LastName { get; set; }         
    





    //* ======= Date of birth validation ============
    [Required(ErrorMessage = "Date of birth is required")]
    [PastDate]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth {get;set;}
    

    public List<Dish> CreatedDishes {get;set;} = new List<Dish>();



    //* ======= Created & Updated validation ============
    public DateTime CreatedAt {get;set;} = DateTime.Now;        
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}


    //* ======= Custom past date validation ============

    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value ==null )
            {
                return ValidationResult.Success;
            }
            DateTime SubmittedDate = (DateTime) value;
            if (SubmittedDate > DateTime.Now)
            {
                return new ValidationResult ("Please enter a date in the past ! ");

            }
            return ValidationResult.Success;
        }
    
    }
