public class DamageStrategy : IUseStrategy
{
    private readonly float _damageAmount;

    public DamageStrategy(float damageAmount)
    {
        _damageAmount = damageAmount;
    }

    public void Use(IItem item, Player player)
    {
        if (item is Weapon weapon)
        {
            player.DealDamage(_damageAmount);
        }
    }
}