namespace Exam02;

public class MovieRatings
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine()!);

        string topMovie = "", bottomMovie = "";
        double topRating = 0, bottomRating = 11;
        double totalRating = 0;

        for (var i = 0; i < n; i++)
        {
            var movieName = Console.ReadLine()!;
            var movieRating = double.Parse(Console.ReadLine()!);

            totalRating += movieRating;

            if (movieRating > topRating)
            {
                topMovie = movieName;
                topRating = movieRating;
            }

            if (movieRating < bottomRating)
            {
                bottomMovie = movieName;
                bottomRating = movieRating;
            }
        }

        Console.WriteLine($"{topMovie} is with highest rating: {topRating:F1}");
        Console.WriteLine($"{bottomMovie} is with lowest rating: {bottomRating:F1}");
        Console.WriteLine($"Average rating: {(totalRating / n):F1}");
    }
}