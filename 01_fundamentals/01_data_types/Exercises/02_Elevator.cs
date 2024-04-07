namespace Elevator;

class Program
{
    static void Main()
    {
        var peopleCount = double.Parse(Console.ReadLine()!);
        var elevatorCapacity = double.Parse(Console.ReadLine()!);

        var courses = (int)Math.Ceiling(peopleCount / elevatorCapacity);

        Console.WriteLine(courses);
    }
}
