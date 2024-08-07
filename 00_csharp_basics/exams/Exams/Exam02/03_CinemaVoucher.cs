namespace Exam02;

public class CinemaVoucher
{
    public static void Main()
    {
        var voucher = int.Parse(Console.ReadLine()!);
        var tickets = 0;
        var other = 0;

        while (true)
        {
            var input = Console.ReadLine()!;

            if (input == "End") break;

            if (input.Length > 8)
            {
                var price = input[0] + input[1];
                voucher -= price;
                if (voucher < 0) break;
                tickets++;
            }
            else
            {
                var price = input[0];
                voucher -= price;
                if (voucher < 0) break;
                other++;
            }
        }

        Console.WriteLine(tickets);
        Console.WriteLine(other);
    }
}