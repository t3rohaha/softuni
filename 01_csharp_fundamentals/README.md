# PROGRAMMING FUNDAMENTALS

## CONTENT

01. [Version Control](#version-control)
02. [Data Types](#data-types)
03. [Methods](#methods)
04. [Arrays](#arrays)
05. [Lists](#lists)
06. [Associative Arrays](#associative-arrays)
07. [Objects and Classes](#objects-and-classes)
08. [Files and Directories](#files-and-directories)
09. [Strings](#strings)
10. [Regex](#regex)

## VERSION CONTROL

System that records changes to source code files, so developers can recall
specific versions later. It allows multiple developers to work on the same
source code, while `keeping track of changes` and `managing conflicts`.

**REPOSITORY** This is where the source code which is version controlled is
stored.

**REMOTE REPOSITORY** Holds project assets in a remote server.

**LOCAL REPOSITORY** Holds the project assets in a local machine.

**CLONE** Download a local copy of the project.

**COMMIT** Store changes in local repository.

**PULL** Take and merge the changes from remote repository.

**PUSH** Send local changes to remote repository.

**BRANCH** Parallel version of the repository, allowing developers to work on
features without affecting the main repository. Branches can be merged back to
the main repository.

**MERGE** Merging is the process of combining changes from source branch to
target branch. It shows the conflicts (if any) between the branches and after
reviewing the code the changes can be integrated.

**CHECKOUT** Is switching between different branches. It updates the working
directory to reflect the state of a specific commit or branch.

**CONFLICTS** Occur when two or more developers make conflicting changes to same
file.

## DATA TYPES

**DATA TYPE** Type of data stored in memory. A data type has name, size and
default value.

**INTEGERS** Integers are whole numbers. The size of the integer data type
determines the range of values it can store. For example an 8-bit integer can
store values ranging from -128 to 127 (signed), or 0 to 255 (unsigned), because
these ranges can be represented with 8 bits. If we try to assign a value greater
than 127 to an 8-bit signed integer this will lead to an exception.

- `sbyte` Signed 8-bit integer.
- `byte` Unsigned 8-bit integer.
- `short` Signed 16-bit integer.
- `ushort` Unsigned 16-bit integer.
- `int` Signed 32-bit integer.
- `uint` Unsigned 32-bit integer.
- `long` Signed 64-bit integer.
- `ulong` Unsigned 64-bit integer.

**REAL NUMBERS** Numbers with floating point. Different floating point types
have different precision.

- `float` 32-bit, 6-9 digits precision after the decimal point `var x = 0F;`
- `double` 64-bit, 15-17 digits precision after the decimal point `var x = 0D;`
- `decimal` 128-bit, 28-29 digits precision after the decimal point `var x = 0M;`

**OTHER**

- `bool` Can hold true or false `var x = true;`
- `char` Represents a single symbol `var x = 'A';`
- `string` Represents a sequence of characters `var x = "Hello!";`

**IMPLICIT TYPE CONVERSION** When we convert a type with smaller value range to
a type with larger value range (e.g float to double). Because we are converting
to a type with bigger value range, no data can be lost.

**EXPLICIT TYPE CONVERSION** When we convert from a type with bigger value range
to a type with smaller value range. Because we are converting to a type with
smaller value range, this can lead to exception or loosing precision.

**STACK** Is part of the computer memory, which is used to store and access
small information. It is faster than the Heap.

**HEAP** Is part of the computer memory, which is used to store and access
large information. It is bigger in size than the Stack.

**VALUE TYPES** Store their values in stack. When a variable with value type is
assigned to another variable, the actual value is copied. All numeric types,
bool, char, DateTime, BigInteger, structs are value types.

**REFERENCE TYPES** Store a reference (or pointer) in the stack to the value
(which is stored in the heap).  When a variable with reference type is assigned
to another variable, only the reference is copied, so both the variables refer
to the same value. String, array, classes, interfaces, delegates are reference
types.

**MUTABILITY** Whether the state of an object can be changed after creating it,
or a new object should be created.

**NOTES**

1. The default type of a numerical value without decimal point is int.  With
decimal point is double.
2.  Floating type values have unexpected behaviour when performing precise
calculations. In that case use decimal.
3. Integer division behaves differently from real division. I.E. 10 / 0 = Divide
by zero exception, but 10 / 0.0 = Infinity.
4. All numeric types are value types.

## METHODS

**METHOD** Code block that can be executed later when invoked. They prevent
writing the same code several times and improve code readability.

**DECLARATION** Introducing the method to the compiler (giving it name, return
type, parameters), without including actual implementation. Methods are declared
inside a class.

**RETURN TYPE** Methods can return values by specifying the data type of the
value returned, or they can return void, which means they do not return value.

**PARAMETERS** Methods can receive parameters, which allow them to be invoked
with specific values.

**OPTIONAL PARAMETERS** Parameters can have default values, which makes them
optional. Optional parameters must appear after all required parameters.

**RETURN** Keyword used to return a value and terminate the method. If the
method is void it simply terminates the method.

**OVERLOADING** Declaring methods with the same name but different parameters.

```csharp
int Sum(int a, int b)
{
    return a + b;
}

var result = Sum(2, 3);         // Assign the result to variable
Console.WriteLine(result);      // 5
Console.WriteLine(Sum(2, 3));   // 5
```

## DATA STRUCTURE

**DATA STRUCTURE** A way of storing, accessing and managing data.

**ORGANIZATION** Data structures specify how data is organized and stored in
memory. This organization affects how efficiently data can be accessed and
modified.

**OPERATIONS** Data structures provide methods to perform common operations
like insert, delete, search, sort, traverse (iterate).

**EFFICIENCY** Different data structured are designed to optimize specific
operations.

## ARRAYS

**ARRAY** Data structure that stores a fixed-size sequential collection of
elements of the same type.

**FIXED SIZE** Arrays have fixed size, meaning once they are created, their
size cannot be changed.

**SEQUENTIAL STORAGE** Array elements are stored sequentially in memory, which
allows for efficient access using their index.

**ELEMENT TYPE** All elements must be of the same type.

**INDEXED ACCESS** Individual elements can be accessed using their index.

**DECLARATION AND INITIALIZATION** Arrays are declared using square brackets []
and specifying size. They can be initialized with values at the time of
declaration or later.

```csharp
var nums = new int[] { 1, 2, 3, 4, 5 };     // Initialize
Console.WriteLine(nums[0]);                 // 1
Console.WriteLine(nums[nums.Length-1]);     // 5
```

## LISTS

**LIST** Generic collection that represents dynamic array that can grow or
shrink dynamically as elements are added or removed. Unlike arrays which have
fixed size, lists provide flexibility by allowing you to add and remove
elements.

**DYNAMIC SIZE** Lists can grow or shrink based on the number of elements they
contain. You do not need to specify the size of the list when you declare it.

**GENERIC** Can hold elements of specified data type. You specify the data type
of the elements when you declare it.

**ACCESS** Individual elements can be accessed using their index.

**MANIPULATION** Lists provide efficient methods for adding, inserting and
removing elements.

```csharp
var nums = new List<int>() { 1, 2, 3, 4, 5 };   // Initialize
nums.Add(7);                                    // Add
nums.Insert(5, 6);                              // Insert
Console.WriteLine(string.Join(", ", nums));     // 1, 2, 3, 4, 5, 6, 7
```

## ASSOCIATIVE ARRAYS

**ASSOCIATIVE ARRAY** Associative arrays are also known as `maps`, `hash tables`
or `dictionaries`, allow you to associate keys with values. Unlike traditional
arrays where elements are accessed by numeric indices, associative arrays use
keys that can be of any data type (usually strings or integers).

**KEY-VALUE PAIRS** Each element in an associative array is a pair of unique
key and a value. Keys are used to access corresponding values.

**FAST LOOKUPS** Associative arrays are designed for efficient retrieval of
elements using their key.

**DYNAMIC SIZE** Associative arrays can grow or shrink based on the number of
elements they contain.

**Dictionary<TKey, TValue>** Generic collection that serves as associative
array. It stores collection of `KeyValuePair<TKey, TValue>` where each key must
be unique.

**SortedDictionary<TKey, TValue>** A dictionary which keeps elements ordered by
key.

**GENERIC** You specify the data type of keys and values that the dictionary
will hold when you declare it.

**MANIPULATION** Dictionary provides efficient methods for manipulating elements
like Add(key, value), Remove(key), ContainsKey(key).

```csharp
var ppl = new SortedDictionary<string, int>()   // Initialize
{
    { "John Terry", 33 },
    { "Frank Lampard", 32},
    { "Ashley Cole", 30 }
};

Console.WriteLine(string.Join(", ", ppl.Keys)); // Ashley Cole, Frank ...
```

## OBJECTS AND CLASSES

**OBJECT** Instance of a class. Encapsulate data (fields) and behavior
(methods).

**CLASS** Template of an object. Contain members (data and methods) that define
the structure and behavior of the objects.

**CLASS DEFINITION** Use `class` keyword to define a class.

**FIELDS** Define variables to hold data.

**CONSTRUCTOR** A special methods which is called when a new instance is
created.

**METHODS** Define functions that operate on the data.

**STATIC CLASS** A class that cannot be instantiated and contains only static
members. They are useful for creating utility or helper classes that provide
functionality without creating an instance.

**BUILT-IN CLASSES** .NET framework includes a rich set of built-in API classes
that provide a wide range of functionalities, from basic data types and
collections to advanced capabilities like networking, files and threading.

**SYSTEM NAMESPACE**
- `System.Object` - The base class for all types.
- `System.String` - Represents text as a series of Unicode characters.
- `System.DateTime` - Represents date and time.

**SYSTEM.COLLECTIONS NAMESPACE**
- `System.Collections.ArrayList` - Non-generic dynamic collection of elements.
- `System.Collections.HashTable` - Non-generic collection of key-value pairs.

**SYSTEM.IO**
- `System.IO.File` - Provides static methods for managing files.
- `System.IO.Directory` - Provides static methods for managing directories.
- `System.IO.Stream` - The abstract base class for all streams (sequence of
bytes).

```csharp
public class Person
{
    public string name;
    public int age;   

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void Introduce()
    {
        Console.WriteLine($"Hello, my name is {this.name} and I am {age} years old.");
    }
}
```

## STRINGS

**STRING** Text, sequence of characters.

**MUTABILITY** Whether variable value can be changed in memory after created.
If data type is immutable, the value cannot be changed, insead a new value is
saved and the reference of the variable is updated. If the data type is mutable
the value is changed directly in memory.

**StringBuilder** A class which helps with the performance issues when
manipulating large strings.

```csharp
var str = new string(new char[] {'s', 't', 'r'});   // char[] to string
var chars = str.ToCharArray();                      // string to char[]

var str1 = "str1";
var str2 = "str2";
string.Compare(str1, str2, true);   // Compare strings (case-insensitive)

var builder = new StringBuilder(100);
builder.Append("Hello Maria, how are you?");
Console.WriteLine(builder); // Hello Maria, how are you?
builder[6] = 'D';
Console.WriteLine(builder); // Hello Daria, how are you?
builder.Remove(5, 6);
Console.WriteLine(builder); // Hello, how are you?
builder.Insert(5, "Peter");
Console.WriteLine(builder); // Hello Peter, how are you?
builder.Replace("Peter", "George");
Console.WriteLine(builder); // Hello George, how are you?
```

## REGEX

**REGEX** Advanced text processing tool.

**PATTERN** Search criteria.

**RANGES**
- `[abc]` Matches any char that is either a, b or c.
- `[^abc]` Matches any char that is not a, b or c.
- `[0-9]` Matches any digit in range 0 - 9.

**CLASSES**
- `\w` Matches any word character (a-z, A-Z, 0-9, _).
- `\W` Matches any non-word char (opposite of \w).
- `\s` Matches any whitespace.
- `\S` Matches any non-whitespace (opposite of \s).
- `\d` Matches any digit (0-9).
- `\D` Matches any non-digit.

**QUANTIFIERS**
- `*` Matches prev element 0 or more times.
- `+` Matches prev element 1 or more times.
- `?` Matches prev element - or 1 time.
- `{3}` Matches prev element exactly 3 times.

**SPECIAL**
- `\n` New line.
- `\r` Carriage return.
- `\t` Tab.
- `\0` Null.

**ANCHORS**
- `^` The match must occur at the beginning.
- `$` The match must occur at the end.
- `/m` Matches beginning and end of line, instead of beginning end of text.

**GROUPING**
- `(subexpr)` Matches everything enclosed and create a group.
- `(?:subexpr)` Matches everything enclosed.
- `(?<name>)` Matches everything enclosed and create named group.

**BACKREFERENCES**
- `\number` Matches the value of numbered group.

```csharp
var text = "Frank: 33, John: 33, Joe: 30";
var pattern = @"([A-Z][a-z]+): (d+)";
var regex = new Regex(pattern);

bool isMatch = regex.IsMatch(text);             // True
Match match = regex.Match(text);                // Single match
MatchCollection matches = regex.Matches(text);  // All matches
```