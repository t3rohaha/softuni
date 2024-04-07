namespace Registration;

class Program
{
    static void Main()
    {
        var username = Console.ReadLine()!;

        var registration = new Registration(username);

        while (true)
        {
            string[] input = Console.ReadLine()!.Split(' ');

            string cmd = input[0]!;

            if (cmd == "Registration") break;

            string[] arguments = input.Skip(1).ToArray();

            switch (cmd)
            {
                case "Letters":
                    registration.ExecuteLetters(arguments[0]);
                    break;
                case "Reverse":
                    registration.ExecuteReverse(int.Parse(arguments[0]), int.Parse(arguments[1]));
                    break;
                case "Substring":
                    registration.ExecuteSubstring(arguments[0]);
                    break;
                case "Replace":
                    registration.ExecuteReplace(arguments[0][0]);
                    break;
                case "IsValid":
                    registration.ExecuteIsValid(arguments[0][0]);
                    break;
            }
        }
    }
}

class Registration
{
    private string _username;

    public Registration(string username)
    {
        _username = username;
    }

    public void ExecuteLetters(string convertTo)
    {
        switch (convertTo)
        {
            case "Lower": _username = _username.ToLower(); break;
            case "Upper": _username = _username.ToUpper(); break;
        }

        Console.WriteLine(_username);
    }

    public void ExecuteReverse(int startIndex, int endIndex)
    {
        var validStartIndex = startIndex >= 0 && startIndex < _username.Length;
        var validEndIndex = endIndex >= 0 && endIndex < _username.Length;

        if (validStartIndex && validEndIndex)
        {
            var reversedSubstring = _username
                .Substring(startIndex, endIndex - startIndex + 1)
                .Reverse();
                
            Console.WriteLine(string.Join("", reversedSubstring));
        }
    }

    public void ExecuteSubstring(string substring)
    {
        if (_username.Contains(substring))
        {
            _username = _username.Replace(substring, "");
            Console.WriteLine(_username);
        }
        else Console.WriteLine($"The username {_username} doesn't contain {substring}.");
    }

    public void ExecuteReplace(char c)
    {
        if (_username.Contains(c))
        {
            _username = _username.Replace(c, '-');
            Console.WriteLine(_username);
        }
    }

    public void ExecuteIsValid(char c)
    {
        if (_username.Contains(c)) Console.WriteLine("Valid username.");
        else Console.WriteLine($"{c} must be contained in your username.");
    }
}
