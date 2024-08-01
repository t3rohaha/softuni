# JAVASCRIPT FUNDAMENTALS

## CONTENT

01. [Syntax and Operators](#syntax-and-operators)
02. [DOM](#dom)
03. [Functions](#functions)
04. [Arrays and Matrices](#arrays-and-matrices)
05. [Regex](#regex)
06. [Objects and JSON](#objects-and-json)

## SYNTAX AND OPERATORS

**DATA TYPES** Represent the type of data stored in a variable.

**NUMBER** Represents both integer and floating-point numbers.

**STRING** Represents a sequence of characters.

**BOOLEAN** Represents an entity with two values (true or false).

**UNDEFINED** Indicates that a variable has been declared but not assigned a
value.

**NULL** Indicates intentional absence of value.

**SYMBOL** Represents unique and immutable value, often used as object property
keys.

**BIGINT** Represents a number larger that the max value of Number data type.

**OBJECT** Collection of properties (key-value pairs).

**ARRAY** Indexed collection of values.

**FUNCTION** Represents a callable block of code.

**DATE** Represents date and time.

**REGEXP** Represents a regular expression.

**ERROR** Represents runtime error.

```javascript
    const a = 5;                            // Number
    const b = 5.5;                          // Number
    const c = 'Frank';                      // String
    const d = true;                         // Boolean
    const e;                                // Undefined
    const f = null;                         // Null
    const g = Symbol('symbol');             // Symbol
    const h = 10n;                          // BigInt
    const i = { name: 'Frank', age: 33 };   // Object
    const j = [ 1, 2, 3 ];                  // Array
    const k = function (input) {            // Function
        console.log(typeof input);
    };
    const l = new Date('2001-09-11');       // Date
    const m = /[a-z]+/;                     // Regex
    const n = new Error('404');             // Error
```

**VARIABLE DECLARATION** JS uses `const`, `let` and `var` keywords for variable
declaration. `const` does not allow changing the value, `let` allows access to
the variable in its scope, `var` allows global access to variable (not
recommended).

**NOTES**

- JavaScript has 7 primitive data types: Number, String, Boolean, Undefined,
Null, Symbol and BigInt. It has objects, which include general objects, arrays,
functions, dates, regex and errors.

## DOM

**DOM** Document object model is a programming interface that represents a web
document. It facilitates document manipulation by programs.

**DOM TREE** The document is represented as tree of nodes. Each node an be
element, attribute or text.

**PARENT NODE** Element containing another element.

**CHILD NODE** Element contained within another element.

**SIBLING NODES** Elements at the same level within the same parent.

```javascript
    const a = document.querySelector('p');
    a.innerHTML = 'This is <strong>modified</strong> content.';

    const b = document.querySelector('#article1');
    b.textContent = '<p>This is displayed as plain text.</p>';

    const c = document.querySelector('.image');
    c.src = 'https://example.com/someimage.png';
    c.alt = 'Some image thumbnail';

    const d = document.querySelector('#alert-btn');
    d.addEventListener('click', function() {
        alert('Button was clicked!');
    });

    document.addEventListener('keypress', function(event) {
        switch (event.key) {
            case 'Enter': alert('Enter was pressed!'); break;
            case 'Escape': alert('Escape was pressed!'); break;
        }
    });
```

## FUNCTIONS

**CLOSURE** Self-invoked function that returns a function. The inner function
has access to the variables declared in the outer function and a state can be
created.

```javascript
    // FUNCTION DECLARATION
    function sum1(a = 0, b= 0) {
        return a + b;
    }

    // FUNCTION EXPRESSION
    const sum2 = function sum2(a = 0, b = 0) {
        return a + b;
    };

    // ARROW FUNCTION
    const sum3 = (a = 0, b = 0) => {
        return a + b;
    };

    // SELF-INVOKING FUNCTION
    (function sum4(a = 0, b= 0) {
        console.log(a + b);
    })(1, 1);

    // CLOSURE
    let sum5 = (() => {
        let sum = 0;
        return (a) => {
            sum += a;
            return sum;
        };
    })();
    console.log(sum5(1));
    console.log(sum5(2));
    console.log(sum5(3));
```

## ARRAYS AND MATRICES

## REGEX

## OBJECTS AND JSON