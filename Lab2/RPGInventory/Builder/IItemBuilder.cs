public interface IItemBuilder
{
    void SetName(string name);
    void SetWeight(float weight);
    void SetDescription(string description);
    void Reset();
    IItem Build();
}