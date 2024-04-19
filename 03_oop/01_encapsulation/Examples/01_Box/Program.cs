namespace Box;

public class Program
{
    public static void Main()
    {
        try
        {
            var box = new Box(2, 3, 4);
            Console.WriteLine($"Surface Area - {box.SurfaceArea():0.00}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():0.00}");
            Console.WriteLine($"Volume - {box.Volume():0.00}");

            var box2 = new Box(0, 0, 0);    // Throws ArgumentException.
        }
        catch(ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }
}