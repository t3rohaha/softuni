using Cars.Interfaces;
using Cars.Models;

namespace Cars;

public class Program
{
    public static void Main()
    {
        ICar seat = new Seat("Leon", "Gray");
        IElectricCar tesla = new Tesla("Model 3", "Red", 2);

        Console.WriteLine(seat.ToString());
        Console.WriteLine(tesla.ToString());
    }
}