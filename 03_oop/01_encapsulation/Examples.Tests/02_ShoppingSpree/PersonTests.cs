namespace ShoppingSpree.Tests;

public class PersonTests
{
    [Fact]
    public void Initialize_EmptyName_ThrowException()
    {
        var sut = () => { var person = new Person("", 1); };
        Assert.Throws<ArgumentException>(sut);
    }

    [Fact]
    public void Initialize_NegativeMoney_ThrowsException()
    {
        var sut = () => { var person = new Person("John", -1); };
        Assert.Throws<ArgumentException>(sut);
    }

    [Fact]
    public void Initialize_ValidArgs_ShouldSetName()
    {
        var sut = new Person("John", 1);
        Assert.Equal("John", sut.Name);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    public void Initialize_ValidArgs_ShouldSetMoney(decimal expected, decimal money)
    {
        var sut = new Person("John", money);
        Assert.Equal(expected, sut.Money);
    }

    [Fact]
    public void BuyProduct_NotEnoughMoney_ShouldReturnFalse()
    {
        var product = new Product("Orange", 1);
        var sut = new Person("John", 0);
        var result = sut.BuyProduct(product);
        Assert.False(result);
    }

    [Fact]
    public void BuyProduct_EnoughMoney_ShouldReturnTrue()
    {
        var product = new Product("Orange", 1);
        var sut = new Person("John", 2);
        var result = sut.BuyProduct(product);
        Assert.True(result);
    }

    [Fact]
    public void BuyProduct_EnoughMoney_ShouldDecreaseMoney()
    {
        var product = new Product("Orange", 1);
        var sut = new Person("John", 2);
        sut.BuyProduct(product);
        var result = sut.Money;
        Assert.Equal(1, result);
    }
}