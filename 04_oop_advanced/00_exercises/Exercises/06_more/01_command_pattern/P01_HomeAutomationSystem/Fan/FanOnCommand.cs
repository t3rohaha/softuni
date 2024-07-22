namespace More.CommandPattern.P01_HomeAutomationSystem.Fan;
public class FanOnCommand : ICommand
{
    private Fan _fan;

    public FanOnCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.On();
    }
}