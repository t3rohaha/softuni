namespace Basics;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Three Parts of LINQ:");
        ThreePartsOfLINQ();
    }

    static void ThreePartsOfLINQ()
    {
        // Specify the data source.
        int[] numbers = [1, 2, 3, 4, 5];

        // Define the query expression.
        IEnumerable<int> oddQuery = numbers.Where(x => x % 2 != 0);

        // Execute the query.
        foreach (var odd in oddQuery) Console.WriteLine(odd);
    }

    static void QueryAndMethodSyntaxDiff()
    {
        int[] nums = [ 1, 2, 3, 4, 5, 1, 2, 3 ];

        // Filtering query using query syntax
        var evenNums1 =
            from n in nums
            where n % 2 == 0
            select n;

        // Filtering query using method syntax
        var evenNums2 = nums.Where(n => n % 2 == 0);

        // Ordering query using query syntax
        var descNums1 =
            from n in nums
            orderby n descending
            select n;

        // Ordering query using method syntax
        var descNums2 = nums.OrderDescending();

        // Grouping query using query syntax
        var groupedNums1 =
            from n in nums
            group n by n;

        // Grouping query using method syntax
        var groupedNums = nums.GroupBy(n => n);
    }
}