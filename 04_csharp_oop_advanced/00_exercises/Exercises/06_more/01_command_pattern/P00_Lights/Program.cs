namespace More.CommandPattern.P00_Lights;
public class Program
{
    public static void Main()
    {
        var light = new Light();

        var on = new LightsOnCommand(light);
        var off = new LightsOffCommand(light);

        var remote = new RemoteControl(on);
        remote.PressButton();

        remote.Command = off;
        remote.PressButton();
    }
}