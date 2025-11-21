public class DamageStrategy : IUseStrategy
{
    public void Use(IItem item, Player player)
    {
        if (item is Weapon weapon)
        {
            player.DealDamage(weapon.Damage + player.AttackDamage);
        }
    }
}