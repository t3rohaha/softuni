namespace Person;

public class Program
{
    static void Main()
    {
        var personArray = new Person[]
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon")
        };

        var people = new People(personArray);

        foreach(Person p in people)
            Console.WriteLine(p.firstName + " " + p.lastName);
    }
}