public static class DiagonalDifference
{
    public static void Run()
    {
        int n =  int.Parse(Console.ReadLine()!);    // Size of square matrix

        var matrix = new int[n,n];

        for (var r = 0; r < n; r++)                 // Initialize matix
        {
            int[] row = Console
            .ReadLine()!
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

            for (var c = 0; c < n; c++)
            {
                matrix[r,c] = row[c];
            }
        }

        int d1Sum = 0;
        int d2Sum = 0;
        for (var r = 0; r < n; r++)                 // Get diagonal sums
        {
            for (var c = 0; c < n; c++)
            {
                if (r == c) d1Sum += matrix[r,c];
                if (r == n - c - 1) d2Sum += matrix[r,c];
            }
        }

        Console.WriteLine(Math.Abs(d1Sum - d2Sum));
    }
}

/*
[00][01][02][03]
[10][11][12][13]
[20][21][22][23]
[30][31][32][33]
*/