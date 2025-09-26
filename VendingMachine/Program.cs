public class VendingMachine
{
    private Dictionary<Product, int> _goods;
    private int _totalMoney;
    private int _currentMoney;

    public VendingMachine(Dictionary<Product, int> initialGoods)
    {
        _totalMoney = 0;
        _currentMoney = 0;
        _goods = initialGoods;
    }

    public string GetGoodsInfo()
    {
        string info = "Доступные товары:\n";
        foreach (var item in _goods)
        {
            if (item.Value > 0)
            {
                if (item.Value == 1)
                    info += $"{item.Key.Name} ({item.Key.Price} руб.): {item.Value} штука\n";
                else if (item.Value >= 2 && item.Value <= 4)
                    info += $"{item.Key.Name} ({item.Key.Price} руб.): {item.Value} штуки\n";
                else info += $"{item.Key.Name} ({item.Key.Price} руб.): {item.Value} штук\n";
            }
            
        }
        return info;
    }
}

public class Product
{
    public string Name { get; }
    public int Price { get; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
}