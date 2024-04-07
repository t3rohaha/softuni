# Programming Fundamentals

The course covers fundamental concepts in programming, which serve as the basis
for effective and high-quality learning in professional modules. It includes
[Error Handling](#error-handling), [Version Control](#version-control),
[Data Types](#data-types), [Array and List](#array-and-list),
[Associative Array](#associative-array),
[Classes and Objects](#classes-and-objects),
[Text Processing](#text-processing) and definitions for
__Value and Reference Types__, __Stack and Heap__, __Mutability__.

## Error Handling

__try block__: In this block, you place the code that you want to monitor for
exceptions.

__catch block__: In this block, you handle the exception that occured within the
try block.

__finally block (optional)__: This block is executed whether or not an exception
occures. It's typically used for cleanup operations, such as closing files or
releasing resources.

## Version Control

System that records changes to source code files, so developers can recall
specific versions later. It allows multiple developers to work on the same
source code, while __keeping track of changes__ and __managing conflicts__.

__Repository__: This is where the source code which is version controlled is
stored.

__Remote Repository__: Holds project assets in a remote server.

__Local Repository__: Holds the project assets in a local machine.

__Clone__: Download a local copy of the project.

__Commit__: Store changes in local repository.

__Pull__: Take and merge the changes from remote repository.

__Push__: Send local changes to remote repository.

__Branch__: Parallel version of the repository, allowing developers to work on
features without affecting the main repository. Branches can be merged back to
the main repository.

__Merge__: Merging is the process of combining changes from source branch to
target branch. It shows the conflicts (if any) between the branches and after
reviewing the code the changes can be integrated.

__Checkout__: Is switching between different branches. It updates the working
directory to reflect the state of a specific commit or branch.

__Conflict Resolution__: Conflict occures when two or more developers make
conflicting changes to same file.

## Data Types

### Integer Types

In C# there are several integer types, each with its own range and storage size.

__sbyte__: Signed 8-bit integer.

__byte__: Unsigned 8-bit integer.

__short__: Signed 16-bit integer.

__ushort__: Unsigned 16-bit integer.

__int__: Signed 32-bit integer.

__uint__: Unsigned 32-bit integer.

__long__: Signed 64-bit integer.

__ulong__: Unsigned 64-bit integer.

### Real Number Types

__float__: 32-bit, 6-9 digits precision after the decimal point -->
`var x = 0F;`

__double__: 64-bit, 15-17 digits precision after the decimal point. -->
`var x = 0D;`

__decimal__ 128-bit, 28-29 digits precision after the decimal point. -->
`var x = 0M;`

### Type Conversion:

__Implicit__: Numerical value of bigger type can be changed to value of smaller
type, i.e. int > short.

__Explicit__: Converting to numerical type explicitly i.e. (int) doubleNum. Data
precision can be lost.

### Other

__boolean__: Can hold false or true --> `var x = true;`

__char__: Represents a single symbol --> `var x = 'A';`

__string__: Represents a sequence of characters --> `var x = "Hello!";`

__NB!__

1. The __default type__ of a numerical value without decimal point is __int__.
With decimal point is __double__.

2. Floating type values have unexpected behaviour when performing
__precise calculations__. In that case use __decimal__.

3. Integer division behaves differently from real division. I.E. 10 / 0 =
Divide by zero exception, but 10 / 0.0 = Infinity.

## Methods

Code block that contains a series of instructions, it's executed only when 
invoked. In C# the Main method is the entry point of every application, it's
called by the CLR when the program is started.

__Declaration__: Methods are declared inside a class.

## Array and List

Collection of elements.

```csharp
var nums = new int[5];      // Declaration (Allocating memory)
nums[0] = 1;                // Setting value
Console.WriteLine(nums[0]); // Accessing value
```

```csharp
var nums = new List<int>(); // Initialization
nums.Add(1);                // Add element
nums.Add(2);
nums.Add(3);
nums.Remove(1);             // Remove element
nums.RemoveAt(0);           // Remove element at index
nums.Insert(0, 100);        // Insert element at index
nums.Contains(100);         // Checks if element exists in collection
nums.Sort();                // Sorts the elements in ascending order (changes
                            // the collection directly)
nums.Reverse();             // Reverse the elements in collection
Console.WriteLine(nums[0]); // Access element
```

__NB!__

1. __Array__ type is with fixed size. Once it's created it's size cannot be
changed in memory, so a new array should be created and assigned to the variable
if changes have to be made.

2. __List__ type have dynamic size which can grow or shrink as needed.
Internally it works with array and if the size grows beyond the capacity a
larger array is created.

3. __List__ provide additional functionality for manipulating the elements.

## Associative Array

Collection of key-value pairs. Each element has a unique key and an associated
value.

__Dictionary__: C# type to handle associative arrays.

__Sorted Dictionary__: A dictionary which keeps elements ordered by key.

```csharp
var phonebook = new Dictionary<string, string>();   // Initialization
phonebook.Add("John", "0883332222");                // Add element
phonebook["Frank"] = "0884442222";                  // Add element
phonebook.Count;                                    // Get elements count
phonebook.Keys;                                     // A collection of the keys
phonebook.Values;                                   // A collection of the
                                                    // values
phonebook.ContainsKey("John");                      // Check if key presents in
                                                    // collection
phonebook.Remove("John");                           // Remove by key
```

## Classes and Objects

In OOP Classes and Objects are fundamental concepts used to model real world
entities. Classes define attributes and behaviour. Objects implement classes.

```csharp
class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public void Print()
    {
        Console.WriteLine($"{X} {Y}");
    }
}

var point = new Point() { X = 5, Y = 10 };
```

## Text Processing

C# provides different ways to manipulate strings i.e. built in methods,
__StringBuilder__ class and __Regex__ class.

__StringBuilder__: String is __immutable__ which can lead to performance issues
when you need to concatenate multiple strings. __StringBuilder__ provides a
__mutable__ buffer which allows efficient append, insert and remove operations.

__Regex__: a way to match text by pattern.

## Dictionary

__Variable Span__: How long it takes for a variable to be used after its
initialized. Always declare a variable as late as possible.

__Allocation__: Allocation of memory for some data. When you set size to an
array, memory is allocated for it.

__Value Types__: Value types store their value directly in the memory allocated
for the variable itself. They are copied by value, which means that when you
copy a value type variable to another variable a copy of the data is made.

__Reference Types__: Reference types store an address to the location where the
data is stored. They are copied by reference, which means that when you copy the
reference to another variable, both will point to same data.

__Stack__: Is part of the computer memory, which is used to store and access
small information. It is faster than the Heap.

__Heap__: Is part of the computer memory, which is used to store and access
large information. It is bigger in size than the Stack.

__Mutability__: Whether the state of an object can be changed after creating it,
or a new object should be created.

## Resources

[Data Types and Variables - Exercises](https://judge.softuni.org/Contests/Practice/Index/1205#0)

[Exam Preparation - 20 March 2024](https://judge.softuni.org/Contests/Practice/Index/4778#0)

[Dictionaries, Lambda and LINQ - Exercises](https://judge.softuni.org/Contests/Practice/Index/209#0)

## Questions

### 01 What would be the output?

```csharp
static void Print(string text)
{
    Console.WriteLine(text);
}

static string Print(string text)
{
    return text;
}
```

### 02 Can you define a method in anonymous type?

### 03 What is mutability?
