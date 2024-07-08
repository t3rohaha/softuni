using System.Collections;

namespace Enumerable;

public class PeopleEnum : IEnumerator
{
    private List<Person> _people;
    private int _position = -1;

    public PeopleEnum(List<Person> people)
    {
        _people = people;
    }

    object IEnumerator.Current => _people[_position];

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
