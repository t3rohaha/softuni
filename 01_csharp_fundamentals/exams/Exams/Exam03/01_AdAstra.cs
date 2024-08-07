using System.Text;
using System.Text.RegularExpressions;

namespace Exam03;

public class AdAstra
{
    public static void Main()
    {
        // var m1 = regex.Matches("#Bread#19/03/21#4000#|Invalid|03/03.20||Apples|08/10/20|200||Carrots|06/08/20|500||Not right|6.8.20|5|");
        // var m2 = regex.Matches("$$#@@%^&#Fish#24/12/20#8500#|#Incorrect#19.03.20#450|$5*(@!#Ice Cream#03/10/21#9000#^#@aswe|Milk|05/09/20|2000|");
        // var m3 = regex.Matches("Hello|#Invalid food#19/03/20#450|$5*(@");

        var input = Console.ReadLine()!;

        var pattern = @"(#[a-zA-Z ]+#[0-9]{2}\/[0-9]{2}\/[0-9]{2}#[0-9]+#)|(\|[a-zA-Z ]+\|[0-9]{2}\/[0-9]{2}\/[0-9]{2}\|[0-9]+\|)";
        var regex = new Regex(pattern);
        var matches = regex.Matches(input);

        var foodInfo = new StringBuilder();
        var totalCals = 0;

        foreach (Match m in matches)
        {
            var inputArgs = m.Value.Split(new char[]{'#', '|'}, StringSplitOptions.RemoveEmptyEntries);

            var name = inputArgs[0];
            var expDate = inputArgs[1];
            var cals = int.Parse(inputArgs[2]);

            foodInfo.AppendLine($"Item: {name}, Best before: {expDate}, Nutrition: {cals}");

            totalCals += cals;
        }

        Console.WriteLine($"You have food to last you for: {totalCals / 2000} days!");
        Console.Write(foodInfo);
    }
}