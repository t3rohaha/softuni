namespace PizzaCalories.Tests;

public class ToppingTests
{
    [Fact]
    public void Initialization_InvalidType_ShouldThrowException()
    {
        var sut = () => { new Topping("Ketchup", 1); };

        var exception = Assert.Throws<Exception>(sut);

        Assert.Equal($"Cannot place Ketchup on top of your pizza.", exception.Message);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(51)]
    public void Initialization_WeightOutOfRange_ShouldThrowException(decimal weight)
    {
        var sut = () => { new Topping("Sauce", weight); };

        var exception = Assert.Throws<Exception>(sut);

        Assert.Equal($"Sauce weight should be in the range [0..50].", exception.Message);
    }

    [Theory]
    [InlineData(72, "Meat", 30)]
    [InlineData(36, "Sauce", 20)]
    public void TotalCalories_ShouldMatchExpectedResult(decimal expected, string type, decimal weight)
    {
        var sut = new Topping(type, weight);

        Assert.Equal(expected, sut.TotalCalories);
    }
}