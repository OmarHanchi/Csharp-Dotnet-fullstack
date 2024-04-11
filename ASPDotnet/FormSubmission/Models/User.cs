#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
namespace FormSubmission
{
    public class User 
    {
        [Required]
        [MinLength(2,ErrorMessage ="Name must be more than 2 characters")]
        public string Name {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [PastDate]
        public DateTime DateOfBirth {get;set;}

        [Required]
        [MinLength(8,ErrorMessage ="Password should be more than 8 characters ")]
        public string Password{get;set;}

        [Required]
        [OddNumber]
        public int OddNumber {get;set;}
    } 
}
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

public class OddNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
         if (value == null || !(value is int))
    {
        return new ValidationResult("Favorite Odd Number must be a whole number.");
    }
       int number = (int)value;
       if (number %2 == 0)
       {
            return new ValidationResult("Favorite Odd Number must be a whole odd number greater than zero.");
       }
       return ValidationResult.Success;
    }
    
        
}