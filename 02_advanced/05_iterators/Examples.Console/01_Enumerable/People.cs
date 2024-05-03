namespace Enumerable;
using System.Collections;

public class People : IEnumerable
{
    private List<Person> _people;

    public People(ICollection<Person> people)
    {
        _people = people.ToList();
    }

    public IEnumerator GetEnumerator()
    {
        return new PeopleEnum(_people);
    }
}
