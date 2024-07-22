namespace More.CommandPattern.P01_HomeAutomationSystem;
public class RemoteControl
{
    private ICommand[] _btn1Commands;
    private ICommand[] _btn2Commands;
    private int _btn1Current = 0;
    private int _btn2Current = 0;

    public RemoteControl(ICommand[] btn1Commands, ICommand[] btn2Commands)
    {
        _btn1Commands = btn1Commands;
        _btn2Commands = btn2Commands;
    }

    public void Execute1()
    {
        this.Execute(_btn1Commands, ref _btn1Current);
    }

    public void Execute2()
    {
        this.Execute(_btn2Commands, ref _btn2Current);
    }

    private void Execute(ICommand[] commands, ref int current)
    {
        current++;

        if (current > commands.Length - 1)
        {
            current = 0;
        }

        commands[current].Execute();
    }
}