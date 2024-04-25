namespace ShoppingSpree.Tests;

public class ProductTests
{
    [Fact]
    public void Initialize_EmptyName_ThrowException()
    {
        var sut = () => { var product = new Product("", 1); };
        Assert.Throws<ArgumentException>(sut);
    }

    [Fact]
    public void Initialize_NegativePrice_ThrowsException()
    {
        var sut = () => { var product = new Product("Orange", -1); };
        Assert.Throws<ArgumentException>(sut);
    }

    [Fact]
    public void Initialize_ZeroPrice_ThrowsException()
    {
        var sut = () => { var product = new Product("Orange", 0); };
        Assert.Throws<ArgumentException>(sut);
    }

    [Fact]
    public void Initialize_ValidArgs_ShouldSetName()
    {
        var sut = new Product("Orange", 1);
        Assert.Equal("Orange", sut.Name);
    }

    [Theory]
    [InlineData(0.5, 0.5)]
    [InlineData(1, 1)]
    public void Initialize_ValidArgs_ShouldSetPrice(decimal expected, decimal price)
    {
        var sut = new Product("Orange", price);
        Assert.Equal(expected, sut.Price);
    }
}