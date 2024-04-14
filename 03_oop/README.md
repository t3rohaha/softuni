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

## Inheritance

A mechanism that allows a `derived` class to reuse, extend and modify all the
`members` of a `base` class except it's `constructor`.

- `Abstract class` a class that is designed to be a base class. It cannot be
instantiated.

- `Sealed class` a class that cannot be inherited further.

- `Interface` provides related functionality to classes.
    - By convention begin with capital `I`
    - It cannot be instantiated.
    - It can contain instance methods, properties, events, indexers, and may
    provide default implementation for them.
    - It may contain static constructors, fileds, constants or operators and
    it must provide default implementation for them.

### Notes

- Classes can inherit only one class.
- Classes can inherit behaviour from multiple interfaces.
