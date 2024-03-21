public class Champion 
{
    public string Name {get;set;}
    public  int Health {get;set;}
    public int AttackDamage {get; set;}
    public Champion (string name, int health , int attackDamage)
    {
        Name = name; 
        Health = health;
        AttackDamage = attackDamage;
    }
    public virtual void Attack (Champion enemy )
    {
        Console.WriteLine("________________________");
        if(enemy.Health<1)
        {
            Console.WriteLine(value : $"{enemy.Name} is already dead! ");
        }
        else
        enemy.Health -= AttackDamage;
        Console.WriteLine(value : $"  {Name}  attacked the {GetType()} {enemy.Name} the {GetType()} and made {AttackDamage} damage "); 
        Console.WriteLine(value : $"{enemy.Name} current health is {enemy.Health}");
        Console.WriteLine(value : $"{Name} current health is {Health}");

    }

}