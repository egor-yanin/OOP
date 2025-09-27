namespace VendingMachine
{

    public class VendingMachine
    {
        private Dictionary<Product, int> _goods;
        private int _totalMoney;
        private int _currentMoney;
        private List<int> _acceptedCoins = new List<int> { 1, 2, 5, 10 };

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

        public void InsertCoin(int coin)
        {
            if (_acceptedCoins.Contains(coin))
                _currentMoney += coin;
            else
                throw new ArgumentException("Недопустимая монета");
        }

        public int CurrentMoney => _currentMoney;

        public Product GetProductByName(string name)
        {
            foreach (var item in _goods.Keys)
            {
                if (item.Name == name)
                    return item;
            }
            throw new ArgumentException("Товар не найден");
        }

        public void SelectProduct(Product product)
        {
            if (!_goods.ContainsKey(product) || _goods[product] == 0)
                throw new InvalidOperationException("Товар отсутствует");

            if (_currentMoney < product.Price)
                throw new InvalidOperationException("Недостаточно средств");

            _goods[product]--;
            _currentMoney -= product.Price;
            _totalMoney += product.Price;
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
}