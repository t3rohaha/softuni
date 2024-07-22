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

**UNIT TESTING** Software testing method, where individual units are tested in
isolation from the rest of the application. The main goal is to validate that
each unit works as expected.

**UNIT** Smallest testable part of the application, typically a function,
method or class.

**ISOLATION** Units are tested independently to ensure that they work correctly
on their own. Dependencies on other objects, databases, files are usually
mocked.

**AUTOMATION** Unit tests are usually autamated, allowing them to run repeatedly
and easily as part of the build proccess.

**ASSERTIONS** Unit tests include assertions that check whether the actual
output of a unit matches the expected output.

**TESTING FRAMEWORK** There are various frameworks available to facilitate unit
testing. In C#, common frameworks include MSTest, NUnit, xUnit.

**TRIPLE A PATTERN** Organize test code by breaking down test case.

**ARRENGE** Setup the object to be tested.

**ACT** Execute the operation and get the result.

**ASSERT** Assert the result is equal to the expected result.

**NAMING CONVENTION** MethodName_Condition_ExpectedResult. Better convention in
my opinion: ClassName+Precondition?_ExpectedResult_Condition.

### XUNIT

**XUNIT** Framework that facilitates unit testing.

**FACT** Attribute to run a single test.

**THEORY** Attribute that allows passing parameters to tests using `InlineData`
attribute.

**MEMBERDATA** Attribute that allows passing parameters to tests using members
that return `IEnumerable<object[]>`.

**CLASSDATA** Attribute that allows passing parameters to tests using classes
that implement `IEnumerable<object[]>`. Both ClassData and MemberData attributes
are used in more complex scenarios like reading the test parameters from an
external file.

### MOQ

**MOCKING** Simulating the behaviour of an external dependency.

**FAKE** Generic term to describe, stub or a mock.

**MOCK** Fake object that the test is asserted against.

**STUB** Fake object that the test is not asserted against. It's usually a
dependency that should be setup.

**MOQ** Mocking framework.

**NOTES**

- In xUnit for each test a new class is created, so the logic inside a
constructor is executed before each test, and the logic inside a dispose
method is executed after each test.

## COMMUNICATION AND EVENTS

**EVENT** Feature that enables communication between objects. It uses
publisher/subscriber model where one object (`publisher`) can notify multiple
other objects (`subscribers`) about changes or important occurences.

**PUBLISHER** A class that defines the handler method and fires the event.

**SUBSCRIBER** A class that provides the handler method and subscribes to the
publisher.

**DELEGATE** Pointer to function. A type that represents a reference to a
method. Enable you to treat methods as objects.

**EVENTHANDLER** Delegate that defines an event handler. Normally receive two
parameters `Sender` and `EventArgs`.

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

### CHAIN OF RESPONSIBILITY

**CHAIN OF RESPONSIBILITY** Behavioral pattern that allow requests to pass
through a chain of handlers. Each handler can either proccess the request or
pass it to the next handler.

**HANDLER** Abstract class that defines the next handler and a handle method.

**CONCRETE HANDLER** Concrete implementation of handler that either proccess
the request or pass it to the next handler.

**CLIENT** The entity that sends requests to the chain.

## COMMAND PATTERN

**COMMAND PATTERN** Behavioral design pattern that decouples the code that
invokes the command from the code that executes it.

**COMMAND** An interface for executing operations.

**CONCRETE COMMAND** A class that implements the command interface and defines
the binding between a Receiver object and an action.

**COMMAND RECEIVER** The object that does the actual work when Execute method is
called.

**COMMAND INVOKER** The object that knows how to execute a command, but doesn't
know how the command has been implemented.

**CLIENT** The object that creates a concrete Command and sets its Receiver.