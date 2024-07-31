# JAVASCRIPT BASICS

## CONTENT

01. [Setup](#setup)
02. [First Steps](#first-steps)
03. [Conditions](#conditions)
04. [Loops](#loops)

## SETUP

- Download and install [node.js](https://nodejs.org/en)

## FIRST STEPS

```javascript
    // FUNCTION DECLARATION
    function printSum(input) {

        // VARIABLE INITIALIZATION + TYPE CASTING + ARRAY ACCESS
        const a = Number(input[0]);
        const b = Number(input[1]);
        const sum = a + b;

        // CONSOLE OUTPUT + INTERPOLATION
        console.log(`${a} + ${b} = ${sum}`);
    }

    // FUNCTION INVOCATION
    printSum(1, 1);
```

**NOTES**

- Because JavaScript is `interpreted` (code is executed directly, it is not
compiled first) and `dynamically typed` (variables can store any type of data at
any time) many errors (such as calling undefined function) are not detected
until the code is actually executed. Some tools (ESLint) can show errors as you
write code.

## CONDITIONS

```javascript

    // COMPARISON OPERATORS
    console.log(2 < 3);     // true
    console.log(2 > 3);     // false
    console.log(2 == '2');  // true  
    console.log(2 === '2'); // false

    // IF-ELSE
    const input = 'red';
    if (input === 'red') {
        console.log('tomato is red');
    } else if (input === 'orange') {
        console.log('orange is orange');
    } else {
        console.log('banana is neither red or orange');
    }

    // SWITCH-CASE
    const number = 1;
    switch (number) {
        case 1: console.log('Monday'); break;
        case 2: console.log('Tuesday'); break;
        case 3: console.log('Wednesday'); break;
        // ...
        default: console.log('No such day!'); break;
    }

    // ROUNDING
    const pi = 3.14159;
    console.log(Math.floor(pi));    // 3
    console.log(Math.ceil(pi));     // 4
    console.log(pi.toFixed(2));     // 3.14

    // VARIABLE SCOPE
    function helloWorld() {
        const test = 'Hello, World!';
    }

    console.log(test) // Error!
```

**NOTES**

- In JavaScript there are two types of comparison `==` (casts values and
compares) and `===` (compares if types are equal, than if value is equal).

## LOOPS

```javascript
    for (let i = 0; i < 10; i++) {
        console.log(i);
    }

    let i = 0;
    while (i < 10) {
        console.log(i);
        i++;
    }

    for (let h = 0; h <= 23; h++) {
        for (let m = 0; m <= 59; m++) {
            console.log(`${h}:${m}`);
        }
    }
```