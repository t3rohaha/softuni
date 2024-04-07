namespace ClearSkies;

class Program
{
    static void Main()
    {
        // Size of the square matrix.
        int n = int.Parse(Console.ReadLine()!);

        // Initialize matrix, jet position and enemy count.
        var matrix = new char[n,n];
        var jet = (row: -1, col: -1, health: -1);
        int enemyCount = 0;
        for (var r = 0; r < n; r++)
        {
            string row = Console.ReadLine()!;
            for (var c = 0; c < n; c++)
            {
                matrix[r,c] = row[c];
                if (row[c] == 'J') jet = (row: r, col: c, health: 300);
                else if (row[c] == 'E') enemyCount++;
            }
        }

        // Receive direction and move jet inside matrix.
        while (true)
        {
            var cmd = Console.ReadLine()!;

            matrix[jet.row, jet.col] = '-';

            if (cmd == "left") jet.col--;
            else if (cmd == "right") jet.col++;
            else if (cmd == "up") jet.row--;
            else jet.row++;

            if (matrix[jet.row, jet.col] == 'E' && enemyCount == 1)
            {
                Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                break;
            }
            else if (matrix[jet.row, jet.col] == 'E')
            {
                jet.health -= 100;
                enemyCount--;
            }
            else if (matrix[jet.row, jet.col] == 'R') jet.health = 300;

            if (jet.health == 0)
            {
                Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jet.row}, {jet.col}]!");
                break;
            }
        }

        matrix[jet.row, jet.col] = 'J';

        // Print matrix
        for (var r = 0; r < n; r++)
        {
            for (var c = 0; c < n; c++)
                Console.Write(matrix[r,c]);
            Console.WriteLine();
        }
    }
}
