using System.Collections.Generic;
using Xunit;
using VendingMachine;

namespace VendingMachine.Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void GetGoodsInfo_ReturnsCorrectInfo_ForSingleProduct()
        {
            var product = new Product("Чипсы", 50);
            var goods = new Dictionary<Product, int> { { product, 1 } };
            var vendingMachine = new VendingMachine(goods);

            string expected = "Доступные товары:\nЧипсы (50 руб.): 1 штука\n";
            string actual = vendingMachine.GetGoodsInfo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetGoodsInfo_ReturnsCorrectInfo_ForMultipleProducts()
        {
            var product1 = new Product("Сок", 30);
            var product2 = new Product("Вода", 20);
            var goods = new Dictionary<Product, int>
            {
                { product1, 3 },
                { product2, 5 }
            };
            var vendingMachine = new VendingMachine(goods);

            string expected = "Доступные товары:\nСок (30 руб.): 3 штуки\nВода (20 руб.): 5 штук\n";
            string actual = vendingMachine.GetGoodsInfo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetGoodsInfo_SkipsProductsWithZeroCount()
        {
            var product1 = new Product("Кола", 40);
            var product2 = new Product("Печенье", 25);
            var goods = new Dictionary<Product, int>
            {
                { product1, 0 },
                { product2, 2 }
            };
            var vendingMachine = new VendingMachine(goods);

            string expected = "Доступные товары:\nПеченье (25 руб.): 2 штуки\n";
            string actual = vendingMachine.GetGoodsInfo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetGoodsInfo_ReturnsOnlyHeader_WhenNoProductsAvailable()
        {
            var goods = new Dictionary<Product, int>();
            var vendingMachine = new VendingMachine(goods);

            string expected = "Доступные товары:\n";
            string actual = vendingMachine.GetGoodsInfo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetGoodsInfo_UsesCorrectWordForm_ForDifferentCounts()
        {
            var product1 = new Product("Батончик", 15);
            var product2 = new Product("Кофе", 60);
            var product3 = new Product("Чай", 25);
            var goods = new Dictionary<Product, int>
            {
                { product1, 1 },
                { product2, 2 },
                { product3, 5 }
            };
            var vendingMachine = new VendingMachine(goods);

            string expected =
                "Доступные товары:\n" +
                "Батончик (15 руб.): 1 штука\n" +
                "Кофе (60 руб.): 2 штуки\n" +
                "Чай (25 руб.): 5 штук\n";
            string actual = vendingMachine.GetGoodsInfo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertCoin_AcceptsValidCoins_AndUpdatesCurrentMoney()
        {
            var goods = new Dictionary<Product, int>();
            var vendingMachine = new VendingMachine(goods);

            vendingMachine.InsertCoin(1);
            vendingMachine.InsertCoin(2);
            vendingMachine.InsertCoin(5);
            vendingMachine.InsertCoin(10);
            int expected = 18;
            int actual = vendingMachine.CurrentMoney;

            Assert.Equal(expected, actual);
        }
    }
}