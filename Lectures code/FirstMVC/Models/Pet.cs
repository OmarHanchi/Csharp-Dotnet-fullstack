#pragma warning disable CS8618
namespace FirstMVC.Models;
using System.ComponentModel.DataAnnotations;

public class Pet 
{
[Required ]
[MinLength(3)]        
public string Name {get;set;}
public string Species {get;set;}
[Required]
public bool IsFriendly {get;set;}
[Required]
[Range(0,int.MaxValue)]
public int Age {get;set;}
}