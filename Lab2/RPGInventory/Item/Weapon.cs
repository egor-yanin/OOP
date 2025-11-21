public class Weapon : IItem
{
    public string Name { get; set; } = "";
    public float Weight { get; set; }
    public string Description { get; set; } = "";
    public float Damage { get; set; }

    public void Use(Player player)
    {
        var strategy = new DamageStrategy(this.Damage + player.AttackDamage);
        strategy.Use(this, player);
    }
}