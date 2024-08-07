using UnitTesting.P00_Lab.Models;

namespace Exercises.Tests.UnitTesting.P00_Lab;
public class AxeTests
{
    [Fact]
    public void Attack_ValidInput_DecreasesDurability()
    {
        var dummy = new Dummy(20, 20);
        var axe = new Axe(10, 10);

        axe.Attack(dummy);

        Assert.Equal(9, axe.DurabilityPoints);
    }

    [Fact]
    public void Attack_BrokenAxe_ThrowsInvalidOperationException()
    {
        var dummy = new Dummy(20, 20);
        var axe = new Axe(10, 0);

        var result = () => axe.Attack(dummy);

        Assert.Throws<InvalidOperationException>(result);
    }
}