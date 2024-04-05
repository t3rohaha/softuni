public class Phonebook
{
    public static void Run()
    {
        var phonebook = new SortedDictionary<string, string>();

        while (true)
        {
            string[] input = Console.ReadLine()!.Split(' ');

            string cmd = input[0];

            if (cmd == "END") break;

            string[] arguments = input.Skip(1).ToArray();

            switch (cmd)
            {
                case "A":
                    Add(phonebook, arguments[0], arguments[1]);
                    break;
                case "S":
                    SearchAndPrint(phonebook, arguments[0]);
                    break;
                case "ListAll":
                    PrintAll(phonebook);
                    break;
            }
        }
    }

    static void Add(SortedDictionary<string, string> phonebook, string name, string phone)
    {
        phonebook[name] = phone;
    }

    static void SearchAndPrint(SortedDictionary<string, string> phonebook, string name)
    {
        if (phonebook.ContainsKey(name))
            Console.WriteLine($"{name} -> {phonebook[name]}");
        else
            Console.WriteLine($"Contact {name} does not exist.");
    }

    static void PrintAll(SortedDictionary<string, string> phonebook)
    {
        foreach (var kvp in phonebook)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }
    }
}
