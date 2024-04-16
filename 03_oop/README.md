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
a `parent` class.

- `Sealed class` a class that cannot be inherited further.

### Notes

- Classes can inherit only one class.
- Classes can inherit behaviour from multiple interfaces.
- All `members` of a class can be inherited.

## ENCAPSULATION

Practice of `grouping` related `data and functionality` in a single unit and 
controlling the access to them. 

- __Classes__ are used to group related data and functionality.

- __Access modifiers__ control the access to the data and functionality.

### Notes

- If a mutable property has public getter and private setter, it's still
accessible.

## ABSTRACTION

Practice of `exposing` related `data and functionality` to a user and hiding the
implementation details.

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