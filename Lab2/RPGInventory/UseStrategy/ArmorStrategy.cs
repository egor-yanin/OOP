public class ArmorStrategy : IUseStrategy
{
    private readonly int _defenseBonus;

    public ArmorStrategy(int defenseBonus)
    {
        _defenseBonus = defenseBonus;
    }

    public void Use(Player player)
    {
        {
            player.Armor += _defenseBonus;
        }
    }
}