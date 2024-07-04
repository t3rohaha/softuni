# PROGRAMMING BASICS

## CONTENT

1. [First Steps](#first-steps)
2. [Simple Calculations](#simple-calculations)
    1. [Variables](#variables)
    2. [Operators and Expressions](#operators-and-expressions)
    3. [Variable Lifetime and Scope](#variable-lifetime-and-scope)
3. [Conditional Statements](#conditional-statements)
4. [Loops](#loops)

## FIRST STEPS

**PROGRAMMING** Writing commands which will be executed by computer.

**PROGRAM** Sequence of commands which serve general purpose.

**SOURCE CODE** Human readable representation of a program.

**COMPILATION** Translating the source code to binary code, so the computer
hardware understands it.

**CONSOLE APPLICATION** Computer program that interacts with the user through a
text based interface known as console.

**WEB APPLICATION** Computer program that interacts with the user through a web
browser over the internet.

**IDE** Integrated Development Environment is software application which
provides centralized environment for sofware development. It facilitates
project management (crud files), package management, compilation, running and
debugging.

**DEBUGGER** A tool that allow developers to inspect their code while executing.

## SIMPLE CALCULATIONS

### VARIABLES

**VARIABLE** Named storage location in memory which holds value. Variables have
type, name and value.

**DECLARATION** Introducing (giving name and type) variable to the compiler.

**INITIALIZATION** Giving initial value to variable.

**TYPE** Variables can hold different types like text, character, number, date,
picture, list etc.

### OPERATORS AND EXPRESSIONS

**OPERATOR** Symbol that performs operation on variables and values.

**ARITHMETIC OPERATORS** (+ - * / % ^)

**COMPARISON OPERATORS** (== != > >= < <=)

**LOGICAL OPERATORS** (! && ||)

**TERNARY OPERATORS** An operator which involves three operands. Examples for
ternary operators are `number % 2 == 0` and `condition ? true : false`.

**EXPRESSION** Combination of operators, variables and values that result in a
value.

### VARIABLE LIFETIME AND SCOPE

**VARIABLE LIFETIME** Period during which a variable exists.

**VARIABLE SCOPE** Part of the code where a variable can be accessed.

## CONDITIONAL STATEMENTS

**IF** Executes code if a given condition is true.

**ELSE-IF** Executes code if a given condition is true and all preceeding
statements are false.

**ELSE** Executes a code if all preceeding statemets are false.

**SWITCH** Executes code based on a given value.

```csharp
int number = 7;

if (number > 10)
{
    Console.WriteLine("The number is greater than 10.");
}
else if (number > 5)
{
    Console.WriteLine("The number is greater than 5.");
}
else
{
    Console.WriteLine("The number is 5 or less.");
}
```

```csharp
int dayOfWeek = 1;

switch (dayOfWeek)
{
    case 1: Console.WriteLine("Monday"); break;
    case 2: Console.WriteLine("Tuesday"); break;
    case 3: Console.WriteLine("Wednesday"); break;
    case 4: Console.WriteLine("Thursday"); break;
    case 5: Console.WriteLine("Friday"); break;
    case 6: Console.WriteLine("Saturday"); break;
    case 7: Console.WriteLine("Sunday"); break;
    default: Console.WriteLine("Invalid day"); break;
}
```

## LOOPS

**FOR** Control statement that executes a block of code for a given number of
times.

**WHILE** Control statement that executes a block of repeatedly until a given
condition is true.

**DO-WHILE** Similar to while loop but always executes atleast once.