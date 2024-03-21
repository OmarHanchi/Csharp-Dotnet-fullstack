class Table : Furniture 
{
    public int numberOfItems{get;set;}
    public List <string> Allitems {get;set;}
    public Table (string c, double p , string m , bool o ) : base (c,p,m,o) 
    {
        numberOfItems=0;
        Allitems = new List<string>();
    }

    //? Idecorate Method
    public void AddItem (string Item)
    {
        numberOfItems++ ;
        Allitems.Add(Item);
    }
    public void ShowItems()
    {
        foreach(string item in Allitems)
        {
            Console.WriteLine(item);
        }
    }
}