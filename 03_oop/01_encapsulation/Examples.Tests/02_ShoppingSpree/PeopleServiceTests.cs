namespace ShoppingSpree.Tests;

public class PeopleServiceTests
{
    [Theory]
    [InlineData("", "Apples=1")]
    [InlineData(" ", "Apples=1")]
    [InlineData("John=1;", "Apples=1")]
    [InlineData("John=1;Frank=1;", "Apples=1")]
    [InlineData("John=;Frank=1", "Apples=1")]
    [InlineData("John=1", "1")]
    [InlineData("John=1", " ")]
    [InlineData("John=1", "Apples=1;")]
    [InlineData("John=1", "Apples=1;Oranges=1;")]
    [InlineData("John=1", "Apples=;Oranges=1")]
    public void Initialization_InvalidInputFormat_ShouldThrowException(string people, string products)
    {
        var sut = delegate()
        {
            new ShoppingService(people, products);
        };

        Assert.Throws<ArgumentException>(sut);
    }

    [Theory]
    [InlineData("John=1", "John")] 
    [InlineData("John=1;Frank=1", "John", "Frank")] 
    public void Initialization_ValidPeople_ShouldSeedPeopleWithCorrectNames(string people, params string[] expectedNames)
    {
        var sut = new ShoppingService(people, "Apples=1");

        var result = sut.People.ToArray();

        for (byte i = 0; i < expectedNames.Length; i++)
            Assert.Equal(expectedNames[i], result[i].Name);
    }

    [Theory]
    [InlineData("Apples=1", "Apples")] 
    [InlineData("Apples=1;Oranges=1", "Apples", "Oranges")] 
    public void Initialization_ValidProducts_ShouldSeedProductsWithCorrectNames(string products, params string[] expectedNames)
    {
        var sut = new ShoppingService("John=1", products);

        var result = sut.Products.ToArray();

        for (byte i = 0; i < expectedNames.Length; i++)
            Assert.Equal(expectedNames[i], result[i].Name);
    }

    [Fact]
    public void Shop_NonExistingPerson_ShouldThrowException()
    {
        var sut = new ShoppingService("John=1", "Orange=1");

        var result = () => { sut.Shop("Frank", "Orange"); };

        Assert.Throws<ArgumentException>(result);
    }

    [Fact]
    public void Shop_NonExistingProduct_ShouldThrowException()
    {
        var sut = new ShoppingService("John=1", "Orange=1");

        var result = () => { sut.Shop("John", "Apple"); };

        Assert.Throws<ArgumentException>(result);
    }

    [Fact]
    public void Shop_ValidParams_ShouldReturnTrue()
    {
        var sut = new ShoppingService("John=1", "Orange=1");

        var result = sut.Shop("John", "Orange");

        Assert.True(result);
    }

    [Fact]
    public void Shop_PersonNotEnoughMoney_ShouldReturnFalse()
    {
        var sut = new ShoppingService("John=1", "Orange=2");

        var result = sut.Shop("John", "Orange");

        Assert.False(result);
    }
}
