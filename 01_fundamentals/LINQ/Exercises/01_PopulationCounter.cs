/*

The intention of this solution is to exercise LINQ queries.

Example input:
Sofia|Bulgaria|1
Veliko Tarnovo|Bulgaria|2
London|UK|4
Rome|Italy|3
report

*/

public static class PopulationCounter
{
    public static void Run()
    {
        var population = new List<CityInfo>();

        while (true)
        {
            string input = Console.ReadLine()!;

            if (input == "report") break;

            string[] arguments = input.Split("|");

            population.Add(new CityInfo
            {
                City = arguments[0],
                Country = arguments[1],
                Population = long.Parse(arguments[2])
            });
        }

        var countryGroup = population
        .GroupBy(x => x.Country)
        .OrderByDescending(x => x.Sum(y => y.Population))
        .Select(group => new
        {
            Country = group.Key,
            Population = group.Sum(x => x.Population),
            Cities = group.OrderByDescending(x => x.Population)
        });

        foreach (var x in countryGroup)
        {
            Console.WriteLine($"{x.Country} (total population: {x.Population})");
            foreach (var cityInfo in x.Cities)
            {
                Console.WriteLine($"=>{cityInfo.City}: {cityInfo.Population}");
            }
        }
    }
}

public class CityInfo
{
    public string? City { get; set; }

    public string? Country { get; set; }

    public long Population { get; set; }
}
