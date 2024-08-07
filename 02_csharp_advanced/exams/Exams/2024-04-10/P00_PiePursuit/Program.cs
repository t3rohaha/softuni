namespace Exams.P00_PiePursuit;
public class Program
{
    public static void Main()
    {
        // int[] c1 = [5, 8, 4, 6];
        // int[] p1 = [3, 7, 2, 9];

        // int[] c2 = [4, 6, 8, 10, 12, 16];
        // int[] p2 = [16, 12, 10, 8, 6, 4];

        // int[] c3 = [3, 3, 3, 3, 3];
        // int[] p3 = [4, 4, 4, 4];

        var contestants = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        var pies = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

        var cQueue = new Queue<int>(contestants);
        var pStack = new Stack<int>(pies);

        while (cQueue.Any() && pStack.Any())
        {
            var c = cQueue.Dequeue();
            var p = pStack.Pop();

            if (c >= p)
            {
                c -= p;
                if (c > 0) cQueue.Enqueue(c);
            }
            else
            {
                p -= c;
                if (p == 1 && pStack.Any()) p += pStack.Pop();
                pStack.Push(p);
            }
        }

        if (!pStack.Any() && cQueue.Any())
        {
            Console.WriteLine("We will have to wait for more pies to be baked!");
            Console.WriteLine($"Contestants left: {string.Join(", ", cQueue)}");
        }
        else if (!pStack.Any() && !cQueue.Any())
        {
            Console.WriteLine("We have a champion!");
        }
        else if (pStack.Any() && !cQueue.Any())
        {
            Console.WriteLine("Our contestants need to rest!");
            Console.WriteLine($"Pies left: {string.Join(", ", pStack)}");
        }
    }
}