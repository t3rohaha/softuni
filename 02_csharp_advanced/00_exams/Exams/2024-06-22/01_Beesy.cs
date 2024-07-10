namespace Exams;

public class Program
{
    public static void Main()
    {
        // Initialize matrix.
        var n = int.Parse(Console.ReadLine()!);
        var matrix = new char[n][];
        for (var i = 0; i < n; i++)
            matrix[i] = Console.ReadLine()!.ToCharArray();

        // Initialize BeesyService.
        var beesy = new BeesyService(matrix);

        // Receive directions, until bee reaches the hive or runs out of energy.
        while (true)
        {
            var cmd = Console.ReadLine()!;

            beesy.MakeMove(cmd);

            if (beesy.HiveReached) break;

            if (beesy.Energy == 0)
                beesy.RestoreEnergy();

            if (beesy.Energy == 0) break;
        }

        // Print output.
        if (beesy.HiveReached && beesy.CollectedNectar >= 30)
            Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {beesy.Energy}");
        if (beesy.HiveReached && beesy.CollectedNectar < 30)
            Console.WriteLine($"Beesy did not manage to collect enough nectar.");
        if (!beesy.HiveReached)
            Console.WriteLine("This is the end! Beesy ran out of energy.");

        Console.WriteLine(beesy.ToString());
    }
}

public class BeesyService
{
    private char[][] _field;
    private int _row;
    private int _col;

    public BeesyService(char[][] field)
    {
        _field = field;
        InitializeBeePosition();
        Energy = 15;
        CollectedNectar = 0;
        HiveReached = false;
        EnergyRestored = false;
    }

    public int Energy { get; private set; }
    public int CollectedNectar { get; private set; }
    public bool HiveReached { get; private set; }
    public bool EnergyRestored { get; private set; }

    public void MakeMove(string direction)
    {
        _field[_row][_col] = '-';
        Energy--;

        switch (direction)
        {
            case "up": _row--; break;
            case "right": _col++; break;
            case "down": _row++; break;
            case "left": _col--; break;
        }

        var min = 0;
        var max = _field.Length - 1;

        if (_row < min) _row = max;
        if (_row > max) _row = min;
        if (_col < min) _col = max;
        if (_col > max) _col = min;

        var newPos = _field[_row][_col];

        if (newPos == 'H')
            HiveReached = true;

        if (char.IsDigit(newPos))
            CollectedNectar += int.Parse(newPos.ToString());

        _field[_row][_col] = 'B';
    }

    public void RestoreEnergy()
    {
        if (!EnergyRestored && CollectedNectar > 30)
        {
            EnergyRestored = true;
            Energy = CollectedNectar - 30;
            CollectedNectar = 30;
        }
    }

    public override string ToString()
    {
        var output = "";
        foreach (var row in _field)
            output += $"{string.Join("", row)}\n";
        return output.Trim();
    }

    private void InitializeBeePosition()
    {
        for (var row = 0; row < _field.Length; row++)
            for (var col = 0; col < _field.Length; col++)
                if (_field[row][col] == 'B')
                    SetPosition(row, col);
    }

    private void SetPosition(int row, int col)
    {
        _row = row;
        _col = col;
    }
}