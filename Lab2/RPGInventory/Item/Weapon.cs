public class Weapon : IItem
{
    public string Name { get; private set; }
    public float Weight { get; private set; }
    public string Description { get; private set; }
    public float Damage { get; set; }

    public Weapon(string name, float weight, string description, float damage)
    {
        Name = name;
        Weight = weight;
        Description = description;
        Damage = damage;
    }

    public void Use(Player player)
    {
        var strategy = new DamageStrategy(this.Damage + player.AttackDamage);
        strategy.Use(this, player);
    }
}