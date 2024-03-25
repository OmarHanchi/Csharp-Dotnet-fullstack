
//! 1. Iterate and print values
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

static void PrintList(List<string> MyList)
{
     Console.WriteLine("===== Method 1======");
    //? using a for loop 
    for ( int i=0 ; i< MyList.Count ;i++  )
    {
        Console.WriteLine(i);
    }

    Console.WriteLine("===== Method 2======");
    //? using a foreach loop 
    foreach (string Name in MyList)
    {
        Console.WriteLine(Name);
    }
    
    Console.WriteLine("===== Method 3======");
    MyList.ForEach(name => Console.WriteLine(name));

}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);


//! Print Sum
static void SumOfNumbers(List<int> IntList)
{
    //? using a for loop 
    int Totalsum = 0 ; 
    for (int x=0 ; x < IntList.Count; x++)
    {
        Totalsum += IntList[x];
    }
    Console.WriteLine("Sum using a for loop: " + Totalsum);

    //? using a foreach loop
    int TotalSum = 0 ; 
    foreach (int i in IntList)
    {
        TotalSum += i ;
    }
    Console.WriteLine("Sum using foreach loop: " + TotalSum);
    
    //? using Linq sum 
    int UsingLinqSum = IntList.Sum();
    Console.WriteLine($"SumOfNumbers using linq {UsingLinqSum}");
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);



static int FindMax(List<int> IntList)
{
  // Find the maximum value using a for loop
  int CurrentMax = IntList[0];
  for (int x = 0; x < IntList.Count; x++)
  {
    if (IntList[x] > CurrentMax)
    {
      CurrentMax = IntList[x];
      
    }
  }
    Console.WriteLine($"Current Max: {CurrentMax}");
  // Return the maximum value after the loop completes
  return CurrentMax;
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
// You should get back 17 in this example
FindMax(TestIntList2);



// static int FindMax1 (List<int> IntList)
// {
  

//     //* Find the maximum value using LINQ
//        int Max = IntList.Max();  
//        Console.WriteLine($"Found max using LINQ: {Max}");
// }






//! === ==== ==== Square the values ===== ==== ==== 


static List<int> SquareValues(List<int> IntList)
{
    List<int> SquaredList = new List<int>();

    foreach (int num in IntList )
    {
        SquaredList.Add(num*num);
    } 
    
    return SquaredList ; 
}
List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
// You should get back [1,4,9,16,25], think about how you will show that this worked
SquareValues(TestIntList3);
Console.WriteLine("this is the squared list :   "+ string.Join(" / ", SquareValues(TestIntList3)));




//! 5. Replace Negative Numbers with 0
static int[] NonNegatives(int[] IntArray)
{
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
    }
    
    return IntArray;
}

int[] TestIntArray = new int[] {-1, 2, 3, -4, 5};
int[] result = NonNegatives(TestIntArray);
NonNegatives(TestIntArray);


//! 6. Print Dictionary

static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    Console.WriteLine("======= Print Dictionary ========");
    foreach (var pair in MyDictionary) 
    {
        Console.WriteLine($"{pair.Key} :  {pair.Value}");
    }
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

//! 7. Find key 
static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    Console.WriteLine("key search result :  ");
    foreach (var key in MyDictionary.Keys)    
    {
        if ( key == SearchTerm)
        {
            return true ; 
        }
    }
    return false ; 
}

// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));


//! // Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
    {
        // Ensure lists have the same length
        if (Names.Count != Numbers.Count)
        {
            Console.WriteLine("Names and Numbers lists must have the same length");
        }

        // Create an empty dictionary
        var nameNumberDict = new Dictionary<string, int>();

        // Loop through names and numbers, adding them as key-value pairs
        for (int i = 0; i < Names.Count; i++)
        {
            nameNumberDict.Add(Names[i], Numbers[i]);
        }

        return nameNumberDict;
    }

// Your test code here
List<string> namesList = new List<string>() { "Julie", "Harold", "James", "Monica" };
List<int> numbersList = new List<int>() { 6, 12, 7, 10 };
GenerateDictionary (namesList,numbersList);

static void PrintStringIntDictionary(Dictionary<string,int> MyDictionary)
{
    Console.WriteLine("======= Print Names & Numbers Dictionary ========");
    foreach (var pair in MyDictionary) 
    {
        Console.WriteLine($"{pair.Key} :  {pair.Value}");
    }
}


// Generate the dictionary
Dictionary<string, int> newDict = GenerateDictionary(namesList, numbersList);
// Print the dictionary
PrintStringIntDictionary(newDict );









