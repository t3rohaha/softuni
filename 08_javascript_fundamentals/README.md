# JAVASCRIPT FUNDAMENTALS

## CONTENT

01. [Data Types](#data-types)
02. [DOM](#dom)
03. [Functions](#functions)
04. [Arrays and Matrices](#arrays-and-matrices)
05. [Strings and Regex](#regex)
06. [Objects and JSON](#objects-and-json)
07. [More](#more)
    01. [Bubble Sort](#bubble-sort)

## DATA TYPES

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
// PRIMITIVE TYPES
const a = 5;                                // NUMBER
const b = 5.5;                              // NUMBER
const c = 'Frank';                          // STRING
const d = true;                             // BOOLEAN
const e;                                    // UNDEFINED
const f = null;                             // NULL
const g = Symbol('symbol');                 // SYMBOL
const h = 10n;                              // BIGINT

// OBJECTS
const i = { name: 'Frank', age: 33 };       // OBJECT
const j = [ 1, 2, 3 ];                      // OBJECT (ARRAY)
const k = function (input) {                // FUNCTION
    console.log(typeof input);
};
const l = new Date('2001-09-11');           // OBJECT (DATE)
const m = /[a-z]+/;                         // OBJECT (REGEX)
const n = new Error('404');                 // OBJECT (ERROR)

// TYPE CHECKING
typeof a === 'number';                      // TRUE 
typeof c === 'string';                      // TRUE 
typeof k === 'function';                    // TRUE 
typeof i === 'object' && !Array.isArray(i); // TRUE 
Array.isArray(j);                           // TRUE 
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

**DOM TREE** The document is represented as tree of nodes. Each node can be
element, attribute or text.

**PARENT NODE** Element containing another element.

**CHILD NODE** Element contained within another element.

**SIBLING NODES** Elements at the same level within the same parent.

```javascript
// SELECTORS
document.querySelector('p');                // SELECT BY TAG
document.querySelector('.image');           // SELECT BY CLASS
document.querySelector('#article1');        // SELECT BY ID
document.querySelectorAll('a');             // SELECT ALL
document.querySelectorAll('#articles a');   // SELECT NESTED ELEMENTS

// CRUD
document.createElement(element);                // CREATE ELEMENT
document.createTextNode(text);                  // CREATE TEXT NODE
document.removeChild(element);                  // REMOVE CHILD
document.appendChild(element);                  // APPEND CHILD
document.replaceChild(newEl, oldEl);            // REPLACE CHILD
a.insertAdjacentHTML('beforeend', '<p>Hi</p>'); // INSERT HTML
e.textContent = '<p>Hello</p>';                 // UPDATE TEXT
a.innerHTML = '<p>Hello</p>';                   // UPDATE HTML

// MODIFY ATTRIBUTES
c.src = 'https://example.com/someimage.png';
c.alt = 'Some image thumbnail';
e.style.color = 'blue';

// ADD CLICK EVENT
d.addEventListener('click', function() {
    alert('Button was clicked!');
});

// ADD KEYPRESS EVENT
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

console.log(sum5(1));   // 1
console.log(sum5(2));   // 3
console.log(sum5(3));   // 6
```

## ARRAYS AND MATRICES

```javascript
// INITIALIZATION
const arr1 = [ 1, 2, 3, 4, 5 ];
const arr2 = [ 'a', 'b', 'c' ];
const arr3 = [ 1, 'a', { name: 'Frank' } ];
const arr4 = Array.from(arr1);

// CRUD
arr1.push(6);                   // ADD TO END
arr1.unshift(0);                // ADD TO START
arr1[0];                        // GET
arr1.slice(0, 2);               // GET (INDEX, COUNT)
arr1[0] = 100;                  // MODIFY
arr1.pop();                     // REMOVE LAST
arr1.splice(0, 1);              // REMOVE (INDEX, COUNT)
arr1[-1];                       // UNDEFINED

// SORT
arr1.sort();                    // SORT ALPHABETICALLY (AS STRING)
arr1.sort((a, b) => a - b);     // SORT AS NUMBERS

// MORE
arr1.length;                    // 5
arr1.includes(10);              // TRUE
arr1.indexOf(10);               // 0
arr1.toString();                // 1,2,3,4,5
arr1.reverse();                 // 5,4,3,2,1
Array.isArray(arr1);            // TRUE

// MATRIX
const matrix = [
    [ 1, 2, 3 ],
    [ 1, 2, 3 ],
    [ 1, 2, 3 ]
];

matrix[0][0];                   // 1
matrix[0][1];                   // 2
matrix[0][2];                   // 3
```

## STRINGS AND REGEX

```javascript
// INITIALIZATION
const str1 = 'This is a very long string to wrap accross multiple lines ' +
             'otherwise my code is unreadable.';

// ASCII
String.fromCharCode(num[]); // FROM ASCII TO CHAR
str1.charCodeAt(index);     // FROM CHAR TO ASCII

// SEARCH
str1[0];                    // T
str1.indexOf('is');         // 2
str1.lastIndexOf('is');     // 76
str1.substring(0, 4);       // This
str1.includes('Is');        // true 

// OTHER
str1.length;                // 90
str1.slice(0, 4);           // This
str1.replace('is', 'xx');

// REGEX
const pattern = new Regex('is', 'g');
const pattern2 = /[0-9]+/g;

str1.match(pattern);                    // GET ALL MATCHES
str1.matchAll(pattern);                 // GET ALL MATCHES

str1.search(pattern);                   // GET INDEX OF FIRST MATCH
patter2.test(str1);                     // FALSE
```

**NOTES**

- More on Regex can be found here: [C# Fundamentals](https://github.com/t3rohaha/softuni/tree/main/01_csharp_fundamentals)

## OBJECTS AND JSON

**OBJECT** Data type which holds data and functionality.

```javascript
// OBJECT INITIALIZATION
const person1 = {
    firstName: 'Frank',
    lastName: 'Lampard',
    age: 33,
    greet: function() {
        console.log(`${this.firstName} ${this.lastName}: Hello!`);
    }
};

const person2 = new Object();
person2.firstName = 'John';
person2.lastName = 'Terry';
person2.age = 34;
person2.greet = function() {
    console.log(`${this.firstName} ${this.lastName}: Hello!`);
};

// OBJECT ACCESS
person.firstName;
person.lastName;
person.greet();

// JSON TO OBJECT
const jsonStr1 = '{"firstName":"Frank"}';
const person3 = JSON.parse(jsonStr1);

// OBJECT TO JSON
const jsonStr2 = JSON.stringify(person3);
```

**JSON** JavaScript Object Notation, is a lightweight and human readable data
interchange format based on javascript.

```json
// JSON STRUCTURE
{
    "firstName": "Frank",                       // STRING
    "lastName": "Lampard",                      // STRING
    "age": 33,                                  // NUMBER
    "address": {                                // OBJECT
        "country": "UK",
        "city": "London"
    },
    "phoneNumbers": ["555-4444", "555-3333"],   // ARRAY
    "currentTeam": null                         // NULL
}
```

## MORE

### BUBBLE SORT

```javascript
// Easy sorting algorithm.

let nums = [1, 2, 5, 4, 3, 6, 7];

// Cycle through all the elements. Each pass guarantees that the largest
// unsorted element is set to its correct position.
for (let i = 0; i < nums.length - 1; i++) {
    let swapped = false;

    // Compare each pair of adjacent elements until the last sorted element.
    for (let j = 0; j < nums.length - 1 - i; j++) {
        if (nums[j] > nums[j + 1]) {
            let temp = nums[j];
            nums[j] = nums[j + 1];
            nums[j + 1] = temp;
            swapped = true;
        }
    }

    // If no swaps were made the array is already ordered.
    if (!swapped) {
        break;
    }
}
```