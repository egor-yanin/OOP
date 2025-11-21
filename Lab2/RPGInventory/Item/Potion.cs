public class HealPotion : IItem
{
    public string Name { get; set; } = "";
    public float Weight { get; set; }
    public string Description { get; set; } = "";
    public float HealAmount { get; set; }

    public void Use(Player player)
    {
        var strategy = new HealStrategy(this.HealAmount);
        strategy.Use(player);
    }
}