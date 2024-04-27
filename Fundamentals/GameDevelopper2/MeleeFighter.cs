public class MeleeFighter : Enemy
{
    public MeleeFighter(string name) : base(name) // Call base class constructor with name
    {
        Health = 120; // Set default health for MeleeFighter

        Attack punch = new Attack("Punch", 20);
        Attack kick = new Attack("Kick", 15);
        Attack tackle = new Attack("Tackle", 25);

        AddAttack(punch);
        AddAttack(kick);
        AddAttack(tackle);
    }

    public override void PerformAttack(Enemy target, Attack chosenAttack)
    {
        base.PerformAttack(target, chosenAttack); // Call base class PerformAttack first

        if (chosenAttack.Name == "Rage") // Handle Rage attack with bonus damage
        {
            Console.WriteLine($"{Name} enters a rage!");
            target.TakeDamage(10); // Deal extra 10 damage on Rage
        }
    }

    public void Rage() // Custom method for Rage attack
    {
        int randomIndex = new Random().Next(AttackList.Count);
        Attack randomAttack = AttackList[randomIndex];
        PerformAttack(this, randomAttack); // Call PerformAttack with this and a random attack
    }
}
