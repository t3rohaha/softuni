using System.Collections;

namespace Iterators.P01_Enumerable;
public class PeopleEnumerator : IEnumerator
{
    private List<Person> _people;
    private int _position = -1;

    public PeopleEnumerator(List<Person> people)
    {
        _people = people;
    }

    public object Current => _people[_position];

    public bool MoveNext()
    {
        _position++;
        return _position < _people.Count;
    }

    public void Reset()
    {
        _position = -1;
    }
}
