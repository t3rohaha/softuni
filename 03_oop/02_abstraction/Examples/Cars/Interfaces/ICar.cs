namespace Cars.Interfaces;

public interface ICar
{
    public string Model { get; set; }
    public string Color { get; set; }

    public string Start() => "Engine Start";
    public string Stop() => "Breaaak!";
}