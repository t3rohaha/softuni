namespace Encapsulation.P03_PizzaCalories;
public class Program
{
    public static void Main()
    {
        Console.Write("Pizza Name: ");
        var pizzaName = Console.ReadLine()!;
        Pizza pizza;

        while (true)
        {
            try
            {
                Console.Write("Dough: ");
                var doughArgs = Console.ReadLine()!.Split(' ');
                var dough = new Dough(doughArgs[0],
                                      doughArgs[1],
                                      decimal.Parse(doughArgs[2]));
                pizza = new Pizza(pizzaName, dough);
                break;
            }
            catch (Exception ex) { PrintError(ex.Message); }
        }

        while (true)
        {
            try
            {
                Console.Write("Topping: ");
                var toppingArgs = Console.ReadLine()!.Split(' ');
                if (toppingArgs[0] == "END") break;
                var topping = new Topping(toppingArgs[0],
                                          decimal.Parse(toppingArgs[1]));
                pizza.AddTopping(topping);
            }
            catch (Exception ex) { PrintError(ex.Message); }
        }

        Console.WriteLine(pizza.ToString());
    }

    private static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
