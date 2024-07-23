using UnitTesting.P00_Lab.Interfaces;

namespace UnitTesting.P00_Lab.Models;
public class Dummy : ITarget
{
    public Dummy(int health, int experience)
    {
        this.Health = health;
        this.Experience = experience;
    }

    public int Health { get; private set; }
    public int Experience { get; private set; }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.Health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.Experience;
    }

    public bool IsDead()
    {
        return this.Health <= 0;
    }
}
