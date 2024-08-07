namespace Exam01;
using System.Text.RegularExpressions;

public class DestinationMapper
{
    public static void Main()
    {
        string encryptedLocations = Console.ReadLine()!;

        string pattern = @"=([A-Z][a-zA-Z]{2,})=|\/([A-Z][a-zA-Z]{2,})\/";

        Regex regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(encryptedLocations);

        var locations = new List<string>();
        int travelPoints = 0;
        foreach (Match match in matches)
        {
            string location = match.Value.Trim(new char[]{'=', '/'});
            travelPoints += location.Length;
            locations.Add(location);
        }

        Console.WriteLine($"Destinations: {string.Join(", ", locations)}");
        Console.WriteLine($"Travel Points: {travelPoints}");
    }
}
