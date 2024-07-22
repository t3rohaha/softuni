using More.CommandPattern.P01_HomeAutomationSystem.Fan;
using More.CommandPattern.P01_HomeAutomationSystem.Garage;

namespace More.CommandPattern.P01_HomeAutomationSystem;
public class Program
{
    public static void Main()
    {
        var fan = new Fan.Fan();
        var garage = new Garage.Garage();

        var fanON = new FanOnCommand(fan);
        var fanOFF = new FanOffCommand(fan);
        var garageOpen = new GarageOpenCommand(garage);
        var garageClose = new GarageCloseCommand(garage);

        var remote = new RemoteControl
        (
            [fanON, fanOFF],
            [garageOpen, garageClose]
        );

        while (true)
        {
            Console.Write("1, 2: ");
            var btn = Console.ReadKey();
            Console.WriteLine();

            switch (btn.Key)
            {
                case ConsoleKey.D1: remote.Execute1(); break;
                case ConsoleKey.D2: remote.Execute2(); break;
                default: Console.WriteLine("Invalid key!"); break;
            }
        }
    }
}
