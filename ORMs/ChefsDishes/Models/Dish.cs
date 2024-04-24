#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsDishes.Models;
public class Dish
{

      [Key]
    public int ID { get; set; }


    //* ======= Dish Name validation ============

    [Required(ErrorMessage = "Dish name is required")]
    public string Name { get; set; }




    //! =======  Chef Id validation ============

    [Required(ErrorMessage = "Chef's name is required")]
    public int ChefId { get; set; }


    //* =======  Tastiness validation ============
    [Required(ErrorMessage = "Tastiness is required")]
    [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5")]
    public int Tastiness { get; set; }



    //* =======  Calories validation ============
    [Required(ErrorMessage = "Calories is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be greater than 0")]
    public int Calories { get; set; }




    //* ======= Navigation property ============
    public Chef? Chef {get;set;}


    //* =======  Created At and Updated At validation ============
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



}