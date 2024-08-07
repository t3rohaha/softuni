namespace More.CommandPattern.P01_HomeAutomationSystem.Garage;
public class GarageOpenCommand : ICommand
{
    private Garage _garage;

    public GarageOpenCommand(Garage garage)
    {
        _garage = garage;
    }

    public void Execute()
    {
        _garage.Open();
    }
}