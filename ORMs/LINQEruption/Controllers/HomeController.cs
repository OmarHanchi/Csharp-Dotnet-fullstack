using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQEruption.Models;

namespace LINQEruption.Controllers;

public class HomeController : Controller
{
    
    public static List<Eruption> Eruptions = new List<Eruption>()
    {
        new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
        new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
        new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
        new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
        new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
        new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
        new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
        new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
        new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
        new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
        new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
        new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
        new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
    };

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }



    public IActionResult Index()
    {
        //* Use LINQ to find the first eruption that is in Chile and print the result.
        Eruption? FirstChileEruption = Eruptions.FirstOrDefault(e => e.Location == "Chile");
        ViewBag.FirstChileEruption = FirstChileEruption;

        //* Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
        Eruption? FirstHawaiinEruption = Eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
        if (FirstHawaiinEruption != null)
        {
            ViewBag.FirstHawaiinEruption = FirstHawaiinEruption;
        }
        else 
        {
            ViewBag.FirstHawaiinEruption = "No Hawaiian Is Eruption found.";
        }
        
        //* Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
        Eruption? FirstGreenlandEruption = Eruptions.FirstOrDefault(e => e.Location == "Greenland");
        if (FirstGreenlandEruption != null)
        {
            ViewBag.FirstGreenlandEruption = FirstGreenlandEruption;
        }
        else 
        {
            ViewBag.FirstGreenlandEruption = "No Greenland Eruption found.";
        }


        //*Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
        Eruption? FirstInNewZealand = Eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
        ViewBag.FirstInNewZealand = FirstInNewZealand ;

        //*Find all eruptions where the volcano's elevation is over 2000m and print them.
        List<Eruption> EruptionsOver2000m = Eruptions.Where(e => e.ElevationInMeters > 2000 ).ToList();
        ViewBag.EruptionsOver2000m = EruptionsOver2000m ;
        //*Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
        List<Eruption> EruptionsStartWithL = Eruptions.Where(e => e.VolcanoName.StartsWith("L")).ToList();
        ViewBag.EruptionsStartWithL = EruptionsStartWithL;
        ViewBag.EruptionsStartWithLCount = EruptionsStartWithL.Count();
        //*Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)



        //*Use the highest elevation variable to find and print the name of the Volcano with that elevation.



        //*Print all Volcano names alphabetically.



        //*Print the sum of all the elevations of the volcanoes combined.



        //*Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)



        //* Find all stratovolcanoes and print just the first three (Hint: look up Take)



        //*Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.



        //*Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
