using Abstraction.P00_Cars.Interfaces;

namespace Abstraction.P00_Cars.Models;
public class Tesla : IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        Model = model;
        Color = color;
        Battery = battery;
    }

    public int Battery { get; set; }
    public string Color { get; set; }
    public string Model { get; set; }

    public override string ToString()
    {
        var output = $"{Color} Seat {Model} with {Battery} Batteries\n";
        output += $"{((IElectricCar)this).Start()}\n";
        output += $"{((IElectricCar)this).Stop()}";
        return output;
    }
}