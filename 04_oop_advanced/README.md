# C# OOP ADVANCED

## CONTENT
01. [SOLID](#solid)
02. [Generics](#generics)
03. [Iterators](#iterators)
04. [Comparators](#comparators)
05. [Reflection and Attributes](#reflection-and-attributes)
06. [Unit Testing](#unit-testing)
07. [Communication and Events](#communication-and-events)
08. [More](#more)
    01. [Design Patterns](#design-patterns)

## SOLID

**SOLID** Principles of object oriented design, which are aimed at creating more
understandable, flexible and maintainable software.

**SRP**
*"A class should have only one reason to change!"*.
Aclass should have one clear task and contain only members that work towards it.
To achieve `strong coheson` the class members should be related and focused
towards the main task. To achieve `loose coupling` we should decrease the
coupling between different classes. We can use *Encapsulation* to group related
functionality and *Abstraction* to decouple different classes.

**OCP**
*"Software entities should be open for extension but closed for modification"*.
You should be able to extend the funcitonality of a class, without modifying it
internally. This can be achieved through *Inheritance*.

**LSP**
*"Objects of a superclass should be replaceable with objects of its subclasses without affecting the correctness of the program"*.
Objects should be replaceble for their base types and *Polymorphism* should not
break existing code.

**ISP**
*"Clients should not be forced to depend on methods they don't use"*.
This can be achieved when you separate a large interface with a lot of methods
into smaller more cohesive ones.

**DIP**
*"High level modules should not depend on low level modules, both should depend on abstractions"*.
*"Abstractions should not depend on details, details should depend on abstractions"*.
This principle promotes loose coupling between modules by ensuring the
high-level modules depend on abstract interfaces rather then concrete
implementations. This can be achieved through *Abstraction*.

## GENERICS

**GENERIC** C# feature which enables `interfaces`, `classes`, `methods` and
`delegates` to be defined with the types of data they will work with. Multiple
generic types can be defined (e.g. Dictionary<TKey, TValue>).

**GENERIC CONSTRAINTS** Specifying the types of generics supported.

## ITERATORS AND COMPARATORS

**ITERATOR** C# feature which allows creating objects that can be enumerated.

**IENUMERABLE** Interface that provides a way to iterate over a collection. All
classes that implement IEnumerable can be iterated with foreach loop. It
provides a single method `GetEnumerator` which handles the iteration logic over
the collection.

**IENUMERATOR** Interface that handles the iteration over a collection.

**ITERATOR METHOD** A method that returns `IEnumerable` or `IEnumerator` and
contains one or more `yield` statements. It can simplify the implementation of
`IEnumerator`.

**YIELD** Keyword used inside `yield methods`. It returns a value and
suspends method execution until `foreach` asks for another value.

**PARAMS** A keyword that allows passing variable number of arguments. Should
always be last in parameter list.

**COMPARATOR** C# feature which allows creating objects that can be compared.

**ICOMPARABLE** Interface that defines a method `CompareTo` used to compare the
current object to another one. Return values should be -1, 0, 1.

**ICOMPARER** Interface that defines a method `Compare` used to compare two
objects. Return values should be -1, 0, 1.

## REFLECTION AND ATTRIBUTES

**REFLECTION** A Feature that allows to inspect and manipulate code (assemblies,
types, methods, fields etc.). Some key features are type inspection, dynamic
invokation and assembly loading.

**TYPE INSPECTION** Allows you to obtain information about types and its
members. The `Type` class is used for this purposes.

**DYNAMIC INVOKATION** Allows you to create instances of types, invoke methods
etc... `Activator` class is used for this purposes.

**ASSEMBLY LOADING** Allows you to load assemblies, inspect and manipulate
types from different assemblies.

**ATTRIBUTES** A class that derives from Attribute class which provides metadata
to code (assemblies, types, methods, fields etc.). Public fields and properties
that are not constructor parameters are added as named parameters.

## UNIT TESTING

**TRIPLE A PATTERN**
- `Arrange` Setup the object to be tested.
- `Act` Execute the operation and get the result.
- `Assert` Assert the result is equal to the expected result.

**NAMING CONVENTION** MethodName_Condition_ExpectedResult

**xUnit**

- `Fact` Attribute to run a single test.

- `Theory` Attribute that allows passing parameters to tests using `InlineData`
attribute.

- `MemberData` Attribute that allows passing parameters to tests using members
that return IEnumerable<object[]>.

- `ClassData` Attribute that allows passing parameters to tests using classes
that implement IEnumerable<object[]>. Both Class and Member Data attributes
are used in more complex scenarios like reading the test parameters from an
external file.

- `Mocking` Simulating the behaviour of an external dependency.

- `Fake` Generic term to describe, stub or a mock.

- `Mock` Fake object that the test is asserted against.

- `Stub` Fake object that the test is not asserted against. It's usually a
dependency that should be setup.

**NOTES**

- In xUnit for each test a new class is created, so the logic inside a
constructor is executed before each test, and the logic inside a dispose
method is executed after each test.

## COMMUNICATION AND EVENTS

## MORE

### DESIGN PATTERNS

**DESIGN PATTERN** Solution to a common software design problem. Solutions are
designed using best practices making them readable, reusable, scalable and
maintainable. Apart from that they provide common vocabulary for developers to
communicate about software design problems and solutions.

**CREATIONAL PATTERN** Deal with object creation, it hides the details of
creating an object.

**STRUCTURAL PATTERN** Deal with the composition of classes and objects which
create larger structures. 

**BEHAVIORAL PATTERN** Deal with the communication between objects, defining how
they interect and distribute responsibilities.