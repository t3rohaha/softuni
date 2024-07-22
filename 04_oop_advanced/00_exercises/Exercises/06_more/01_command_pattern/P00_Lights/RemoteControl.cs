namespace More.CommandPattern.P00_Lights;
public class RemoteControl
{
    public RemoteControl(ICommand command)
    {
        this.Command = command;
    }

    public ICommand Command { get; set; }

    public void PressButton()
    {
        this.Command.Execute();
    }
}