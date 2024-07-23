namespace More.CommandPattern.P01_HomeAutomationSystem.Garage;
public class GarageCloseCommand : ICommand
{
    private Garage _garage;

    public GarageCloseCommand(Garage garage)
    {
        _garage = garage;
    }

    public void Execute()
    {
        _garage.Close();
    }
}