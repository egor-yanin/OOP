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
    public void Build_ShouldResetBuilderState()
    {
        // Arrange
        var builder = new PotionBuilder();
        builder.SetName("Potion 1");
        builder.SetHealAmount(15);
        var first = builder.Build();

        // Act
        builder.SetName("Potion 2");
        builder.SetHealAmount(5);
        var second = builder.Build();

        // Assert
        var potion1 = Assert.IsType<HealPotion>(first);
        var potion2 = Assert.IsType<HealPotion>(second);

        Assert.Equal("Potion 1", potion1.Name);
        Assert.Equal(15, potion1.HealAmount);

        Assert.Equal("Potion 2", potion2.Name);
        Assert.Equal(5, potion2.HealAmount);
    }
}