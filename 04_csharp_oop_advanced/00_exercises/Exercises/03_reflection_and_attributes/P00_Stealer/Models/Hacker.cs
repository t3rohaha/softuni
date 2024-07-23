namespace ReflectionAndAttributes.P00_Stealer.Models;
// This class is not encapsulated properly on purpose.
public class Hacker
{
    public string username = "securityGod82";
    private string _password = "mySuperSecretPassw0rd";

    private int Id { get; set; }

    public double BankAccountBalance { get; private set; }

    public string Password
    {
        get => _password;
        set => _password = value;
    }

    public void DownloadAllBankAccountsInTheWorld()
    {
        Console.WriteLine("Bank accounts downloaded!");
    }
}
