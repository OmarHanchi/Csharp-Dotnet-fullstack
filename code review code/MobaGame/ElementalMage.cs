public class ElementalMage:Champion 
{
    public int FireBallDamage{get;set;}
    public bool 
    public ElementalMage (string name) : base (name, 80, 10)
    {
        FireBallDamage = 90 ;
    }
    
    public void FireBall(Champion enemy)
    {
        
            double dmg = enemy.Health;
            enemy.Health -= (int)dmg;

            Console.WriteLine(value : $"  {Name}  attacked the {GetType()} {enemy.Name} the {enemy.GetType()} and made {dmg} damage "); 
        
    }  
}