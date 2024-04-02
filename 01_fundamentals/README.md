# Programming Fundamentals

The course covers fundamental concepts in programming, which serve as the basis for effective and high-quality learning in professional modules. Learners build upon the knowledge acquired in the Programming Basics course and begin to utilize more advanced programming techniques and structures such as lists, dictionaries, objects, and classes.

## Error Handling

__try block__: In this block, you place the code that you want to monitor for exceptions.

__catch block__: In this block, you handle the exception that occured within the try block.

__finally block (optional)__: This block is executed whether or not an exception occures. It's typically used for cleanup operations, such as closing files or releasing resources.

## Version Control

System that records changes to source code files, so developers can recall specific versions later. It allows multiple developers to work on the same source code, while __keeping track of changes__ and __managing conflicts__.

__Repository__: This is where the source code which is version controlled is stored.

__Remote Repository__: Holds project assets in a remote server.

__Local Repository__: Holds the project assets in a local machine.

__Clone__: Download a local copy of the project.

__Commit__: Store changes in local repository.

__Pull__: Take and merge the changes from remote repository.

__Push__: Send local changes to remote repository.

__Branch__: Parallel version of the repository, allowing developers to work on features without affecting the main repository. Branches can be merged back to the main repository.

__Merge__: Merging is the process of combining changes from source branch to target branch. It shows the conflicts (if any) between the branches and after reviewing the code the changes can be integrated.

__Checkout__: Is switching between different branches. It updates the working directory to reflect the state of a specific commit or branch.

__Conflict Resolution__: Conflict occures when two or more developers make conflicting changes to same file.

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

__float__: 32-bit, 6-9 digits precision after the decimal point --> `var x = 0F;`

__double__: 64-bit, 15-17 digits precision after the decimal point. --> `var x = 0D;`

__decimal__ 128-bit, 28-29 digits precision after the decimal point. --> `var x = 0M;`

### Type Conversion:

__Implicit__: Numerical value of bigger type can be changed to value of smaller type, i.e. int > short.

__Explicit__: Converting to numerical type explicitly i.e. (int) doubleNum. Data precision can be lost.

### Other

__boolean__: Can hold false or true --> `var x = true;`

__char__: Represents a single symbol --> `var x = 'A';`

__string__: Represents a sequence of characters --> `var x = "Hello!";`

### Key Considerations

1. __Default Behaviour__: When creating a numerical value without decimal point it's __integer__. If it is with a decimal point it's __double__.

2. __Precise Calculations__: Floating-point types sometimes have unexpected behaviour, so for precise calculations is better to use decimal.

3. __Division Behaviour__: Integer division behaves differently from real division. I.E. 10 / 0 = Divide by zero exception, but 10 / 0.0 = Infinity.

4. __Variable Span__: How long it takes for a variable to be used after its initialized. Always declare a variable as late as possible.

## SoftUni Judge

[Data Types and Variables - Exercises](https://judge.softuni.org/Contests/Practice/Index/206#0)
