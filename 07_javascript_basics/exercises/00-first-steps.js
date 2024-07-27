// 01. Hello SoftUni
function helloSoftUni() {
    console.log('Hello SoftUni');
}

// 02. Nums 1...10
function nums1To10() {
    console.log(1);
    console.log(2);
    console.log(3);
    console.log(4);
    console.log(5);
    console.log(6);
    console.log(7);
    console.log(8);
    console.log(9);
    console.log(10);
}

// 03. Square Area
function squareArea(input) {
    const a = Number(input[0]);
    const area = a * a;
    console.log(area);
}

// 04. Inches to Centimeters
function inchesToCentimeters(input) {
    const inches = Number(input[0]);
    const cm = inches * 2.54;
    console.log(cm);
}

// 05. Greeting by Name
function greetingByName(input) {
    const name = input[0];
    console.log(`Hello, ${name}!`);
}

// 06. Concatenate Data
function concatenateData(input) {
    const firstName = input[0];
    const lastName = input[1];
    const age = Number(input[2]);
    const city = input[3];
    console.log(`You are ${firstName} ${lastName}, a ${age}-years old person from ${city}.`);
}

// 07. Projects Creation
function projectsCreation(input) {
    const timePerProject = 3;
    const architectName = input[0];
    const projectsCount = Number(input[1]);
    const totalTime = timePerProject * projectsCount;
    console.log(`The architect ${architectName} will need ${totalTime} hours to complete ${projectsCount} project/s.`);
}

// 08. Pet Shop
function petShop(input) {
    const dogFoodPrice = 2.5;
    const catFoodPrice = 4;
    const dogs = input[0];
    const cats = input[1];
    const dogsTotal = dogs * dogFoodPrice;
    const catsTotal = cats * catFoodPrice;
    const total = dogsTotal + catsTotal;
    console.log(`${total} lv.`);
}

// 09. Yard Greening
function yardGreening(input) {
    const price = 7.61; // per sqm
    const discPerc = 0.18;
    const sqm = Number(input[0]);

    const total = price * sqm;
    const disc = total * discPerc;
    const grandTotal = total - disc;

    console.log(`The final price is: ${grandTotal} lv.`);
    console.log(`The discount is: ${disc} lv.`);
}
