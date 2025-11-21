public class Player
{
    public string Name { get; set; }
    public float MaxCarryWeight { get; set; }
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
        // Implementation of dealing damage
        System.Console.WriteLine($"Dealed {damage} damage.");
    }
}