#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace OTMDemo.Models;
public class Pet
{
    [Key]
    public int PetId {get;set;}
    [Required]
    public string PetName {get;set;}
    public string Species {get;set;}

    public int OwnerId {get;set;}

    //? Navigation property that lets us connect with pet model
    public Owner? Owner {get; set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}