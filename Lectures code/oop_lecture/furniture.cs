using System.Drawing;
using System.Reflection.Metadata;

public class Furniture 
{
    //! step1
    //? fields to describe our object 
    
    public string colour;
    public string _colour{get{return colour ; }}
    public double priice ;
    public string materials ;
    public string _materials{get{return materials ; }}

    public bool outdoor ;

    //! step 2 
    //? Constructor 
    public Furniture (string c , double p , string m,bool o )
    {
        colour = c ; 
        priice = p ; 
        materials = m ; 
        outdoor = o ; 

    }
    //! new constructor 
     public Furniture (string c , double p , string m,)
    {
        colour = c ; 
        priice = p ; 
        materials = m ; 
        outdoor = false ; 

    }

    //! step 3 
    //? Methods 
    public void ChangeColor(string newColor)
    {
        Console.WriteLine ($"changed our furniture colour from  {colour} to {newColor}");
        colour = newColor;
    }

}