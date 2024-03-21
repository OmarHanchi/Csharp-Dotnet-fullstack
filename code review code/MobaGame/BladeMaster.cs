public class BladeMaster : Champion
{
    public bool Rage {get; set;}
    public BladeMaster (string name) : base (name,200,25)
    {
        Rage = true;
    }
    public override void Attack (Champion enemy)
    {
         
        if(enemy.Health<1)
        {
            Console.WriteLine("________________________");
            Console.WriteLine(value : $"{enemy.Name} is already dead! ");
        }
        else if (Rage)
        {
            Console.WriteLine("________________________");
            int dmg = AttackDamage*2;
            enemy.Health -= dmg ;
            Console.WriteLine(value : $"  {Name}  attacked the {GetType()} {enemy.Name} the {enemy.GetType()} and made {dmg} damage "); 
            Rage = false ; 
        }
        else base.Attack (enemy);
    }  
}