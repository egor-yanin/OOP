using Xunit;

public class ArmorBuilderTests
{
    [Fact]
    public void Build_ShouldReturnArmorWithSetProperties()
    {
        // Arrange
        var builder = new ArmorBuilder();

        builder.SetName("Chainmail");
        builder.SetWeight(12.5f);
        builder.SetDescription("Sturdy chainmail armor");
        builder.SetDefense(30);

        // Act
        var item = builder.Build();

        // Assert
        var armor = Assert.IsType<Armor>(item);
        Assert.Equal("Chainmail", armor.Name);
        Assert.Equal(12.5f, armor.Weight);
        Assert.Equal("Sturdy chainmail armor", armor.Description);
        Assert.Equal(30, armor.Defense);
    }

    [Fact]
    public void Reset_ShouldClearPreviousState()
    {
        // Arrange
        var builder = new ArmorBuilder();
        builder.SetName("Leather Armor");
        builder.SetDefense(10);

        // Act
        builder.Reset();
        var item = builder.Build();

        // Assert
        var armor = Assert.IsType<Armor>(item);
        Assert.NotEqual("Leather Armor", armor.Name);
        Assert.NotEqual(10, armor.Defense);
    }

    [Fact]
    public void Build_ShouldResetBuilderState()
    {
        // Arrange
        var builder = new ArmorBuilder();
        builder.SetName("Plate");
        builder.SetDefense(50);
        var first = builder.Build();

        builder.SetName("Cloth");
        builder.SetDefense(5);
        var second = builder.Build();

        // Assert
        var armor1 = Assert.IsType<Armor>(first);
        var armor2 = Assert.IsType<Armor>(second);

        Assert.Equal("Plate", armor1.Name);
        Assert.Equal(50, armor1.Defense);

        Assert.Equal("Cloth", armor2.Name);
        Assert.Equal(5, armor2.Defense);
    }
}