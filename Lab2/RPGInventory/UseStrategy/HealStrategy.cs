public class HealStrategy : IUseStrategy
{
    private readonly float _healAmount;

    public HealStrategy(float healAmount)
    {
        _healAmount = healAmount;
    }

    public void Use(IItem item, Player player)
    {
        if (item is HealPotion potion)
        {
            player.Heal(_healAmount);
        }
    }
}