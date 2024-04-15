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

A mechanism that allows a `derived` class to inherit all the `members` of a
`base` class except it's `constructor`.

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

## ENCAPSULATION

Practice of grouping related data and functionality and controlling the access
to them. 

- __Classes__ are used to group related data and functionality.

- __Access modifiers__ control the access to the data and functionality.

### Notes

- If a mutable property has public getter and private setter, it's still
accessible.