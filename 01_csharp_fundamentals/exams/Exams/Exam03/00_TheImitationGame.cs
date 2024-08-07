using System.Text;

namespace Exam03;

public class TheImitationGame
{
    public static void Main()
    {
        var encryptedMessage = Console.ReadLine()!;

        var encryptor = new Encryptor(encryptedMessage);

        while (true)
        {
            var inputArgs = Console.ReadLine()!.Split('|');
            var command = inputArgs[0];

            if (command == "Decode")
            {
                encryptor.Print();
                break;
            }

            if (command == "Move")
            {
                encryptor.Move(int.Parse(inputArgs[1]));
                continue;
            }

            if (command == "Insert")
            {
                encryptor.Insert(int.Parse(inputArgs[1]), inputArgs[2]);
                continue;
            }

            if (command == "ChangeAll")
            {
                encryptor.ChangeAll(inputArgs[1], inputArgs[2]);
                continue;
            }
        }
    }
}

public class Encryptor
{
    private StringBuilder _message;

    public Encryptor(string encryptedMessage)
    {
        _message = new StringBuilder(encryptedMessage);
    }

    public void Move(int n)
    {
        for (var i = 0; i < n; i++)
            _message.Append(_message[i]);
        _message.Remove(0, n);
    }

    public void Insert(int index, string value)
    {
        _message.Insert(index, value);
    }

    public void ChangeAll(string substring, string replacement)
    {
        _message.Replace(substring, replacement);
    }

    public void Print()
    {
        Console.WriteLine($"The decrypted message is: {_message}");
    }
}