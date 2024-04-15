namespace People;

public class Program
{
    static void Main()
    {
        var people = new List<Person>()
        {
            new Person("Andrew", "Williams", 65, 2200M),
            new Person("Newton", "Holland", 57, 3333M),
            new Person("Rachelle", "Nelson", 27, 650M),
            new Person("Brandi", "Scott", 44, 666.66M),
            new Person("George", "Miller", 35, 650.5M),
        }; 

        var parcentage = 20; 
        people.ForEach(p => p.IncreaseSalary(parcentage)); 

        var team = new Team("SoftUni");
        people.ForEach(team.AddPlayer);
        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

        team.FirstTeam.Append(new Person("Frank", "Lampard", 22, 1000));
        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
    }
}
