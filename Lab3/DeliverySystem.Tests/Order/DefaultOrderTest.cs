using Xunit;
using DeliverySystem;
using DeliverySystem.Dish;
using DeliverySystem.Discount;

public class DefaultOrderTests
{
    [Fact]
    public void GetTotalPrice_ReturnsSumWithoutDiscount()
    {
        // Arrange
        var order = new DefaultOrder();
        var dish1 = new DefaultDish("Pizza", 300, 500, "Main", 800);
        var dish2 = new DefaultDish("Salad", 100, 200, "Appetizer", 150);

        order.AddDish(dish1, 2); // 2 * 300 = 600
        order.AddDish(dish2, 3); // 3 * 100 = 300

        // Act
        float total = order.GetTotalPrice();

        // Assert
        Assert.Equal(900, total);
    }

    [Fact]
    public void GetTotalPrice_AppliesDishDiscount()
    {
        // Arrange
        var order = new DefaultOrder();
        var dish = new DefaultDish("Burger", 200, 300, "Main", 600);
        order.AddDish(dish, 2);

        // Устанавливаем скидку на Burger 50%
        order.SetDiscount(new DishDiscount("Burger", 50));

        // Act
        float total = order.GetTotalPrice();

        // Assert
        Assert.Equal(200, total); // (200 * 0.5) * 2 = 200
    }

    [Fact]
    public void GetTotalPrice_ReturnsZero_WhenNoDishes()
    {
        // Arrange
        var order = new DefaultOrder();

        // Act
        float total = order.GetTotalPrice();

        // Assert
        Assert.Equal(0, total);
    }

    [Fact]
    public void GetTotalPrice_DishDiscountDoesNotAffectOtherDishes()
    {
        // Arrange
        var order = new DefaultOrder();
        var burger = new DefaultDish("Burger", 200, 300, "Main", 600);
        var pizza = new DefaultDish("Pizza", 300, 500, "Main", 800);
        order.AddDish(burger, 1);
        order.AddDish(pizza, 1);

        // Скидка только на Burger 25%
        order.SetDiscount(new DishDiscount("Burger", 25));

        // Act
        float total = order.GetTotalPrice();

        // Assert
        Assert.Equal(450, total); // (200*0.75) + 300 = 150 + 300 = 450
    }
}