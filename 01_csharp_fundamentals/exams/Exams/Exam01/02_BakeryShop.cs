namespace Exam01;

public class BakeryShopProgram
{
    public static void Main()
    {
        var shop = new BakeryShop();

        while (true)
        {
            string[] input = Console.ReadLine()!.Split(' ');

            string cmd = input[0];

            if (cmd == "Complete") break;

            string[] arguments = input.Skip(1).ToArray();

            switch (cmd)
            {
                case "Receive":
                    shop.Receive(arguments[1], int.Parse(arguments[0]));
                    break;
                case "Sell":
                    shop.Sell(arguments[1], int.Parse(arguments[0]));
                    break;
            }
        }

        shop.PrintOutput();
    }
}

class BakeryShop
{
    private int _sold;
    private Dictionary<string, int> _stock;

    public BakeryShop()
    {
        _sold = 0;
        _stock = new Dictionary<string, int>();
    }

    public void PrintOutput()
    {
        foreach (var kvp in _stock)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        Console.WriteLine($"All sold: {_sold} goods");
    }

    public void Receive(string food, int qty)
    {
        if (qty <= 0) return;

        if (!_stock.ContainsKey(food)) _stock.Add(food, 0);

        _stock[food] += qty;
    }

    public void Sell(string food, int qty)
    {
        if (!_stock.ContainsKey(food))
        {
            Console.WriteLine($"You do not have any {food}.");
            return;
        }

        if (_stock[food] < qty)
        {
            int stockQty = _stock[food];
            _sold += stockQty;
            _stock.Remove(food);
            Console.WriteLine($"There aren't enough {food}. You sold the last {stockQty} of them.");
            return;
        }

        _stock[food] -= qty;
        _sold += qty;
        Console.WriteLine($"You sold {qty} {food}.");

        if (_stock[food] == 0) _stock.Remove(food);
    }
}
