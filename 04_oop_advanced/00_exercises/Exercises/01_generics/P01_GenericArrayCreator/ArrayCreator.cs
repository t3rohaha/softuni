namespace Generics.P01_GenericArrayCreator;
public class ArrayCreator
{
    public static T[] Create<T>(int length, T defaultValue)
    {
        var arr = new T[length];

        for (int i = 0; i < length; i++)
            arr[i] = defaultValue;

        return arr;
    }
}
