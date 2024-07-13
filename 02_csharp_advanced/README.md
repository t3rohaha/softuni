# C# ADVANCED

## CONTENT
01. [Stacks and Queues](#stacks-and-queues)
02. [Multidimensional Arrays](#multidimensional-arrays)
03. [Data Transfer](#streams)
04. [Functional Programming](#functional-programming)
05. [More](#more)
    01. [Collections vs Data Structures](#collections-vs-data-structures)
    02. [Set](#set)
    03. [Linked List](#linked-list)

## STACKS AND QUEUES

**STACK** Data structure that follows the LIFO principle. This means that the
last element added to the stack is the first one to be removed. Provide the
following functionality (1. Pushing element to the top of the stack, 2. Popping
elements from the top of the stack, 3. Getting the topmost element without
removing it).

**QUEUE** Data structure that follows the FIFO principle. This means that the
first element added to the queue is the first one to be removed. Provide the
following functionality (1. Adding element to the end of the queue, 2. Removing
the first element of the queue, 3. Getting the first element of the queue
without removing it).

## MULTIDIMENSIONAL ARRAY

**MULTIDIMENSIONAL ARRAY** Data structure that organizes data into multiple
dimensions. Unlike one-dimensional array, which stores elements in a linear
sequence, multidimensional arrays use multiple indeces to access its elements.

**2D ARRAY** Is a multidimentional array that can be accessed by two indeces. It
can be visualized as a table where indices represent `row` and `column`.

**3D ARRAY** Is a multidimentional array that can be accessed by three indeces.
It can be visualized as a cube where each element can be accessed by coordinates
(width, height, depth).

**JAGGED ARRAY** Array of arrays, where each array can have different size.

**NOTES**

- If you want to have access to the dimensions of an array you should use `T[,]`
syntax. If you want to use jagged array syntax you should use `T[][]` syntax.

```csharp
var firstArray2D = new int[2, 3];               // Declare
var firstArray3D = new int[2, 3, 4];            // Declare

int[,] secondArray2D =                          // Initialize
{
    { 1, 2, 3 },
    { 1, 2, 3 },
};

int[,,] secondArray3D =                         // Initialize
{
    {
        { 1, 2, 3, 4 },
        { 1, 2, 3, 4 },
        { 1, 2, 3, 4 }
    },
    {
        { 1, 2, 3, 4 },
        { 1, 2, 3, 4 },
        { 1, 2, 3, 4 }
    },
};

Console.WriteLine(secondArray2D[1, 2]);         // Access 2D last: 3
Console.WriteLine(secondArray3D[1, 2, 3]);      // Access 3D last: 4

Console.WriteLine(secondArray3D.Length);        // All elements: 24
Console.WriteLine(secondArray3D.Rank);          // Number of dimensions: 3
Console.WriteLine(secondArray3D.GetLength(0));  // Length of d1: 2
Console.WriteLine(secondArray3D.GetLength(1));  // Length of d2: 3
Console.WriteLine(secondArray3D.GetLength(2));  // Length of d3: 4
```

```csharp
var jaggedArray1 = new int[2][];        // Declare
jaggedArray1[0] = [1, 2, 3];         
jaggedArray1[1] = [1, 2, 3, 4];

int[][] jaggedArray2 =                  // Initialize
{
    [1, 2, 3],
    [1, 2, 3, 4]
};

Console.WriteLine(jaggedArray2[0][0]);  // 1
Console.WriteLine(jaggedArray2[1][1]);  // 2
```

## DATA TRANSFER

**STREAM** Abstraction that represents the transfer of data. Streams are opened
when the transfer begins and closed after it ends. Data is not transferred all
at once but by chunks (buffers), for efficiency.

**INPUT STREAM** Used to read data.

**OUTPUT STREAM** Used to write data.

**DECORATOR STREAM** Stream that add additional functionality to existing
streams without modifying their core behavior.

**FILE STREAM** Decorator stream which facilitates working with files.

**MEMORY STREAM** Decorator stream which facilitates working with memory.

**NETWORK STREAM** Decorator stream which facilitates transfers over the
network.

**READ** Extract data from stream.

**WRITE** Send data to stream.

**SEEK** Move the position within a stream.

**FLUSH** Clear buffer and ensure data is sent to destination.

**READERS AND WRITERS** Stream adapters (or readers and writers) facilitate
type conversion when working with different types of streams (e.g. stream of
bytes to text stream).

## FUNCTIONAL PROGRAMMING

**FUNCTIONAL PROGRAMMING** Programming style that uses functions as its main
building block (e.g. instead of objects). The function is `first class` citizen,
which means it can be passed as arguments to function, be returned from function
and be set to variable.

**PURE FUNCTIONS** Functions that have no side affects and always return the
same value for the same input, without modifying external data.

**DELEGATES** A type that represents reference to methods. Enable you to treat
methods as objects.

**Func<T, TResult>** Predefined delegate which always return value.

**Action<T>** Predefined delegate that doesn't return value.

**LINQ** (Language-Integrated Query) is a feature that facilitates working with
data from different data sources by providing common syntax for data
manipulation. LINQ query can be written using either `query syntax` or
`method syntax`.

**LINQ DATA SOURCE** Any object that supports the generic `IEnumerable<T>`, or
an interface that inherits from it, typically `IQueryable<T>`.

**LINQ QUERY EXECUTION** A query is executed with foreach or by caching the
result and calling ToList() or ToArray() methods.

**LAMBDA EXPRESSIN** Syntax for creating anonymous functions, which facilitates
functional programming techniques in C#.

## MORE

### COLLECTIONS VS DATA STRUCTURES

**COLLECTION** A group of data.

**DATA STRUCTURE** A way of storing, accessing and managing data in memory.

### SET

**SET** Collection that contains unique elements. C# provides `HashSet<T>`,
which implements the matematical set concept and provides methods for operations
like `union`, `intersection` and `difference`.

**UNION** Get all unique elements between two sets.

**INTERSECTION** Get elements that present between two sets.

**DIFFERENCE** Get elements that present in a set and don't present in compared
set.

### LINKED LIST

**LINKED LIST** Data structure where elements are stored in objects called
`nodes`. Each node has two parts: data and reference to next node. C# provides
the `LinkedList<T>` which is a `doubly liked list`.

**SINGLY LINKED LIST** each node contains data and reference to the next node. The
last node points to null.

**DOUBLY LINKED LIST** each node contains data, reference to next and previous
node. This allows traversial of the list both forward and backward.

**CIRCULAR LINKED LIST** each node contains data, reference to next and previous
node. The last node points to first node forming a circle.