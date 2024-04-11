namespace Person;
using System.Collections;

public class PeopleEnum : IEnumerator
{
    private List<Person> _people;
    private int _position = -1;

    public PeopleEnum(List<Person> people)
    {
        _people = people;
    }

    public Person Current => _people[_position];

    object IEnumerator.Current => Current;

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
