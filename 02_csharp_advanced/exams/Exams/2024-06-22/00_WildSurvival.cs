namespace Exams;

public class WildSurvival
{
    public static void Main()
    {
        var beesInput = Console.ReadLine()!.Split(' ').Select(int.Parse);
        var enemiesInput = Console.ReadLine()!.Split(' ').Select(int.Parse);

        var beesQueue = new Queue<int>(beesInput);
        var enemiesStack = new Stack<int>(enemiesInput);

        while (beesQueue.Any() && enemiesStack.Any())
        {
            var beePower = beesQueue.Dequeue();
            var enemyPower = enemiesStack.Pop() * 7;

            if (enemyPower > beePower)
            {
                enemyPower -= beePower;
                var survivals = Math.Ceiling((decimal)enemyPower / 7);
                enemiesStack.Push((int)survivals);
                continue;
            }

            if (beePower > enemyPower)
            {
                beePower -= enemyPower;
                beesQueue.Enqueue(beePower);
                continue;
            }
        }

        Console.WriteLine("The final battle is over!");
        if (beesQueue.Count == 0 && enemiesStack.Count == 0)
            Console.WriteLine("But no one made it out alive!");
        if (beesQueue.Count > 0)
            Console.WriteLine($"Bee groups left: {string.Join(", ", beesQueue)}");
        if (enemiesStack.Count > 0)
            Console.WriteLine($"Bee-eater groups left: {string.Join(", ", enemiesStack.Reverse())}");
    }
}