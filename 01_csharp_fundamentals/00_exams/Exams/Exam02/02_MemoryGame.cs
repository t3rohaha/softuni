namespace Exam02;

public class MemoryGame
{
    public static void Main()
    {
        var nums = Console.ReadLine()!.Split(" ").ToList();
        var moves = 0;
        var outOfRange = (int i) => i < 0 || i > nums.Count - 1;

        while (true)
        {
            moves++;
            var input = Console.ReadLine()!;

            if (input == "end")
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", nums));
                break;
            }

            var idxs = input.Split(" ").Select(int.Parse).ToArray();
            var i1 = idxs[0];
            var i2 = idxs[1];

            if (i1 == i2 || outOfRange(i1) || outOfRange(i2))
            {
                nums.Insert(nums.Count / 2, $"-{moves}a");
                nums.Insert(nums.Count / 2, $"-{moves}a");
                Console.WriteLine("Invalid input! Adding additional elements to the board");
                continue;
            }

            var n1 = nums[i1];
            var n2 = nums[i2];

            if (n1 != n2)
            {
                Console.WriteLine("Try again!");
                continue;
            }

            if (n1 == n2)
            {
                if (i2 > i1)
                {
                    nums.RemoveAt(i2);
                    nums.RemoveAt(i1);
                }
                else
                {
                    nums.RemoveAt(i1);
                    nums.RemoveAt(i2);
                }

                Console.WriteLine($"Congrats! You have found matching elements - {n1}!");
            }


            if (nums.Count == 0)
            {
                Console.WriteLine($"You have won in {moves} turns!");
                break;
            }
        }
    }      
}