public class Enemy
{
    private int health = 100;
    public int Health { get { return health; } }  // Read-only property for health

    public string Name { get; set; }
    public List<Attack> AttackList { get; set; }

    public Enemy(string name)
    {
        Name = name;
        AttackList = new List<Attack>();
    }

    public void AddAttack(Attack attack)
    {
        AttackList.Add(attack);
    }

    public virtual void TakeDamage(int damage) // Virtual keyword for overriding in subclasses
    {
        health -= damage;
        if (health <= 0)
        {
            Console.WriteLine($"{Name} has been defeated!");
            health = 0; // Ensure health doesn't go negative
        }
    }

    public virtual void PerformAttack(Enemy target, Attack chosenAttack)
    {
        target.TakeDamage(chosenAttack.DamageAmount);
        Console.WriteLine($"{Name} attacks {target.Name} with {chosenAttack.Name}, dealing {chosenAttack.DamageAmount} damage!");
    }
}
