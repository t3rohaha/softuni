namespace IteratorsAndComparators.P01_Enumerable;
public class Program
{
    public static void Main()
    {
        Person[] personArray =
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon")
        };

        People people = new People(personArray);

        foreach(Person p in people)
            Console.WriteLine(p.ToString());
    }
}