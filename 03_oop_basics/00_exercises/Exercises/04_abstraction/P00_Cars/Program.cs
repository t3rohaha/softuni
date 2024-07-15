using Abstraction.P00_Cars.Interfaces;
using Abstraction.P00_Cars.Models;

namespace Abstraction.P00_Cars;
public class Program
{
    public static void Main()
    {
        ICar seat = new Seat("Leon", "Gray");
        ICar tesla = new Tesla("Model 3", "Red", 2);

        Console.WriteLine(seat.ToString());
        Console.WriteLine(tesla.ToString());
    }
}