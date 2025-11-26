public class WeaponBuilder : IItemBuilder
{
    private Weapon _weapon = new Weapon();

    public void SetName(string name)
    {
        _weapon.Name = name;
    }

    public void SetWeight(float weight)
    {
        _weapon.Weight = weight;
    }

    public void SetDescription(string description)
    {
        _weapon.Description = description;
    }

    public void SetDamage(float damage)
    {
        _weapon.Damage = damage;
    }

    public void Reset()
    {
        _weapon = new Weapon();
    }

    public IItem Build()
    {
        var result = _weapon;
        _weapon = new Weapon();
        return result;
    }
}