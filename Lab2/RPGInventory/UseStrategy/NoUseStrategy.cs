public class NoUseStrategy : IUseStrategy
{
    public void Use(Player player)
    {
        Console.WriteLine($"Item cannot be used.");
    }
}