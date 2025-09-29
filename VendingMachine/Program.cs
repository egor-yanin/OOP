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

        public int ReturnMoney()
        {
            int moneyToReturn = _currentMoney;
            _currentMoney = 0;
            return moneyToReturn;
        }

        public void RefillProduct(Product product, int quantity)
        {
            if (_goods.ContainsKey(product))
                _goods[product] += quantity;
            else
                _goods[product] = quantity;
        }

        public int CollectMoney()
        {
            int collectedMoney = _totalMoney;
            _totalMoney = 0;
            return collectedMoney;
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

    class Program
    {
        static void Main(string[] args)
        {
            var goods = new Dictionary<Product, int>
            {
                { new Product("Вода 0,5 л.", 50), 5 },
                { new Product("Шоколадеый батончик", 40), 3 },
                { new Product("Кола 0,3 л.", 70), 2 }
            };
            var vendingMachine = new VendingMachine(goods);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Посмотреть товары");
                Console.WriteLine("2. Внести монету");
                Console.WriteLine("3. Выбрать товар");
                Console.WriteLine("4. Вернуть деньги");
                Console.WriteLine("5. Админ-панель");
                Console.WriteLine("q. Выйти");

                var input = Console.ReadLine();

                if (input == null)
                    continue;
                else if (input == "q")
                    exit = true;
                else if (input == "1")
                    Console.WriteLine(vendingMachine.GetGoodsInfo());
                else if (input == "2")
                {
                    Console.WriteLine("Введите номинал монеты (1, 2, 5, 10):");
                    var coin = Console.ReadLine();
                    try
                    {
                        if (coin != null)
                            vendingMachine.InsertCoin(int.Parse(coin));
                        Console.WriteLine($"Текущий баланс: {vendingMachine.CurrentMoney} руб.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Введите название товара:");
                    var productName = Console.ReadLine();
                    try
                    {
                        if (productName != null)
                        {
                            var product = vendingMachine.GetProductByName(productName);
                            vendingMachine.SelectProduct(product);
                            Console.WriteLine($"Вы купили: {product.Name}");
                            Console.WriteLine($"Остаток на балансе: {vendingMachine.CurrentMoney} руб.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "4")
                {
                    int returnedMoney = vendingMachine.ReturnMoney();
                    Console.WriteLine($"Возвращено: {returnedMoney} руб.");
                }
                else if (input == "5")
                {
                    Console.WriteLine("Админ-панель:");
                    Console.WriteLine("1. Пополнить товар");
                    Console.WriteLine("2. Снять деньги");
                    Console.WriteLine("3. Выйти из админ-панели");
                    var adminInput = Console.ReadLine();

                    if (adminInput == "1")
                    {
                        Console.WriteLine("Введите название товара для пополнения:");
                        var productName = Console.ReadLine();
                        Console.WriteLine("Введите количество для пополнения:");
                        var quantityStr = Console.ReadLine();
                        try
                        {
                            if (productName != null && quantityStr != null)
                            {
                                int quantity = int.Parse(quantityStr);
                                var product = vendingMachine.GetProductByName(productName);
                                vendingMachine.RefillProduct(product, quantity);
                                Console.WriteLine("Товар пополнен.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (adminInput == "2")
                    {
                        int collectedMoney = vendingMachine.CollectMoney();
                        Console.WriteLine($"Снято денег: {collectedMoney} руб.");
                    }
                }
                else
                {
                    Console.WriteLine("Недопустимое действие. Попробуйте снова.");
                }
            }
        }
    }
}