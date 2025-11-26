public class Armor : IItem
{
    public string Name { get; set; } = "";
    public float Weight { get; set; }
    public string Description { get; set; } = "";
    public int Defense { get; set; }
    private IUseStrategy _useStrategy = new NoUseStrategy();

    public void Use(Player player)
    {
        _useStrategy.Use(player);
    }
}