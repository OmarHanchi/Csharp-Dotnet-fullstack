using System ;
using System.Runtime.CompilerServices;
class Fundamentals
{
    static void Main ()
    {
        // Print all of the integers from 1 to 255.
            for (int i=1 ; i <=255 ; i++)
            {
                Console.WriteLine(i);
            }
            
        // Print all of the integers from 1 to 255.
            for (int i=1 ; i <=255 ; i++)
            {
                if (i % 2 != 2) 
                {
                    Console.WriteLine(i);
                }
            }
        // print sum of all numbers from 0 to 255 
            int sum = 0;
            for (int i=1 ; i<=255 ; i++ )
            {
                sum += i ;
                Console.WriteLine($"new number : {i}  , sum is  {sum} ");
            }
    }
}

