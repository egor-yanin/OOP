using Xunit;

public class PotionBuilderTests
{
    [Fact]
    public void Build_ShouldReturnPotionWithSetProperties()
    {
        // Arrange
        var builder = new PotionBuilder();

        builder.SetName("Health Potion");
        builder.SetWeight(0.5f);
        builder.SetDescription("Restores health");
        builder.SetHealAmount(30);

        // Act
        var item = builder.Build();

        // Assert
        var potion = Assert.IsType<HealPotion>(item);
        Assert.Equal("Health Potion", potion.Name);
        Assert.Equal(0.5f, potion.Weight);
        Assert.Equal("Restores health", potion.Description);
        Assert.Equal(30, potion.HealAmount);
    }

    [Fact]
    public void Reset_ShouldClearPreviousState()
    {
        // Arrange
        var builder = new PotionBuilder();
        builder.SetName("Mana Potion");
        builder.SetHealAmount(10);

        // Act
        builder.Reset();
        var item = builder.Build();

        // Assert
        var potion = Assert.IsType<HealPotion>(item);
        Assert.NotEqual("Mana Potion", potion.Name);
        Assert.NotEqual(10, potion.HealAmount);
    }

    [Fact]
    public void Build_ShouldReturnSameInstanceIfNotReset()
    {
        // Arrange
        var builder = new PotionBuilder();
        builder.SetName("Potion1");
        var potion1 = builder.Build();

        builder.SetName("Potion2");
        var potion2 = builder.Build();

        // Assert
        Assert.Same(potion1, potion2);
        Assert.Equal("Potion2", potion2.Name);
    }
}