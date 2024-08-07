using Classes.P00_BankAccount;

namespace Classes.P01_Person;
public class Person
{
    private string _name;
    private int _age;
    private List<BankAccount> _accounts;

    public Person(string name, int age)
    {
        _name = name;
        _age = age;
        _accounts = new List<BankAccount>();
    }

    public Person(string name, int age, List<BankAccount> accounts)
        :this(name, age)
    {
        _accounts.AddRange(accounts);
    }

    public decimal GetBalance()
    {
        return _accounts.Sum(acc => acc.Balance);
    }
}