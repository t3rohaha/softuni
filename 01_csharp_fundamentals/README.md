# PROGRAMMING FUNDAMENTALS

## CONTENT

01. [Version Control](#version-control)
02. [Data Types](#data-types)
03. [Methods and Debugging](#methods-and-debugging)
04. [Arrays](#arrays)
05. [Lists](#lists)
06. [Dictionaries, Lambda and LINQ](#dictionaries,-lambda-and-linq)
07. [Objects and Classes](#objects-and-classes)
08. [Files and Directories](#files-and-directories)
09. [Strings](#strings)
10. [Regex](#regex)

## Error Handling

- `try-block` In this block, you place the code that you want to monitor for
exceptions.

- `catch-block` In this block, you handle the exception that occured within the
try block.

- `finally-block (optional)` This block is executed whether or not an exception
occures. It's typically used for cleanup operations, such as closing files or
releasing resources.

## Version Control

System that records changes to source code files, so developers can recall
specific versions later. It allows multiple developers to work on the same
source code, while `keeping track of changes` and `managing conflicts`.

- `Repository` This is where the source code which is version controlled is
stored.

- `Remote Repository` Holds project assets in a remote server.

- `Local Repository` Holds the project assets in a local machine.

- `Clone` Download a local copy of the project.

- `Commit` Store changes in local repository.

- `Pull` Take and merge the changes from remote repository.

- `Push` Send local changes to remote repository.

- `Branch` Parallel version of the repository, allowing developers to work on
features without affecting the main repository. Branches can be merged back to
the main repository.

- `Merge` Merging is the process of combining changes from source branch to
target branch. It shows the conflicts (if any) between the branches and after
reviewing the code the changes can be integrated.

- `Checkout` Is switching between different branches. It updates the working
directory to reflect the state of a specific commit or branch.

- `Conflicts` Occur when two or more developers make conflicting changes to same
file.

## Data Types

- `Integer Types`

    In C# there are several integer types, each with its own range and storage size.

    - `sbyte` Signed 8-bit integer.

    - `byte` Unsigned 8-bit integer.

    - `short` Signed 16-bit integer.

    - `ushort` Unsigned 16-bit integer.

    - `int` Signed 32-bit integer.

    - `uint` Unsigned 32-bit integer.

    - `long` Signed 64-bit integer.

    - `ulong` Unsigned 64-bit integer.

- `Real Number Types`

    - `float` 32-bit, 6-9 digits precision after the decimal point `var x = 0F;`

    - `double` 64-bit, 15-17 digits precision after the decimal point `var x = 0D;`

    - `decimal` 128-bit, 28-29 digits precision after the decimal point `var x = 0M;`

- `Type Conversion`

    - `Implicit` C# automatically converts smaller type `int` (with less memory
    size) to larger type `double` (with larger memory size).

    - `Explicit` Generally a larger type `double` is explicitly by the
    programmer to smaller type `int`. Data precision can be lost.

- `Other`

    - `bool` Can hold true or false `var x = true;`

    - `char` Represents a single symbol `var x = 'A';`

    - `string` Represents a sequence of characters `var x = "Hello!";`

### Notes

- The `default type` of a numerical value without decimal point is `int`.
With decimal point is `double`.

-  Floating type values have unexpected behaviour when performing
`precise calculations`. In that case use `decimal`.

- `Integer division` behaves differently from real division. I.E. 10 / 0 =
Divide by zero exception, but 10 / 0.0 = Infinity.

## Methods

Code block that contains a series of instructions, it's executed only when 
invoked. In C# the Main method is the entry point of every application, it's
called by the CLR when the program is started.

`Declaration` Methods are declared inside a class.

## Array and List

- `Array` type is with fixed size. Once it's created it's size cannot be
changed in memory, so a new array should be created and assigned to the variable
if changes have to be made.

- `List` type have dynamic size which can grow or shrink as needed.
Internally it works with array and if the size grows beyond the capacity a
larger array is created.

- `List` provide additional functionality for manipulating the elements.

## Associative Array

Collection of key-value pairs. Each element has a unique key and an associated
value.

`Dictionary` C# type to handle associative arrays.

`Sorted Dictionary` A dictionary which keeps elements ordered by key.

## Classes and Objects

In OOP Classes and Objects are fundamental concepts used to model real world
entities. Classes define attributes and behaviour. Objects implement classes.

## Text Processing

- C# provides different ways to manipulate strings i.e. built in methods,
`StringBuilder` class and `Regex` class.

`StringBuilder` String is `immutable` which can lead to performance issues
when you need to concatenate multiple strings. `StringBuilder` provides a
`mutable` buffer which allows efficient append, insert and remove operations.

`Regex` a way to match text by pattern.

## Dictionary

`Variable span` How long it takes for a variable to be used after its
initialized. Always declare a variable as late as possible.

`Allocation` Allocation of memory for some data. When you set size to an
array, memory is allocated for it.

`Value Types` Value types store their value directly in the memory allocated
for the variable itself. They are copied by value, which means that when you
copy a value type variable to another variable a copy of the data is made.

`Reference Types` Reference types store an address to the location where the
data is stored. They are copied by reference, which means that when you copy the
reference to another variable, both will point to same data.

`Stack` Is part of the computer memory, which is used to store and access
small information. It is faster than the Heap.

`Heap` Is part of the computer memory, which is used to store and access
large information. It is bigger in size than the Stack.

`Mutability` Whether the state of an object can be changed after creating it,
or a new object should be created.
