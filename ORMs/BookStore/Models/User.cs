#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace BookStore.Models;
public class User
{        
    [Key]        
    public int UserId { get; set; }

    //=======================First Name ====================    
    [Required]   
    [MinLength(2,ErrorMessage ="First name must be at least 2 characters")]     
    public string FirstName { get; set; }

    //=======================Last Name ====================    
    [Required] 
    [MinLength(2,ErrorMessage ="Last name must be at least 2 characters")]     
    public string LastName { get; set; }    


    //=======================Email ====================    
    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }      
    

    //=======================Password ====================    
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; }          
    

    //=======================Created At & Updated At ====================    
    public DateTime CreatedAt {get;set;} = DateTime.Now;        
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    


    //======================= Confirm Password ====================    
    [NotMapped]
    [Compare("Password")]
    public string PasswordConfirm { get; set; }


    //Navigation properties 
    public List<Book> MyBooks {get;set;} = new List<Book>(){};

}





//? ======= Unique email validation ============
public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
    	// Though we have Required as a validation, sometimes we make it here anyways
    	// In which case we must first verify the value is not null before we proceed
        if(value == null)
        {
    	    // If it was, return the required error
            return new ValidationResult("Email is required!");
        }
    
    	// This will connect us to our database since we are not in our Controller
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        // Check to see if there are any records of this email in our database
    	if(_context.Users.Any(e => e.Email == value.ToString()))
        {
    	    // If yes, throw an error
            return new ValidationResult("Email must be unique!");
        } else {
    	    // If no, proceed
            return ValidationResult.Success;
        }
    }
}
