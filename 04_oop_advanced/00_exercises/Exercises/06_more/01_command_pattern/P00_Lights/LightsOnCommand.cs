namespace More.CommandPattern.P00_Lights;
public class LightsOnCommand : ICommand
{
    private Light _light;

    public LightsOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }
}
