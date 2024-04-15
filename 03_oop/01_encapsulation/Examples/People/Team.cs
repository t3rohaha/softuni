namespace People;

public class Team
{
    private List<Person> _firstTeam;
    private List<Person> _reserveTeam;

    public Team(string name)
    {
        Name = name;
        _firstTeam = new List<Person>();
        _reserveTeam = new List<Person>();
    }

    public string Name { get; private set; }

    public IReadOnlyCollection<Person> FirstTeam { get => _firstTeam; }

    public IReadOnlyCollection<Person> ReserveTeam { get => _reserveTeam; }

    public void AddPlayer(Person player)
    {
        if (player.Age < 40) _firstTeam.Add(player);
        else _reserveTeam.Add(player);
    }
}