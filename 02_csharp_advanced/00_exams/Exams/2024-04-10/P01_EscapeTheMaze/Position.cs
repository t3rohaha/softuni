namespace Exams.P01_EscapeTheMaze;
public class Position
{
    public Position(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }

    public int Row { get; set; }
    public int Col { get; set; }
}
