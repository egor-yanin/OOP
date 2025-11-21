public class Weapon : IItem
{
    public float Damage { get; set; }

    public Weapon(string name, float weight, string description, float damage)
    {
        Name = name;
        Weight = weight;
        Description = description;
        Damage = damage;
    }

    void Use(Player player)
    {
        var strategy = new DamageStrategy();
        strategy.Use(this, player);
    }
}