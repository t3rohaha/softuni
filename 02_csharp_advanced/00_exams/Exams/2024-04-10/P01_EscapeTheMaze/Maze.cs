namespace Exams.P01_EscapeTheMaze;
public class Maze
{
    private const char EMPTY = '-';
    private const char PLAYER = 'P';
    private const char EXIT = 'X';
    private const char MONSTER = 'M';
    private const char HEALTH = 'H';
    private const int MAX_HEALTH = 100;
    private const int MONSTER_DAMAGE = 40;
    private const int HEALTH_BOOST = 15;

    private char[][] _matrix;
    private Position _player;
    private int _health;

    public Maze(char[][] matrix)
    {
        _matrix = matrix;
        _player = this.InitializePlayerPosition();
        _health = MAX_HEALTH;
        this.GameOver = false;
    }

    public bool GameOver { get; private set; }

    public void MoveTraveller(string direction)
    {
        var newPosition = GetNewPosition(direction);

        var symbol = _matrix[newPosition.Row][newPosition.Col];

        if (symbol == PLAYER)
        {
            return;
        }
        else if (symbol == EXIT)
        {
            this.GameOver = true;
        }
        else if (symbol == MONSTER)
        {
            _health -= MONSTER_DAMAGE;

            if (_health <= 0)
            {
                _health = 0;
                this.GameOver = true;
            }
        }
        else if (symbol == HEALTH)
        {
            _health += HEALTH_BOOST;

            if (_health > 100)
            {
                _health = 100;
            }
        }

        _matrix[_player.Row][_player.Col] = EMPTY;
        _matrix[newPosition.Row][newPosition.Col] = PLAYER;
        _player.Row = newPosition.Row;
        _player.Col = newPosition.Col;
    }

    public void PrintMaze()
    {
        foreach (var row in _matrix)
            Console.WriteLine(string.Join("", row));
    }

    public void PrintState()
    {
        if (this.GameOver)
        {
            if (_health <= 0)
            {
                Console.WriteLine("Player is dead. Maze over!");
            }
            else
            {
                Console.WriteLine("Player escaped the maze. Danger passed!");
            }
        }

        Console.WriteLine($"Player's health: {_health} units");
    }

    private Position GetNewPosition(string direction)
    {
        var newPosition = new Position(_player.Row, _player.Col);

        switch (direction)
        {
            case "up": newPosition.Row--; break;
            case "right": newPosition.Col++; break;
            case "down": newPosition.Row++; break;
            case "left": newPosition.Col--; break;
        }

        if (newPosition.Row < 0) newPosition.Row = 0;
        else if (newPosition.Col < 0) newPosition.Col = 0;
        else if (newPosition.Row > _matrix.Length-1) newPosition.Row = _matrix.Length-1;
        else if (newPosition.Col > _matrix.Length-1) newPosition.Col = _matrix.Length-1;

        return newPosition;
    }

    private Position InitializePlayerPosition()
    {
        for (var row = 0; row < _matrix.Length; row++)
            for (var col = 0; col < _matrix.Length; col++)
                if (_matrix[row][col] == PLAYER)
                    return new Position(row, col);

        return new Position(0, 0);
    }
}