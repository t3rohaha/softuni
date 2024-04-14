namespace RandomList;

public class RandomList<T> : List<T>
{
    public T  RemoveRandom()
    {
        if (this.Count == 0) throw new InvalidOperationException();

        var random = new Random();

        int randomIndex = random.Next(0, this.Count);

        T itemToRemove = this[randomIndex];

        this.RemoveAt(randomIndex);

        return itemToRemove;
    }
}
