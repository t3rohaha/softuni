public static class Skeleton
{
    public static void Solve()
    {
        var m = int.Parse(Console.ReadLine()!);     // Minutes of the time to beat
        var s = int.Parse(Console.ReadLine()!);     // Seconds of the time to beat
        var d = double.Parse(Console.ReadLine()!);  // Distance of track in meters
        var p = int.Parse(Console.ReadLine()!);     // Personal time in seconds for 100 meters

        var recordTime = m * 60 + s;                // Time to beat in seconds
        var personalTime = d / 100 * p;             // Personal time in seconds
        var personalTimeSubtraction = 0d;           // Time in seconds that will be subracted from personal time

        if (d > 120) 
        {
            personalTimeSubtraction = d / 120 * 2.5;
        }

        personalTime -= personalTimeSubtraction;

        if (personalTime <= recordTime)
        {
            Console.WriteLine("Marin Bangiev won an Olympic quota!");
            Console.WriteLine($"His time is {personalTime:0.000}.");
        }
        else
        {
            var diff = personalTime - recordTime;
            Console.WriteLine($"No, Marin failed! He was {diff:0.000} second slower.");
        }
    }
}
