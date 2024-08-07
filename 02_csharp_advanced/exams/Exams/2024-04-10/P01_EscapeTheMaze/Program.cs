namespace Exams.P01_EscapeTheMaze;
public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine()!);
        var matrix = new char[n][];
        for (var i = 0; i < n; i++)
            matrix[i] = Console.ReadLine()!.ToCharArray();

        // string[][] m1 =
        // [
        //     ["-", "-", "-", "-", "-"],
        //     ["-", "P", "M", "-", "-"],
        //     ["-", "M", "-", "-", "-"],
        //     ["-", "-", "-", "H", "-"],
        //     ["-", "X", "-", "-", "-"],
        // ];

        // string[][] m2 =
        // [
        //     ["-", "-", "H", "-", "-", "-", "-", "-"],
        //     ["-", "-", "-", "P", "-", "-", "-", "X"],
        //     ["-", "-", "-", "-", "-", "-", "-", "-"],
        //     ["-", "-", "M", "-", "-", "M", "-", "-"],
        //     ["-", "-", "H", "-", "-", "M", "-", "-"],
        //     ["H", "-", "-", "-", "-", "-", "M", "-"],
        //     ["-", "-", "-", "-", "-", "-", "-", "-"],
        //     ["-", "-", "-", "-", "-", "-", "H", "-"],
        // ];

        var maze = new Maze(matrix);

        while (true)
        {
            var direction = Console.ReadLine()!;
            maze.MoveTraveller(direction);
            if (maze.GameOver) break;
        }

        maze.PrintState();
        maze.PrintMaze();
    }
}