using System.Text.RegularExpressions;

// To test in Judge:
// 00 Remove static keyword from class
// 01 Rename Run to Main
static class DestinationMapper
{
    public static void Run()
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
