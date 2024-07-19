using UnitTesting.P00_Lab.Models;

namespace Exercises.Tests.UnitTesting.P00_Lab;
public class DummyTests
{
    [Fact]
    public void Dummy_LosesHealth_IfAttacked()
    {
        var dummy = new Dummy(20, 20);

        dummy.TakeAttack(10);

        Assert.Equal(10, dummy.Health);
    }

    [Fact]
    public void DeadDummy_ThrowsException_IfAttacked()
    {
        var dummy = new Dummy(0, 20);

        var result = () => dummy.TakeAttack(10);

        Assert.Throws<InvalidOperationException>(result);
    }

    [Fact]
    public void DeadDummy_GivesXP_OnGiveExperience()
    {
        var dummy = new Dummy(0, 20);

        var result = dummy.GiveExperience();

        Assert.Equal(20, result);
    }

    [Fact]
    public void AliveDummy_ThrowsException_OnGiveExperience()
    {
        var dummy = new Dummy(1, 20);

        var result = () => { dummy.GiveExperience(); };

        Assert.Throws<InvalidOperationException>(result);
    }
}