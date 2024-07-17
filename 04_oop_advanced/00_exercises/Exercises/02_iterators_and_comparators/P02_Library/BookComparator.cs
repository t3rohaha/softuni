namespace IteratorsAndComparators.P02_Library;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book? x, Book? y)
    {
        if (x is not null && y is null) return -1;
        if (x is null && y is not null) return 1;
        if (x is null && y is null) return 0;

        var result = x!.Title.CompareTo(y!.Title);

        if (result == 0)
            return x.Year.CompareTo(y.Year);

        return result;
    }
}