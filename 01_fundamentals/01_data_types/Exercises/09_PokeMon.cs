namespace PokeMon;

class Program
{
    static void Main()
    {
        var initialPokePower = int.Parse(Console.ReadLine()!);  // N
        var pokeDistance = int.Parse(Console.ReadLine()!);      // M
        var exhaustionFactor = int.Parse(Console.ReadLine()!);  // Y

        int pokePower = initialPokePower;
        int pokesCount = 0;

        while (pokePower >= pokeDistance)
        {
            pokesCount++;

            pokePower -= pokeDistance;
            
            if (pokePower == initialPokePower / 2M)
            {
                if (exhaustionFactor == 0) continue;
                
                pokePower /= exhaustionFactor;
            }
        }

        Console.WriteLine(pokePower);
        Console.WriteLine(pokesCount);
    }
}
