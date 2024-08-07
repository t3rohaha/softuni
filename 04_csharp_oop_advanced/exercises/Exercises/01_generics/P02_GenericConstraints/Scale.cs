namespace Generics.P02_GenericConstraints;
public class Scale<T> where T : IComparable
{
    private T _left;
    private T _right;

    public Scale(T left, T right)
    {
        _left = left;
        _right = right;
    }

    public bool? GetHeavier()
    {
        var result = _left.CompareTo(_right);
        
        if (result > 0) return true;
        if (result < 0) return false;
        return null;
    }
}
