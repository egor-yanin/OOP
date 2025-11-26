public interface IItem
{
    string Name { get; }
    float Weight { get; }
    string Description { get; }
    void Use(Player player);
}