// To test in Judge:
// 00 Remove static keyword from class
// 01 Rename Run to Main
static class BakeryShop
{
    public static void Run()
    {
        var stock = new Dictionary<string, int>();
        var sold = 0;

        while (true)
        {
            string[] input = Console.ReadLine()!.Split(' ');

            string cmd = input[0];

            if (cmd == "Complete") break;

            string[] arguments = input.Skip(1).ToArray();

            switch (cmd)
            {
                case "Receive":
                    Receive(stock, int.Parse(arguments[0]), arguments[1]);
                    break;
                case "Sell":
                    sold += Sell(stock, int.Parse(arguments[0]), arguments[1]);
                    break;
            }
        }

        PrintOutput(stock, sold);
    }

    static void PrintOutput(Dictionary<string, int> stock, int sold)
    {
        foreach (var kvp in stock)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        Console.WriteLine($"All sold: {sold} goods");
    }

    static void Receive(Dictionary<string, int> stock, int quantity, string food)
    {
        if (quantity <= 0) return;

        if (!stock.ContainsKey(food)) stock.Add(food, 0);

        stock[food] += quantity;
    }

    static int Sell(Dictionary<string, int> stock, int quantity, string food)
    {
        if (!stock.ContainsKey(food))
        {
            Console.WriteLine($"You do not have any {food}.");
            return 0;
        }

        if (stock[food] < quantity)
        {
            int stockQuantity = stock[food];
            stock.Remove(food);
            Console.WriteLine($"There aren't enough {food}. You sold the last {stockQuantity} of them.");
            return stockQuantity;
        }

        stock[food] -= quantity;
        Console.WriteLine($"You sold {quantity} {food}.");

        if (stock[food] == 0)
        {
            stock.Remove(food);
        }

        return quantity;
    }
}