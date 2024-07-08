using System.Text;

namespace MultidimensionalArrays;

public class Basics
{
    public static void Main()
    {
        PrintArray("Array:", Array());
        Console.WriteLine();

        PrintArray2D("2D Array:", Array2D());
        Console.WriteLine();

        PrintArray3D("3D Array:", Array3D());
        Console.WriteLine();


        PrintArray2D("Matrix:", Matrix());
        Console.WriteLine();

        PrintJaggedArray("Jagged Array:", JaggedArray());
    }

    static int[] Array()
    {
        return new int[] {1, 2, 3};
    }

    static int[,] Array2D()
    {
        return new int[,]
        {
            {1, 2, 3},
            {1, 2, 3},
            {1, 2, 3},
            {1, 2, 3},
        };
    }

    static int[,,] Array3D()
    {
        return new int[,,]
        {
            {
                {1, 2, 3, 4},
                {1, 2, 3, 4},
                {1, 2, 3, 4},
            },
            {
                {1, 2, 3, 4},
                {1, 2, 3, 4},
                {1, 2, 3, 4},
            },
            {
                {1, 2, 3, 4},
                {1, 2, 3, 4},
                {1, 2, 3, 4},
            },
        };
    }

    static int[,] Matrix()
    {
        return new int[3,3]
        {
            {1, 2, 3},
            {1, 2, 3},
            {1, 2, 3},
        };
    }

    static int[][] JaggedArray()
    {
        return new int[][]
        {
            new int[] {1, 2, 3},
            new int[] {1, 2, 3, 4},
            new int[] {1, 2, 3, 4, 5},
            new int[] {1, 2, 3},
        };
    }

    static void PrintArray(string header, int[] array)
    {
        Console.WriteLine(header);
        Console.WriteLine(string.Join(" ", array));
    }

    static void PrintArray2D(string header, int[,] array)
    {

        var sb = new StringBuilder();
        sb.AppendLine(header);

        for (int r = 0; r < array.GetLength(0); r++)
        {
            for (int c = 0; c < array.GetLength(1); c++)
            {
                sb.Append($"{array[r, c]} ");
            }
            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString().Trim());
    }

    static void PrintArray3D(string header, int[,,] array)
    {
        var sb = new StringBuilder();
        sb.AppendLine(header);

        for (int l = 0; l < array.GetLength(0); l++)
        {
            for (int r = 0; r < array.GetLength(1); r++)
            {
                for (int c = 0; c < array.GetLength(2); c++)
                {
                    sb.Append($"{array[l,r,c]} ");
                }
                sb.AppendLine();
            }
            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString().Trim());
    }

    static void PrintJaggedArray(string header, int[][] array)
    {
        var sb = new StringBuilder();
        sb.AppendLine(header);

        for (int r = 0; r < array.Length; r++)
        {
            for (int c = 0; c < array[r].Length; c++)
            {
                sb.Append($"{array[r][c]} ");
            }
            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString().Trim());
    }
}
