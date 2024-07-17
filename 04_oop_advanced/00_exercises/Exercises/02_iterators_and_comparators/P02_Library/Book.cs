namespace IteratorsAndComparators.P02_Library;
public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        Title = title;
        Year = year;
        Authors = authors;
    }

    public string Title { get; }
    public int Year { get; }
    public IEnumerable<string> Authors { get; }

    public int CompareTo(Book? other)
    {
        if (other is null) return -1;
        if (Year < other.Year) return -1;
        if (Year > other.Year) return 1;
        return Title.CompareTo(other.Title);
    }

    public override string ToString()
    {
        return $"{Title} ({Year})";
    }
}