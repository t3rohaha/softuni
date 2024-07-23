# C# OOP BASICS

## CONTENT
01. [Classes](#classes)
02. [Architecture and Refactoring](#architecture-and-refactoring)
03. [Encapsulation](#encapsulation)
04. [Inheritance](#inheritance)
05. [Abstraction](#abstraction)
06. [Polymorphism](#polymorphism)
07. [More](#more)
    01. [Types of class reuse](#types-of-class-reuse)

## CLASSES

**CLASS** A type that describes the data and behavior of an object.

### CLASS MEMBERS

**CLASS MEMBERS** Represent class data and behaviour.

**FIELD** Variable declared at class scope.

**CONSTANT** Field whose value is set at compile time and cannot be changed.

**METHOD** Define the actions that a class can perform.

**EVENT** Enable class or object to notify another class or object when
something of interest occurs.

**OPERATOR OVERLOAD** Changing the result of an operator in case one or both of
the operands are of that type.

**INDEXER** Enable creating class, struct or interface that can be accessed like
array.

**CONSTRUCTOR** A method which is called when an object is created.

**FINALIZER** A method which is called when an object is about to be deleted
from memory. They are used rarely.

**NESTED TYPES** A class defined inside another class. Used to describe objects
that are only used by the classes that use them.

### ACCESS MODIFIERS

**ACCESS MODIFIERS** Control the access to types and members.

**PUBLIC** Applied to types and members. No restrictions to the access.

**PRIVATE** Applied to members only. Restricts all access, except within the
class itself.

**PROTECTED** Applied to types and members. Restricts access from non-derived
classes.

**INTERNAL** Applied to types and members. Restricts access from other
assemblies.

**PROTECTED INTERNAL** Applied to members only. Restricts access from
non-derived classes in other assemblies.

**PRIVATE PROTECTED** Applied to members only. Restricts access from different
assemblies and non-derived classes.

## ARCHITECTURE AND REFACTORING

**PROJECT ARCHITECTURE** Structured design of software systems. It includes
organizing code into `methods`, `classes` and `projects` to ensure that a system
is `scalable`, `maintainable` and `easy to understand`.

**SCALABILITY** How easily a system can grow.

**MAINTAINABILITY** How easily a system can be understood, corrected, enhanced.

**REFACTORING** Changing project structure without changing it's behavior.

## ENCAPSULATION

**ENCAPSULATION** Grouping data and methods into single unit and controlling
the data access. In C# encapsulation is achieved with the use of `classes` to
group the data and `access modifiers` to control and restrict the access to
data and functionality.

**CLASSES** Used to group related data and functionality (Review in previous
heading).

**ACCESS MODIFIERS** Control the access to the data and functionality (Review
in previous heading).

**THIS** Used as a reference to the current object. Can be used to modify
the data of the current object. Can be used to invoke the methods of the current
object. Can be used to pass the current object as a paramenter. Can be used to
return the current object from a method. Can be used for constructor
overloading.

**VALIDATION** Ensures an object preserves a valid state e.g. an objects
properties provide getters and setters (methods used to access and modify
private fields) which are a good place to perform validation.

**NOTES**

- If a mutable property has public getter and private setter, it's still
accessible.

## INHERITANCE

**INHERITANCE** A way for a `child` class to inherit `data and functionality`
from a `parent` class. The child class can `reuse` and `extend` the
functionality of the parent class by adding new methods or overriding existing
ones.

**PARENT** The class giving its members to the its child class. Also called
`super class` or `base class`.

**CHILD** The class taking members from its parent class. Also called `subclass`
or `derived` class.

**SEALED** Keyword applied to classes and members. If a class is sealed it
cannot be inherited. If a class member is sealed it cannot be overridden.

**BASE** Keyword used to access members from parent class.

**VIRTUAL** Keyword used to define a method that can be overridden by child
class. These methods usually provide default implementation and the child class
decides if concrete implementation is required.

**NOTES**

- Classes can inherit only one class.
- Classes can inherit behaviour from multiple interfaces.
- All `members` of a class can be inherited.
- Constructors are not iherited.

## ABSTRACTION

**ABSTRACTION** Abstraction is the process of `hiding` implementation details
and `exposing` only the essential features of an object. It allows developers to
focus on what an object does rather than how it does it. In C# abstraction is
achieved with the use of `abstract classes` and `interfaces`.

**ABSTRACT CLASS** A class that cannot be instantiated. It is designed to be
parent class and may contain abstract members that must be implemented by the
child class.

**INTERFACE** Feature that define a set of functionality that implementing
classes must adhere to. It enables `polymorphism` and help achieve
`loose-coupling` between components in oop.

**NOTES**

- A class may inherit only one abstract class.

- For a class to have abstract method, it should be abstract.

- By convention interfaces begin with capital `I`.

- All the members of an interface are `public`, so they cannot include
`access modifiers`.

- Interfaces can provide members without implementation which are implicitly 
`public abstract` and must be implemented by derived classes.

- Classes that implement an interface can provide concrete implementation to all
of its members.

- Classes can implement multiple interfaces.

- Static members cannot be overridden.

## POLYMORPISM

**POLYMORPHISM** Means `"many forms"`, allows objects of different classes to
be treated as objects of common superclass. It enables a single interface to
represent multiple implementations and allows methods to behave differently
based on the objects they operate on. Polymorphism is typically achieved through
`method overriding` (runtime polymorphism) and `method overloading`
(compile-time polymorphism).

**IS** Keyword used to check if object is an instance of a givent type.

**NOTES**

- In your source code you can call a method in a base class, and cause child
class overrided method to be executed.

- In C#, every type is polymorphic because all types, including user-defined
types, inherit from Object.

## MORE

### TYPES OF CLASS REUSE

**INHERITANCE** Allow child class to inherit the members of parent class. This
way the child class `extends` the parent class.

**COMPOSITION** Creating complex objects by using more simple objects that
provide the desired funcitonality.

**DELEGATION** Delegation involves passing (delegating) the resposibility for
handling certain functionality from one object to another.