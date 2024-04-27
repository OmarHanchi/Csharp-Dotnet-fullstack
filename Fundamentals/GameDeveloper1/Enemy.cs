public class Enemy
{
    public static void Main(string[] args)
{
    // Create some attack instances
    Attack fireball = new Attack("Fireball", 20);
    Attack punch = new Attack("Punch", 8);
    Attack kick = new Attack("Kick", 12);

    // Create an enemy instance
    Enemy goblin = new Enemy("Goblin");

    // Add attacks to the enemy's list
    goblin.AddAttack

    private int health = 100; // Private health field
    public int Health { get { return health; } } // Public getter for health (read-only)

    public string Name { get; set; }
    public List<Attack> AttackList { get; set; }

    public Enemy(string name)
    {
        Name = name;
        AttackList = new List<Attack>(); // Initialize an empty AttackList
    }

    public void AddAttack(Attack attack) // Method to add attacks
    {
        AttackList.Add(attack);
    }

    public Attack RandomAttack()
    {
        Random random = new Random();
        int index = random.Next(AttackList.Count); // Get a random index within the AttackList range
        return AttackList[index];
    }
}

}




