namespace PizzaCalories;

public class PizzaTests
{
    private readonly Pizza _sut;

    public PizzaTests()
    {
        _sut = new Pizza("New York", new Dough("White", "Crispy", 100));
    }
    [Theory]
    [InlineData("")]
    [InlineData("1234567890123456")]
    public void Initialize_InvalidName_ThrowsException(string name)
    {
        var sut = () => { new Pizza(name, new Dough("White", "Crispy", 100)); };
        var ex = Assert.Throws<Exception>(sut);
        Assert.Equal("Pizza name should be between 1 and 15 symbols.", ex.Message);
    }

    [Fact]
    public void AddTopping_ValidData_ShouldIncreaseToppingsCount()
    {
        _sut.AddTopping(new Topping("Meat", 20));
        Assert.Equal(1, _sut.ToppingsCount);
    }

    [Fact]
    public void AddTopping_MaxToppingsExceeded_ShouldThrowException()
    {
        for (var i = 0; i < 10; i++)
            _sut.AddTopping(new Topping("Meat", 20));

        var act = () => { _sut.AddTopping(new Topping("Meat", 20)); };

        var ex = Assert.Throws<Exception>(act);

        Assert.Equal("Number of toppings should be in range [0..10].", ex.Message);
    }
}