public class NoUseStrategy : IUseStrategy
{
    public void Use(IItem item, Player player)
    {
        Console.WriteLine($"Item {item.Name} cannot be used.");
    }
}