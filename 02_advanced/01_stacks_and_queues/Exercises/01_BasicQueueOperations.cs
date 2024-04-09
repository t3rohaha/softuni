namespace BasicQueueOperations;

class Program
{
    static void Main()
    {
        int[] input = Console
        .ReadLine()!
        .Split(' ')
        .Select(int.Parse)
        .ToArray();

        int n = input[0];   // Number of elements to enqueue
        int s = input[1];   // Number of elements to dequeue
        int x = input[2];   // Element to look for

        int[] elements = Console
        .ReadLine()!
        .Split(' ')
        .Select(int.Parse)
        .ToArray();

        var queue = new Queue<int>();

        for (var i = 0; i < n; i++) // Enqueue N elements
        {
            queue.Enqueue(elements[i]);
        }

        for (var i = 0; i < s; i++) // Dequeue S elements
        {
            queue.Dequeue();
        }

        if (queue.Contains(x))      // Look for X
        {
            Console.WriteLine("true");
        }
        else if (queue.Count > 0)
        {
            Console.WriteLine(queue.Min());
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
