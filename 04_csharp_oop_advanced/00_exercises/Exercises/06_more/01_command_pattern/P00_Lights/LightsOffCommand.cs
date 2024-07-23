namespace More.CommandPattern.P00_Lights;
public class LightsOffCommand : ICommand
{
    private Light _light;

    public LightsOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }
}
