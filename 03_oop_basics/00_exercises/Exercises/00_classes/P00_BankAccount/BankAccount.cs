namespace Classes.P00_BankAccount;

public class BankAccount
{
    public BankAccount(int id)
    {
        Id = id;
        Balance = 0;
    }

    public int Id { get; private set; }
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount > 0) Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && Balance - amount >= 0)
            Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account: {Id}, Balance: {Balance}";
    }
}