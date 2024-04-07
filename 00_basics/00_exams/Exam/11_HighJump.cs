namespace HighJump;

class Program
{
    static void Main()
    {
        ushort finalTargetHeight = ushort.Parse(Console.ReadLine()!);
        ushort targetHeight = (ushort)(finalTargetHeight - 30);
        ushort heightCompleted = 0;
        byte jumpsCount = 0;
        byte attempts = 3;

        while (true)
        {
            var attemptHeight = ushort.Parse(Console.ReadLine()!);

            if (attemptHeight > targetHeight)
            {
                heightCompleted = targetHeight;
                targetHeight += 5;
                attempts = 3;
            }
            else attempts--;

            jumpsCount++;

            if (attempts == 0) break;
            if (heightCompleted >= finalTargetHeight) break;
        }

        if (heightCompleted >= finalTargetHeight)
            Console.WriteLine($"Tihomir succeeded, he jumped over {finalTargetHeight}cm after {jumpsCount} jumps.");
        else
            Console.WriteLine($"Tihomir failed at {targetHeight}cm after {jumpsCount} jumps.");
    }
}
