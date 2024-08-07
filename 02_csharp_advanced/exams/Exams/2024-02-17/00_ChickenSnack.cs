namespace Exams;

public class ChickenSnack
{
    public static void Main()
    {
        // Coins in Henry's pocket as STACK
        var cStack = new Stack<int>(
            Console.ReadLine()!
            .Split(' ')
            .Select(int.Parse)
            .ToArray()
        );

        // Prices in shop as QUEUE
        var pQueue = new Queue<int>(
            Console.ReadLine()!
            .Split(' ')
            .Select(int.Parse)
            .ToArray()
        );

        int foodCount = 0;

        while (cStack.Count > 0 && pQueue.Count > 0)
        {
            var c = cStack.Pop();
            var p = pQueue.Dequeue();

            if (c == p)
            {
                foodCount++;
            }
            else if (c > p)
            {
                foodCount++;
                int change = c - p;
                if (cStack.Count > 0) cStack.Push(cStack.Pop() + change);
                else cStack.Push(change);
            }
        }

        switch (foodCount)
        {
            case 0:
                Console.WriteLine($"Henry remained hungry. He will try next weekend again.");
                break;
            case 1:
                Console.WriteLine($"Henry ate: {foodCount} food.");
                break;
            case < 4:
                Console.WriteLine($"Henry ate: {foodCount} foods.");
                break;
            case >= 4:
                Console.WriteLine($"Gluttony of the day! Henry ate {foodCount} foods.");
                break;
        }
    }
}