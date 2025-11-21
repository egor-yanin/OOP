public class HealStrategy : IUseStrategy
{
    private readonly float _healAmount;

    public HealStrategy(float healAmount)
    {
        _healAmount = healAmount;
    }

    public void Use(Player player)
    {
        {
            player.Heal(_healAmount);
        }
    }
}