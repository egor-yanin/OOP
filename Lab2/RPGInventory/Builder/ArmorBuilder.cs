public class ArmorBuilder : IItemBuilder
{
    private Armor _armor = new Armor();

    public void SetName(string name)
    {
        _armor.Name = name;
    }

    public void SetWeight(float weight)
    {
        _armor.Weight = weight;
    }

    public void SetDescription(string description)
    {
        _armor.Description = description;
    }

    public void SetDefense(int defense)
    {
        _armor.Defense = defense;
    }

    public void Reset()
    {
        _armor = new Armor();
    }

    public IItem Build()
    {
        var result = _armor;
        Reset();
        return result;
    }
}