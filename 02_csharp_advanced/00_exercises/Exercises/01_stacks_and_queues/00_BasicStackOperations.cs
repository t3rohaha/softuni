namespace StacksAndQueues;

public class BasicStackOperations
{
    public static void Main()
    {
        int[] input = Console
        .ReadLine()!
        .Split(' ')
        .Select(int.Parse)
        .ToArray();

        int n = input[0];   // Number of elements to push
        int s = input[1];   // Number of elements to pop
        int x = input[2];   // Element to look for

        int[] elements = Console
        .ReadLine()!
        .Split(' ')
        .Select(int.Parse)
        .ToArray();

        var stack = new Stack<int>();

        for (var i = 0; i < n; i++) // Push N elements
            stack.Push(elements[i]);

        for (var i = 0; i < s; i++) // Pop S elements
            stack.Pop();

        if (stack.Contains(x))      // Look for X
        {
            Console.WriteLine("true");
        }
        else if (stack.Count > 0)
        {
            Console.WriteLine(stack.Min());
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
