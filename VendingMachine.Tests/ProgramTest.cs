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

        [Fact]
        public void SelectProduct_WhenEnoughMoney_UpdatesStockAndMoney()
        {
            var product = new Product("Шоколад", 20);
            var goods = new Dictionary<Product, int> { { product, 2 } };
            var vendingMachine = new VendingMachine(goods);

            vendingMachine.InsertCoin(10);
            vendingMachine.InsertCoin(10);
            vendingMachine.SelectProduct(product);

            int expectedMoney = 0;
            int actualMoney = vendingMachine.CurrentMoney;
            int expectedStock = 1;
            int actualStock = goods[product]; // Можно получить при просмотре списка товаров

            Assert.Equal(expectedMoney, actualMoney);
            Assert.Equal(expectedStock, actualStock);
        }

        [Fact]
        public void SelectProduct_WhenNotEnoughMoney_ThrowsInvalidOperationException()
        {
            var product = new Product("Пирожок", 15);
            var goods = new Dictionary<Product, int> { { product, 1 } };
            var vendingMachine = new VendingMachine(goods);

            vendingMachine.InsertCoin(10);

            Assert.Throws<InvalidOperationException>(() => vendingMachine.SelectProduct(product));
        }

        [Fact]
        public void SelectProduct_WhenOutOfStock_ThrowsInvalidOperationException()
        {
            var product = new Product("Мороженое", 30);
            var goods = new Dictionary<Product, int> { { product, 0 } };
            var vendingMachine = new VendingMachine(goods);

            vendingMachine.InsertCoin(10);
            vendingMachine.InsertCoin(10);
            vendingMachine.InsertCoin(10);

            Assert.Throws<InvalidOperationException>(() => vendingMachine.SelectProduct(product));
        }
    }
}