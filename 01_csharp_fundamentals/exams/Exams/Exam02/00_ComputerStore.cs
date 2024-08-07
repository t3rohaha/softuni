namespace Exam02;

public class ComputerStore
{
    public static void Main()
    {
        var total = 0m;
        var orderType = "";

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "special" || input == "regular")
            {
                orderType = input;
                break;
            }

            var price = decimal.Parse(input!);

            if (price <= 0)
            {
                Console.WriteLine("Invalid price!");
                continue;
            }

            total += price;
        }

        if (total == 0) Console.WriteLine("Invalid order!");
        else
        {
            var taxes = total * 0.2m;
            var grandTotal = total + taxes;

            if (orderType == "special") grandTotal -= grandTotal * 0.1m;

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {total:F2}$");
            Console.WriteLine($"Taxes: {taxes:F2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {grandTotal:F2}$");
        }
    }
}