namespace PizzaCalories.Tests;

public class DoughTests
{
    [Fact]
    public void Initialization_InvalidType_ShouldThrowException()
    {
        var sut = () => { new Dough("", "Crispy", 100); };

        var exception = Assert.Throws<Exception>(sut);

        Assert.Equal("Invalid type of dough.", exception.Message);
    }

    [Fact]
    public void Initialization_InvalidTechnique_ShouldThrowException()
    {
        var sut = () => { new Dough("White", "", 100); };

        var exception = Assert.Throws<Exception>(sut);

        Assert.Equal("Invalid baking technique.", exception.Message);
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(201)]
    public void Initialization_WeightOutOfRange_ShouldThrowException(decimal weight)
    {
        var sut = () => { new Dough("White", "Crispy", weight); };

        var exception = Assert.Throws<Exception>(sut);

        Assert.Equal("Dough weight should be in the range [0..200].", exception.Message);
    }

    [Theory]
    [InlineData(270, "White", "Crispy", 100)]
    [InlineData(330, "White", "Chewy", 100)]
    public void TotalCalories_ShouldMatchExpectedResult(decimal expected, string type, string bakingTechnique, decimal weight)
    {
        var sut = new Dough(type, bakingTechnique, weight);

        Assert.Equal(expected, sut.TotalCalories);
    }
}