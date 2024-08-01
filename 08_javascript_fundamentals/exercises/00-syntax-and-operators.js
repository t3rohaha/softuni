// 01. String Length
function stringLength(str1, str2, str3) {
    const sum = str1.length + str2.length + str3.length;
    const avg = Math.floor(sum / 3);

    console.log(sum);
    console.log(avg);
}

// 02. Math Operations
function mathOperations(num1, num2, operator) {
    let result = 0;
    switch (operator) {
        case '+': result = num1 + num2; break;
        case '-': result = num1 - num2; break;
        case '*': result = num1 * num2; break;
        case '/': result = num1 / num2; break;
        case '%': result = num1 % num2; break;
        case '**': result = num1 ** num2; break;
    }

    console.log(result);
}

// 03. Sum Of Numbers
function sumOfNumbers(n, m) {
    const num1 = +n;
    const num2 = +m;

    let sum = 0;
    for (let i = num1; i <= num2; i++) {
        sum += i;
    }

    return sum;
}

// 04. Largest Number
function largestNumber(num1, num2, num3) {
    let result;
    if (num1 > num2 && num1 > num3) {
        result = num1;
    } else if (num2 > num1 && num2 > num3) {
        result = num2;
    } else if (num3 > num1 && num3 > num2) {
        result = num3;
    }
    console.log(`The largest number is ${result}.`);
}

// 05. Circle Area
function circleArea(input) {
    const inputType = typeof input;
    if (inputType === 'number') {
        const r = +input;
        const area = Math.PI * r ** 2;
        console.log(area.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
}