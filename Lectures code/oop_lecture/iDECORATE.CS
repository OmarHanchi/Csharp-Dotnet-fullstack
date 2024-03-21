interface IDecorate
{
    //! Add a fiel (auto implemented prperty)
    int numberOfItems {get;set;}
    List<string> Allitems {get;set;}


    //? Add method
    void addItem(string Item);

}