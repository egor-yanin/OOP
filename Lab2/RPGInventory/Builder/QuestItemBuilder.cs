public class QuestItemBuilder : IItemBuilder
{
    private QuestItem _item = new QuestItem();

    public void SetName(string name)
    {
        _item.Name = name;
    }

    public void SetWeight(float weight)
    {
        _item.Weight = weight;
    }

    public void SetDescription(string description)
    {
        _item.Description = description;
    }

    public void SetQuestID(string questID)
    {
        _item.QuestID = questID;
    }

    public void Reset()
    {
        _item = new QuestItem();
    }

    public IItem Build()
    {
        var result = _item;
        Reset();
        return result;
    }
}