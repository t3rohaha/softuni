# C# Advanced

This course covers advanced data structures like
[Stacks and Queues](#stacks-and-queues),
[Multidimentional Arrays](#multidimentional-arrays), [Sets](#sets), 
[Linked Lists](#linked-lists) and advanced programming concepts like
[Generics](#generics), [Iterators and Comparators](#iterators-and-comparators),
[Streams](#streams), [Functional Programming](#functional-programming) and
[LINQ](#linq).

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

## Sets

Collection that contains unique elements. C# provides __HashSet&lt;T&gt;__,
which implements the matematical set concept and provides methods for operations
like __union__, __intersection__ and __difference__.

__Union__: All unique elements between two sets.

__Intersection__: Elements that present between two sets.

__Difference__: Elements that present in a set and don't present in compared
set.

```csharp
var s1 = new HashSet<int> { 0, 0, 1, 2, 3 };    // 0, 1, 3, 5
var s2 = new HashSet<int> { 0, 0, 2, 4, 6 };    // 0, 2, 4, 6

var union = s1.Union(s2);                       // 0, 1, 3, 5, 2, 4, 6
var intersection = s1.Intersect(s2);            // 0
var diff = s1.Except(s2);                       // 1, 3, 5
```

## Linked Lists

__Data structure__ where elements are stored in objects called __nodes__. Each
node has two parts: data and reference to next node. C# provides the
__LinkedList&lt;T&gt;__ which is a __doubly linked list__.

__Singly Linked List__: each node contains data and reference to the next node.
The last node points to null.

__Doubly Linked List__: each node contains data, reference to next and previous
node. This allows traversial of the list both forward and backward.

__Circular Linked List__: each node contains data, reference to next and
previous node. The last node points to first node forming a circle.

__Examples__: [LinkedList&lt;T&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-8.0)

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

## LINQ

LINQ (Language-Integrated Query) is a feature that facilitates working with data
from different data sources. LINQ query can be written using either
__query syntax__ or __method syntax__.

__Three parts of LINQ query__:
```csharp
// 1. Data source.
int[] numbers = [ 0, 1, 2, 3, 4 ];

// 2. Query creation.
var evenNums = numbers.Where(n => n % 2 == 0);

// 3. Query execution.
for (int n in evenNums) Console.WriteLine(n);
```

__Query and Method syntax difference__:
```csharp
int[] nums = [ 1, 2, 3, 4, 5, 1, 2, 3 ];

// Filtering query using query syntax
var evenNums1 =
    from n in nums
    where n % 2 == 0
    select n;

// Filtering query using method syntax
var evenNums2 = nums.Where(n => n % 2 == 0);

// Ordering query using query syntax
var descNums1 =
    from n in nums
    orderby n descending
    select n;

// Ordering query using method syntax
var descNums2 = nums.OrderDescending();

// Grouping query using query syntax
var groupedNums1 =
    from n in nums
    group n by n;

// Grouping query using method syntax
var groupedNums = nums.GroupBy(n => n);
```

__NB!__

1. A LINQ __data source__ is any object that supports the generic
__IEnumerable<T>__, or an interface that inherits from it, typically
__IQueryable<T>__.

2. A __query__ is executed with foreach. To force query execution and cache the
result you can call ToList or ToArray methods.

## Generics

## Iterators and Comparators

## Dictionary

__Generic__: With specified type.

__Non-generic__: Without specified type.

__Lambda expression__: anonymous function.

__Collection__: A group of elements.

__Data Structure__: A way of organizing data, so it can be easily accessed and
manipulated.

## Resources

[Stacks and Queues - Exercise](https://judge.softuni.org/Contests/Practice/Index/1447#0)

[Multidimensional Arrays - Exercise](https://judge.softuni.org/Contests/Practice/Index/1455#0)

[C# Advanced Regular Exam - 17 February 2024](https://judge.softuni.org/Contests/Practice/Index/4555#0)

## Questions

### 00 What would be the output of the following program?

```csharp
var matrix = new int[3,3]
{
    {1, 2, 3},
    {1, 2, 3},
    {1, 2, 3}
}

Console.WriteLine(matrix.Count);
```

### 01 What would be the output of the following program?

```csharp
var anon = new { a = 0 };
anon.a = 1;
```
