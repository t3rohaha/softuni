namespace Classes.P00_BankAccount;

public class Program
{
    public static void Main()
    {
        var accountManager = new AccountManager();

        while (true)
        {
            var cmdArgs = Console.ReadLine()!.Split(' ');

            if (cmdArgs[0] == "End")
            {
                break;
            }

            if (cmdArgs[0] == "Create")
            {
                var id = int.Parse(cmdArgs[1]);
                accountManager.Create(id);
                continue;
            }

            if (cmdArgs[0] == "Deposit")
            {
                var id = int.Parse(cmdArgs[1]);
                var amount = decimal.Parse(cmdArgs[2]);
                accountManager.Deposit(id, amount);
                continue;
            }

            if (cmdArgs[0] == "Withdraw")
            {
                var id = int.Parse(cmdArgs[1]);
                var amount = decimal.Parse(cmdArgs[2]);
                accountManager.Withdraw(id, amount);
                continue;
            }

            if (cmdArgs[0] == "Print")
            {
                var id = int.Parse(cmdArgs[1]);
                accountManager.Print(id);
                continue;
            }
        }
    }
}