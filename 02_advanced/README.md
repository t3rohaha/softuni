# C# Advanced

## Stacks and Queues

`Stack` is a `LIFO` collection. For working with stacks we can use `Stack<T>`,
which is a generic class that inherits `IEnumerable<T>`.

`Queue` is a `FIFO` collection. For working with queues we can use `Queue<T>`,
which is a generic class that inherits `IEnumerable<T>`.

## Multidimensional Arrays

`Multidimentional Array` an array of arrays with fixed length.

`2D Array` Is a multidimentional array that can be accessed by two indeces
(rows and columns).

`3D Array` Is a multidimentional array that can be accessed by three indeces
(layer, rows and columns).

`Matrix` is 2D array where the rows and columns have the same length.

`Jagged Array` An array of arrays which can be with different size.

### Notes

If you want to have access to the dimensions of an array you should use `T[,]`
syntax. If you want to use jagged array syntax you should use `T[][]` syntax.

## Sets

Collection that contains unique elements. C# provides `HashSet<T>`, which
implements the matematical set concept and provides methods for operations
like `union`, `intersection` and `difference`.

`Union` All unique elements between two sets.

`Intersection` Elements that present between two sets.

`Difference` Elements that present in a set and don't present in compared set.

## Linked Lists

`Data structure` where elements are stored in objects called `nodes`. Each
node has two parts: data and reference to next node. C# provides the
`LinkedList<T>` which is a `doubly liked list`.

`Singly liked list` each node contains data and reference to the next node.
The last node points to null.

`Doubly linked list` each node contains data, reference to next and previous
node. This allows traversial of the list both forward and backward.

`Circular liked list` each node contains data, reference to next and
previous node. The last node points to first node forming a circle.

## Stream I/O

Refer to transfer of data either from or to storage. .NET offers different
classes that inherit `Stream` class and facilitate working with different
types of streams. I.E. `FileStream` class is used to perform common operations
involving files. 

`Stream` A collection of bytes which is used to read/write from/to different
types of storage.

`Readers and Writers` Streams work with bytes, so when reading text from
text file for example, conversion from string to bytes is needed. .NET provide
classes for this task.

`Asynchronous I/O` Reading and writing large amount of data take a lot of
time and if we want the application to stay responsive, we can use asynchronous
code.

`Compression` Refers to reducing the size of a file for storage.

`Decompression` refers to extracting te contents of a file in usable format.

### Notes

Streams are opened before using them and closed after that.

## Functional Programming

Programming style that uses functions as its main building block. The function
is `first class` citizen, which means it can be passed as arguments to function,
be returned from function and be set to variable.

`Pure functions` Functions that have no side affects and always return the same
value for the same input, without modifying external data.

`Delegates` Enable you to treat methods as objects.

`Func<T, TResult>` Predefined delegate which always return value.

`Action<T>` Predefined delegate that doesn't return value.

## LINQ

LINQ (Language-Integrated Query) is a feature that facilitates working with data
from different data sources. LINQ query can be written using either
`query syntax` or `method syntax`.

### Notes

A LINQ `data source` is any object that supports the generic `IEnumerable<T>`,
or an interface that inherits from it, typically `IQueryable<T>`.

A `query` is executed with `foreach`. To force query execution and cache the
result you can call `ToList()` or `ToArray()` methods.

## Generics

C# feature which enables `interfaces`, `classes`, `methods` and `delegates` to
be defined with the types of data they will work with.

## Iterators

C# feature which allows creating classes that can be enumerated.

`IEnumerable` base interface for creating classes that can be enumerated.

`Iterator method` a method that returns `IEnumerable` and contains one or
more `yield` statements.

`yield` is a keyword used inside `yield methods`. It returns a value and
suspends method execution until `foreach` asks for another value.

## Notes

### Collections vs Data Structures

`Collection` A group of data.

`Data Structure` A way of storing, accessing and manipulating data in memory.
