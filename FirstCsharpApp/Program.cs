// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// =========    data types  ============= 
// what is statically typed laguage ?

// you have to specify the type of variable or function you want to create 
// for storage .. it specify the needed storage space for that variable ..
// you will take the place you just can use 
// javascript 
// var name = "hello" 
// python 
// name = "hello"
// c# 
string name = "omar" ;
int number = 7 ; 
double dec = 3.14 ; 
float floatValue = 1.2f;
bool isTrue = true ;


// ========= list and dictionnaries ===========
// array and list 
// arrays in c# we need to tell him that there is a fixed lenght
string[array] groceryList = new string[4];
// in his memory c# will see it [null,null,null,null]
string [] groceryList2 = {"carrots","turkey","bread","milk"};
//                           0          1       2       3
// in c# , square braquets are used indexing and accessing to an array 
groceryList [2] = "Ham";
//[null,null,"Ham",null]

// Lists are variable lenght 
list <int> numberList = new list <int>();
numberList.Add(0);
numberList.Add(1);
numberList.Add(2);
numberList.Add(3);


numberList.Insert(4,100);

string words ="hello" ;

foreach (int in numberList)
{
    console.WriteLine(int);
}



// ============ Function =============

static void SayHello()
{
    console.WriteLine("hello everyone");
}

SayHello();

// ========== parametres =======

static int DoMath ( int x , int y )
{
    return x- y;
}
//   =========== arguments =========
DoMath(6,4);
console.WriteLine(DoMath(10,4));
int answer = DoMath(10,5);
console.writeline (answer);
