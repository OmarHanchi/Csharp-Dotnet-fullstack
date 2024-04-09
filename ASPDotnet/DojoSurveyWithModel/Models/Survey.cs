#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace DojoSurveyWithModel.Models
{
public class Survey 
{
  [MinLength(3, ErrorMessage ="Name should be no less than 3 characters")]
  public string Name {get;set;}
  public string Location {get;set;}  
  
  [Required]
  public string FavouriteLanguage {get;set;}

  [MinLength(20,ErrorMessage ="comment should be more than 20 characters.")]
  public string Comment {get;set;}
}
}
