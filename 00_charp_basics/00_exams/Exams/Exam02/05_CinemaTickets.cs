namespace Exam02;

public class CinemaTickets
{
    public static void Main()
    {
        var tickets = 0;
        var student = 0;
        var standard = 0;
        var kid = 0;

        while (true)
        {
            var input1 = Console.ReadLine()!;
            if (input1 == "Finish") break;

            var movie = input1;
            var totalSeats = int.Parse(Console.ReadLine()!);
            var freeSeats = totalSeats;

            while (freeSeats != 0)
            {
                var input2 = Console.ReadLine()!;
                if (input2 == "End") break;

                tickets++;
                freeSeats--;

                var ticketType = input2;
                switch (ticketType)
                {
                    case "student": student++; break;
                    case "standard": standard++; break;
                    case "kid": kid++; break;
                }
            }

            var perc = (((double)totalSeats - freeSeats) / totalSeats) * 100;
            Console.WriteLine($"{movie} - {perc:F2}% full.");
        }

        Console.WriteLine($"Total tickets: {tickets}");
        Console.WriteLine($"{(((double)student / tickets) * 100):F2}% student tickets.");
        Console.WriteLine($"{(((double)standard / tickets) * 100):F2}% standard tickets.");
        Console.WriteLine($"{(((double)kid / tickets) * 100):F2}% kids tickets.");
    }
}