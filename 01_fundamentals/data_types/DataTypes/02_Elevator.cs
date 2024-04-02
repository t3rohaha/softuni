public static class Elevator
{
    public static void Solve()
    {
        var peopleCount = double.Parse(Console.ReadLine()!);
        var elevatorCapacity = double.Parse(Console.ReadLine()!);

        var courses = (int)Math.Ceiling(peopleCount / elevatorCapacity);

        Console.WriteLine(courses);
    }
}
