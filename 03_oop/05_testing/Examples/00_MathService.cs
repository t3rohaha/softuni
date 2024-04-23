namespace Examples;

public class MathService
{
   public bool IsPrime(int candidate)
   {
        if (candidate < 2) return false;

        for (var divisor = 2; candidate <= Math.Sqrt(candidate); divisor++)
            if (candidate % divisor == 0) return false;

        return true;
   }
}
