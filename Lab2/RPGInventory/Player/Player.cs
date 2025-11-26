public class Player
{
    public string Name { get; set; }
    public float MaxCarryWeight { get; set; }
    public float MaxHP { get; set; } = 100;
    public float HP { get; set; } = 100;
    public float Armor { get; set; } = 0;
    public float AttackDamage { get; set; } = 10;

    public Player(string name, float maxCarryWeight)
    {
        Name = name;
        MaxCarryWeight = maxCarryWeight;
    }

    public void DealDamage(float damage)
    {
        var effectiveDamage = damage - Armor;
        if (effectiveDamage < 0) effectiveDamage = 0;
        HP -= effectiveDamage;
        if (HP < 0) HP = 0;
        System.Console.WriteLine($"Player {Name} took {effectiveDamage} damage. Current HP: {HP}");
    }

    public void Heal(float amount)
    {
        HP += amount;
        if (HP > MaxHP) HP = MaxHP;
        System.Console.WriteLine($"Healed {amount} HP. Current HP: {HP}");
    }
}