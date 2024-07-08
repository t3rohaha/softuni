namespace Exam02;

public class TheLift
{
    public static void Main()
    {
        var ppl = int.Parse(Console.ReadLine()!);
        var wagons = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();
        var maxCapacity = 4;
        var total = 0;

        for (var i = 0; i < wagons.Length; i++)
        {
            var temp = maxCapacity -= wagons[i];

            if (ppl < temp) temp = ppl;

            wagons[i] += temp;
            ppl -= temp;
            total += wagons[i];

            if (ppl == 0) break;
        }

        if (ppl != 0)
        {
            Console.WriteLine($"There isn't enough space! {ppl} people in a queue!");
        }

        if (total != wagons.Length * maxCapacity)
        {
            Console.WriteLine("The lift has empty spots!");
        }

        Console.WriteLine(string.Join(' ', wagons));
    }
}