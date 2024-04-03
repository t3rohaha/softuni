// To test in Judge:
// 00 Remove static keyword from class
// 01 Rename Run to Main
static class Registration
{
    public static void Run()
    {
        var username = Console.ReadLine()!;

        var executeLetters = (string convertTo) =>
        {
            switch (convertTo)
            {
                case "Lower": username = username.ToLower(); break;
                case "Upper": username = username.ToUpper(); break;
            }

            Console.WriteLine(username);
        };

        var executeReverse = (int startIndex, int endIndex) => 
        {
            var validStartIndex = startIndex >= 0 && startIndex < username.Length;
            var validEndIndex = endIndex >= 0 && endIndex < username.Length;

            if (validStartIndex && validEndIndex)
            {
                var reversedSubstring = username
                    .Substring(startIndex, endIndex - startIndex + 1)
                    .Reverse();
                    
                Console.WriteLine(string.Join("", reversedSubstring));
            }
        };

        var executeSubstring = (string substring) => 
        {
            if (username.Contains(substring))
            {
                username = username.Replace(substring, "");
                Console.WriteLine(username);
            }
            else Console.WriteLine($"The username {username} doesn't contain {substring}.");
        };

        var executeReplace = (char c) =>
        {
            if (username.Contains(c))
            {
                username = username.Replace(c, '-');
                Console.WriteLine(username);
            }
        };

        var executeIsValid = (char c) =>
        {
            if (username.Contains(c)) Console.WriteLine("Valid username.");
            else Console.WriteLine($"{c} must be contained in your username.");
        };

        while (true)
        {
            string[] input = Console.ReadLine()!.Split(' ');

            string cmd = input[0]!;

            if (cmd == "Registration") break;

            string[] arguments = input.Skip(1).ToArray();

            switch (cmd)
            {
                case "Letters":
                    executeLetters(arguments[0]);
                    break;
                case "Reverse":
                    executeReverse(int.Parse(arguments[0]), int.Parse(arguments[1]));
                    break;
                case "Substring":
                    executeSubstring(arguments[0]);
                    break;
                case "Replace":
                    executeReplace(arguments[0][0]);
                    break;
                case "IsValid":
                    executeIsValid(arguments[0][0]);
                    break;
            }
        }
    }
}
