namespace IteratorsAndComparators.P01_Enumerable;
public class Person
{
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
