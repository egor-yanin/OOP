public class HealPotion : IItem
{
    public string Name { get; private set; }
    public float Weight { get; private set; }
    public string Description { get; private set; }
    public float HealAmount { get; set; }

    public HealPotion(string name, float weight, string description, float healAmount)
    {
        Name = name;
        Weight = weight;
        Description = description;
        HealAmount = healAmount;
    }

    public void Use(Player player)
    {
        var strategy = new HealStrategy(this.HealAmount);
        strategy.Use(this, player);
    }
}