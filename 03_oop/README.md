# C# OOP

## Classes

- `Members` Represent class data and behaviour.
    - `Fields` Variables declared at class scope.
    - `Constants` Fields whose value is set at compile time and cannot be
    changed.
    - `Methods` Define the actions that a class can perform.
    - `Events` Defined and triggered by delegates, they are a way to provide
    notifications to other objects.
    - `Operators` When you overload an operator you define it as a public static
    member of the type, so it is considered type member.
    - `Indexers` Enable an object to be indexed, similar to arrays.
    - `Construct` A method which is called when an object is created.
    - `Finalizer` Called runtime to when an object is about to be removed from
    memory. They are used rarely.
    - `Nested types` A class defined inside another class. Used to describe
    objects that are only used by the classes that use them.

- `Access Modifiers` control the acces to all types and all their members.
    - `public` can be applied to types and members. No restrictions.
    - `protected internal` can be applied to members only. Restricts access from
    non-derived classes in different assembly.
    - `protected` can be applied to types and members. Restricts access from
    non-derived classes.
    - `internal` can be applied to members only. Restrics access from different
    assembly.
    - `private protected` can be applied to members only. Restricts access from
    different assembly and non-derived classes.
    - `private` can be applied to members only. Restrics all access, except from
    within the class itself.

## INHERITANCE

A mechanism that allows a `child` class to inherit `data and functionality` from
a `parent` class. The child class can reuse and extend the functionality of the
parent class by adding new methods or overriding existing ones.

- `Sealed class` a class that cannot be inherited further.

### Notes

- Classes can inherit only one class.
- Classes can inherit behaviour from multiple interfaces.
- All `members` of a class can be inherited.

## ENCAPSULATION

Encapsulation is `grouping data and methods` that operate on the data into a
single unit. This concept prevents direct access to objects internal state and
ensures that data is accessed and modified through controlled methods. In C#
encapsulation is achieved with the use of `classes` to group the data and
functionality and `access modifiers` to control the access to the data and
functionality.

- __Classes__ are used to group related data and functionality.

- __Access modifiers__ control the access to the data and functionality.

### Notes

- If a mutable property has public getter and private setter, it's still
accessible.

## ABSTRACTION

Abstraction is the process of `hiding` implementation details and `exposing`
only the essential features of an object. It allows developers to focus on what
an object does rather than how it does it. In C# abstraction is achieved with
the use of `abstract classes` and `interfaces`.

- `Abstract class` a class that is designed to be a base class. It cannot be
instantiated.

- `Interface` provides related functionality to classes.
    - By convention begin with capital `I`
    - It cannot be instantiated.
    - It can contain instance methods, properties, events, indexers, and may
    provide default implementation for them.
    - It may contain static constructors, fileds, constants or operators and
    it must provide default implementation for them.

### Notes

- Do NOT provide abstraction, unless it is tested by implementing it.

## POLYMORPISM

Polymorphism, which means `"many forms"`, allows objects of different classes to
be treated as objects of common superclass. It enables a single interface to
represent multiple implementations and allows methods to behave differently
based on the objects they operate on. Polymorphism is typically achieved through
`method overriding` (runtime polymorphism) and `method overloading` (runtime
polymorphism).

### Notes

- In your source code you can call a method in a base class, and cause child
class overrided method to be executed.

- In C#, every type is polymorphic because all types, including user-defined
types, inherit from Object.

## SOLID

Acronym for five principles in OOP.

- `SRP` A class should have only one reason to change, meaning that it should
have one job or responsibility. We want to increase the `cohesion` between
things that chage for the same reasons, and we want to decrease the coupling
between those things that cange for different reasons.
    - Who is the program responsible to?

- `OCP` Software entities (classes, modules, funcitons etc.) should be open for
extension but closed for modification. In other words you should be able to
extend the behavior of a system without modifying existing code.
    - Plugin architecture.

- `LSP` Objects of a superclass should be replaceable with objects of its
subclasses without affecting the correctness of the program.  This means that
objects should be substitutable for their base types.

- `ISP` Clients should not be forced to depend on interfaces they don't use.
This principle states that you should prefer small, cohesive interfaces over
large, monolithic ones.

- `DIP` High level modules should not depend on low level modules, both should
depend on abstractions. Abstractions should not depend on details, details
should depend on abstractions. This principle promotes loose coupling between
modules by ensuring the high-level modules depend on abstract interfaces rather
then concrete implementations.

- [SRP](https://blog.cleancoder.com/uncle-bob/2014/05/08/SingleReponsibilityPrinciple.html),
[OCP](https://blog.cleancoder.com/uncle-bob/2014/05/12/TheOpenClosedPrinciple.html)

## Reflection

A Feature that allows to inspect and manipulate code (assemblies, types,
methods, fields etc.). Some key features:

- `Type Inspection` Allows you to obtain information about types and its
members. The `Type` class is used for this purposes.

- `Dynamic Invokation` Allows you to create instances of types, invoke methods
etc... `Activator` class is used for this purposes.

- `Assembly Loading` Allows you to load assemblies, inspect and manipulate
types from different assemblies.

## Attributes

A class that derives from Attribute class which provides metadata to code
(assemblies, types, methods, fields etc.). Public fields and properties that
are not constructor parameters are added as named parameters.

## Unit Testing

- `Fake` Generic term to describe, stub or a mock.

- `Mock` Fake object that the test is asserted against.

- `Stub` Fake object that the test is not asserted against. It's usually a
dependency that should be setup.

- `Triple A Pattern`
    - `Arrange` Setup the object to be tested.
    - `Act` Execute the operation and get the result.
    - `Assert` Assert the result is equal to the expected result.

- `Naming convention` MethodName_Condition_ExpectedResult

## xUnit

- `Fact` Attribute to run a single test.

- `Theory` Attribute that allows passing parameters to tests using `InlineData`
attribute.