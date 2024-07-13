using Abstraction.P00_Cars.Interfaces;

namespace Abstraction.P00_Cars.Models;
public class Seat : ICar
{
    public Seat(string model, string color)
    {
        Model = model;
        Color = color;
    }

    public string Model { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        var output = $"{Color} Seat {Model}\n";
        output += $"{((ICar)this).Start()}\n";
        output += $"{((ICar)this).Stop()}";
        return output;
    }
}
