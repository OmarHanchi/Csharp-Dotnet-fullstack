public class Attack
{
    public string Name { get; set; }
    public int DamageAmount { get; set; }

    public Attack(string name, int damageAmount)
    {
        Name = name;
        DamageAmount = damageAmount; // Ensure damage is within range (5-25)
        if (damageAmount < 5 || damageAmount > 25)
        {
            throw new ArgumentOutOfRangeException("DamageAmount", "Damage must be between 5 and 25.");
        }
    }
}
