using System;

class Program
{
    static void Main()
    { int i = 1 ; 
    while (i<= 255) {
        Console.WriteLine(i);
        i++ ; 
    }
    {
        
    }
     
    /*
       // Use a for loop to iterate from 1 to 255
        for (int i = 1; i <= 255; i++)
        {
            Console.WriteLine(i);
        }
    */
    Console.WriteLine("...........................................");
    for (int val = 1 ; val <= 100 ; val++)
    {
    if (val % 15 ==0) {
        Console.WriteLine("FizzBuzz");
    }
    else if  (val % 3 == 0) {
        Console.WriteLine("Fizz");
    }
    else if  (val % 5 == 0) {
        Console.WriteLine("Buzz");
    }
    }

    } 
}

