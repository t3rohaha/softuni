public static class GameNumberWars
{
    public static void Solve()
    {
        var player1 = Console.ReadLine()!;
        var player2 = Console.ReadLine()!;

        var playerPoints1 = 0;
        var playerPoints2 = 0;

        while (true)
        {
            var cmd1 = Console.ReadLine()!;

            if (cmd1 == "End of game")  // Terminates the cycle
            {
                Console.WriteLine($"{player1} has {playerPoints1} points");
                Console.WriteLine($"{player2} has {playerPoints2} points");
                break;
            }

            var card1 = int.Parse(cmd1);
            var card2 = int.Parse(Console.ReadLine()!);

            if (card1 == card2)         // Terminates the cycle
            {
                Console.WriteLine("Number wars!");
                card1 = int.Parse(Console.ReadLine()!);
                card2 = int.Parse(Console.ReadLine()!);

                if (card1 > card2)
                {
                    Console.WriteLine($"{player1} is winner with {playerPoints1} points");
                }
                else
                {
                    Console.WriteLine($"{player2} is winner with {playerPoints2} points");
                }

                break;
            }

            if (card1 > card2)
            {
                playerPoints1 += card1 - card2;
            }
            else
            {
                playerPoints2 += card2 - card1;
            }
        }
    }
}
