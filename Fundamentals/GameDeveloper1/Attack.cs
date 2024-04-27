public class Attack
{
    public string Name { get; set; } // Public access for both reading and writing
    public int DamageAmount { get; set; } // Public access for both reading and writing

    public Attack(string name, int damageAmount) // Constructor
    {
        Name = name;
        DamageAmount = damageAmount; // Ensure damage is within range (5-25)
        if (damageAmount < 5 || damageAmount > 25)
        {
            throw new ArgumentOutOfRangeException("DamageAmount", "Damage must be between 5 and 25.");
        }
    }
}