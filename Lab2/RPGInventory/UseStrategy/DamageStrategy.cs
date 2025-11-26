public class DamageStrategy : IUseStrategy
{
    private readonly float _damageAmount;

    public DamageStrategy(float damageAmount)
    {
        _damageAmount = damageAmount;
    }

    public void Use(Player player)
    {
        {
            player.DealDamage(_damageAmount);
        }
    }
}