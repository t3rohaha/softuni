using System.Collections;

namespace IteratorsAndComparators.P02_Library;
public class Library : IEnumerable<Book>
{
    private Book[] _books;
    public Library(params Book[] books)
    {
        _books = books;
    }

    public void Sort()
    {
        Array.Sort(_books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(_books);

        // foreach (var b in _books)
        //     yield return b;

        // return _books.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private Book[] _books;
        private int _position;
        
        public LibraryIterator(Book[] books)
        {
            _books = books;
            _position = -1;
        }

        public Book Current => _books[_position];
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _position++;
            return _position < _books.Length;
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
        }
    }
}