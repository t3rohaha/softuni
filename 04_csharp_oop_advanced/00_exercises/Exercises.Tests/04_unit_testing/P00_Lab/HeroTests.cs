using Moq;
using UnitTesting.P00_Lab.Interfaces;
using UnitTesting.P00_Lab.Models;

namespace Exercises.Tests.UnitTesting.P00_Lab;
public class HeroTests
{
    [Fact]
    public void Hero_GainsXP_IfTargetDies()
    {
        var weapon = new Mock<IWeapon>();
        var target = new Mock<ITarget>();
        target.Setup(t => t.IsDead()).Returns(true);
        target.Setup(t => t.GiveExperience()).Returns(10);
        var hero = new Hero("Frank Lampard", weapon.Object);

        hero.Attack(target.Object);

        Assert.Equal(10, hero.Experience);
    }
}