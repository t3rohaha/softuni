namespace UnitTesting.P00_Lab.Interfaces;
public interface ITarget
{
    void TakeAttack(int attackPoints);
    int GiveExperience();
    bool IsDead();
}