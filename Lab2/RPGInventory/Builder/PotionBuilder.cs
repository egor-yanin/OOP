public class PotionBuilder : IItemBuilder
{
    private HealPotion _potion = new HealPotion();

    public void SetName(string Name)
    {
        _potion.Name = Name;
    }

    public void SetWeight(float Weight)
    {
        _potion.Weight = Weight;
    }

    public void SetDescription(string Description)
    {
        _potion.Description = Description;
    }

    public void SetHealAmount(float HealAmount)
    {
        _potion.HealAmount = HealAmount;
    }

    public void Reset()
    {
        _potion = new HealPotion();
    }

    public IItem Build()
    {
        return _potion;
    }
}