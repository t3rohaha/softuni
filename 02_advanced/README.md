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

## Streams

## Functional Programming

## Dictionary

__Generic__: With specified type.

__Non-generic__: Without specified type.
