using InterfacesAndAbstractClasses.P01_Cars.Interfaces;

namespace InterfacesAndAbstractClasses.P01_Cars.Models;
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
        return $"{Color} Seat {Model}";
    }
}