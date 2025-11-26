using Xunit;

public class WeaponBuilderTests
{
    [Fact]
    public void Build_ShouldReturnWeaponWithSetProperties()
    {
        // Arrange
        var builder = new WeaponBuilder();

        builder.SetName("Axe");
        builder.SetWeight(5.5f);
        builder.SetDescription("Battle axe");
        builder.SetDamage(42);

        // Act
        var item = builder.Build();

        // Assert
        var weapon = Assert.IsType<Weapon>(item);
        Assert.Equal("Axe", weapon.Name);
        Assert.Equal(5.5f, weapon.Weight);
        Assert.Equal("Battle axe", weapon.Description);
        Assert.Equal(42, weapon.Damage);
    }

    [Fact]
    public void Reset_ShouldClearPreviousState()
    {
        // Arrange
        var builder = new WeaponBuilder();
        builder.SetName("Sword");
        builder.SetDamage(10);

        // Act
        builder.Reset();
        var item = builder.Build();

        // Assert
        var weapon = Assert.IsType<Weapon>(item);
        Assert.NotEqual("Sword", weapon.Name);
        Assert.NotEqual(10, weapon.Damage);
    }

    [Fact]
    public void Build_ShouldResetBuilderState()
    {
        // Arrange
        var builder = new WeaponBuilder();
        builder.SetName("Bow");
        builder.SetDamage(15);
        var first = builder.Build();

        // Act
        builder.SetName("Dagger");
        builder.SetDamage(5);
        var second = builder.Build();

        // Assert
        var weapon1 = Assert.IsType<Weapon>(first);
        var weapon2 = Assert.IsType<Weapon>(second);

        Assert.Equal("Bow", weapon1.Name);
        Assert.Equal(15, weapon1.Damage);

        Assert.Equal("Dagger", weapon2.Name);
        Assert.Equal(5, weapon2.Damage);
    }
}