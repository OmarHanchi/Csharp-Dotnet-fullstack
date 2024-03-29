#pragma warning disable CS8618
namespace LINQEruption.Models
{
//* I made this model of the object : new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),    
public class Eruption
    {
        public string VolcanoName { get; set; }  //? Name of the volcano
        public int Year { get; set; }            //? Year of the eruption
        public string Location { get; set; }     //? Location of the volcano
        public int ElevationInMeters { get; set; } //? Elevation of the volcano in meters
        public string Type { get; set; }          //? Type of volcano 
    
                //* this is the constructor 
            public Eruption(string volcanoName, int year, string location, int elevationInMeters, string type)
                {
                    VolcanoName = volcanoName;
                    Year = year;
                    Location = location;
                    ElevationInMeters = elevationInMeters;
                    Type = type;
                }
    }
}