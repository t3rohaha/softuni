# C# Advanced

This course covers advanced data structures like
[Stacks and Queues](#stacks-and-queues),
[Multidimentional Arrays](#multidimentional-arrays) and advanced programming
concepts like [Streams](#streams) and
[Functional Programming](#functional-programming).

## Stacks and Queues

__Stack__: LIFO collection. For working with stacks we can use
__Stack&lt;T&gt;__, which is a generic class that inherits
__IEnumerable&lt;T&gt;__.

__Queue__: FIFO collection. For working with queues we can use
__Queue&lt;T&gt;__, which is a generic class that inherits
__IEnumerable&lt;T&gt;__.

## Multidimentional Arrays

An array of arrays creating dimensions.

__Matrix__: Two-dimensional array that can be accessed by two indeces (rows and
colums).

__Jagged Array__: An array of arrays where every array can be with different
size.

```csharp
var matrix = new int[,]
{
    {1, 2},
    {1, 2}
};
var topLeft = matrix[0, 0];

var jaggedArr = new int[,,]
{
    {1, 2},
    {1, 2, 3},
    {1, 2}
};
var midRight = jaggedArr[1, 2];

var threeDimensionalArr = new int[,,,]
{
    {
        {1, 2, 3},
        {1, 2, 3},
        {1, 2, 3}
    },
    {
        {1, 2, 3},
        {1, 2, 3},
        {1, 2, 3}
    },
    {
        {1, 2, 3},
        {1, 2, 3},
        {1, 2, 3}
    }
};
var topLeft = threeDimensionalArray[0, 0, 0];
```

## Stream I/O

Refer to transfer of data either from or to storage. .NET offers different
classes that inherit __Stream__ class and facilitate working with different
types of streams. I.E. __FileStream__ class is used to perform common operations
involving files. 

__Stream__: A collection of bytes which is used to read/write from/to different
types of storage.

__Readers and Writers__: Streams work with bytes, so when reading text from
text file for example, conversion from string to bytes is needed. .NET provide
classes for this task.

__Asynchronous I/O__: Reading and writing large amount of data take a lot of
time and if we want the application to stay responsive, we can use asynchronous
code.

__Compression__: Refers to reducing the size of a file for storage.
__Decompression__ refers to extracting te contents of a file in usable format.

__NB!__

1. Streams are opened before using them and closed after that.

## Functional Programming

Programming style that uses functions as its main building block. The function
is __first class__ citizen, which means it can be passed as arguments to
function, be returned from function and be set to variable.

__Pure functions__: Functions that have no side affects and always return the
same value for the same input, without modifying external data.

__Delegates__: Enable you to treat methods as objects.

```csharp
MathOperation Sum = (x, y) => x + y;

delegate int MathOperation(int x, int y);
```

__Func&lt;T, TResult&gt;__: Predefined delegate which always returns value.

__Action&lt;T&gt;__: predefined delegate that doesn't return value.

## Dictionary

__Generic__: With specified type.

__Non-generic__: Without specified type.

## Questions

### What would be the output of the following program?

```csharp
var matrix = new int[3,3]
{
    {1, 2, 3},
    {1, 2, 3},
    {1, 2, 3}
}

Console.WriteLine(matrix.Count);
```
