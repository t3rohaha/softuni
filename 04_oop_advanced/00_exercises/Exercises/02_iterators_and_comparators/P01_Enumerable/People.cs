using System.Collections;

namespace IteratorsAndComparators.P01_Enumerable;
public class People : IEnumerable
{
    private List<Person> _people;

    public People(ICollection<Person> people)
    {
        _people = people.ToList();
    }

    public IEnumerator GetEnumerator()
    {
        return new PeopleEnumerator(_people);
    }
}
