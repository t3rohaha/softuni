namespace Generics.P00_BoxOfT;
public class Box<T>
{
    private List<T> _box = new List<T>();

    public void Add(T element)
    {
        _box.Add(element);
    }

    public T Remove()
    {
        T element = _box[_box.Count() - 1];
        _box.RemoveAt(_box.Count() - 1);
        return element;
    }

    public int Count()
    {
        return _box.Count();
    }
}
