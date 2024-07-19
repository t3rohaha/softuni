namespace Exam03;

public class ThePianist
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine()!);

        var initialCollection = new List<Piece>();
        for (var i = 0; i < n; i++)
        {
            var inputArgs = Console.ReadLine()!.Split('|');
            var name = inputArgs[0];
            var composer = inputArgs[1];
            var key = inputArgs[2];

            initialCollection.Add(new Piece(name, composer, key));
        }

        var pieces = new PianoCollection(initialCollection);
        while (true)
        {
            var inputArgs = Console.ReadLine()!.Split('|');
            var command = inputArgs[0];

            if (command == "Stop")
            {
                pieces.Print();
                break;
            }

            if (command == "Add")
            {
                var result = pieces.Add(inputArgs[1], inputArgs[2], inputArgs[3]);
                Console.WriteLine(result);
                continue;
            }

            if (command == "Remove")
            {
                var result = pieces.Remove(inputArgs[1]);
                Console.WriteLine(result);
                continue;
            }

            if (command == "ChangeKey")
            {
                var result = pieces.ChangeKey(inputArgs[1], inputArgs[2]);
                Console.WriteLine(result);
                continue;
            }
        }
    }
}

public class Piece
{
    public Piece(string name, string composer, string key)
    {
        Name = name;
        Composer = composer;
        Key = key;
    }

    public string Name { get; }
    public string Composer { get; }
    public string Key { get; set; }

    public override string ToString()
    {
        return $"{Name} -> Composer: {Composer}, Key: {Key}";
    }
}

public class PianoCollection
{
    private List<Piece> _collection;

    public PianoCollection(IEnumerable<Piece> collection)
    {
        _collection = new List<Piece>(collection);
    }

    public string Add(string name, string composer, string key)
    {
        if (_collection.Any(p => p.Name == name))
            return $"{name} is already in the collection!";

        _collection.Add(new Piece(name, composer, key));

        return $"{name} by {composer} in {key} added to the collection!";
    }

    public string Remove(string name)
    {
        var piece = _collection.FirstOrDefault(p => p.Name == name);

        if (piece is null)
            return $"Invalid operation! {name} does not exist in the collection.";

        _collection.Remove(piece);

        return $"Successfully removed {name}!";
    }

    public string ChangeKey(string name, string newKey)
    {
        var piece = _collection.FirstOrDefault(p => p.Name == name);

        if (piece is null)
            return $"Invalid operation! {name} does not exist in the collection.";

        piece.Key = newKey;

        return $"Changed the key of {name} to {newKey}!";
    }

    public void Print()
    {
        foreach(var p in _collection)
            Console.WriteLine(p.ToString());
    }
}