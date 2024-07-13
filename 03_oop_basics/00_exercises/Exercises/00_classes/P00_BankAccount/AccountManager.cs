namespace Classes.P00_BankAccount;
public class AccountManager
{
    private List<BankAccount> _accounts;

    public AccountManager()
    {
        _accounts = new List<BankAccount>();
    }

    public void Create(int id)
    {
        if (_accounts.Any(x => x.Id == id))
        {
            Console.WriteLine("Account already exists");
            return;
        }

        _accounts.Add(new BankAccount(id));
    }

    public void Deposit(int id, decimal amount)
    {
        var acc = _accounts.FirstOrDefault(x => x.Id == id);

        if (acc is null)
        {
            Console.WriteLine("Account does not exist");
            return;
        }
        
        acc.Deposit(amount);
    }

    public void Withdraw(int id, decimal amount)
    {
        var acc = _accounts.FirstOrDefault(x => x.Id == id);

        if (acc is null)
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        if (acc.Balance < amount)
        {
            Console.WriteLine("Insufficient balance");
            return;
        }
        
        acc.Withdraw(amount);
    }

    public void Print(int id)
    {
        var acc = _accounts.FirstOrDefault(x => x.Id == id);

        if (acc is null)
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        Console.WriteLine(acc.ToString());
    }
}