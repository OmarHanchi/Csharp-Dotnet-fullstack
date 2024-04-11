
using System.ComponentModel.DataAnnotations;
namespace DateValidator
{
    public class DateModel
    {
        [PastDate]
        public DateTime DateInput { get; set; }
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

