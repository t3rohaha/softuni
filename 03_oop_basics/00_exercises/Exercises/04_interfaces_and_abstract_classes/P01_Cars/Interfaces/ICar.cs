namespace InterfacesAndAbstractClasses.P01_Cars.Interfaces;
public interface ICar
{
    public string Model { get; set; }
    public string Color { get; set; }

    public string Start()
    {
        return "Engine start";
    }
    public string Stop()
    {
        return "Breaaak!";
    }
}