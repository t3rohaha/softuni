// 01: Cinema
function cinema(input) {
    const projectionType = input[0];
    const rows = Number(input[1]);
    const cols = Number(input[2]);

    let price = 0;
    switch (projectionType) {
        case 'Premiere': price = 12; break;
        case 'Normal': price = 7.5; break;
        case 'Discount': price = 5; break;
        default: console.log('Invalid projection type.');
    }

    const total = (rows * cols * price).toFixed(2);
    console.log(`${total} leva`);
}

// 02: Summer Outfit
function summerOutfit(input) {
    const degrees = Number(input[0]);
    const dayTime = input[1];

    let outfit = 'invalid';
    let shoes = 'invalid';
    if (degrees >= 10 && degrees <= 18) {
        switch (dayTime) {
            case 'Morning':
                outfit = 'Sweatshirt';
                shoes = 'Sneakers';
                break;
            case 'Afternoon':
                outfit = 'Shirt';
                shoes = 'Moccasins';
                break;
            case 'Evening':
                outfit = 'Shirt';
                shoes = 'Moccasins';
                break;
        }
    } else if (degrees > 18 && degrees <= 24) {
        switch (dayTime) {
            case 'Morning':
                outfit = 'Shirt';
                shoes = 'Moccasins';
                break;
            case 'Afternoon':
                outfit = 'T-Shirt';
                shoes = 'Sandals';
                break;
            case 'Evening':
                outfit = 'Shirt';
                shoes = 'Moccasins';
                break;
        }
    } else if (degrees >= 25) {
        switch (dayTime) {
            case 'Morning':
                outfit = 'T-Shirt';
                shoes = 'Sandals';
                break;
            case 'Afternoon':
                outfit = 'Swim Suit';
                shoes = 'Barefoot';
                break;
            case 'Evening':
                outfit = 'Shirt';
                shoes = 'Moccasins';
                break;
        }
    } else {
        console.log('Invalid degrees.');
    }

    const output = `It's ${degrees} degrees, get your ${outfit} and ${shoes}.`;
    console.log(output);
}

// 03: New House
function newHouse(input) {
    const flowersType = input[0];
    const flowersCount = Number(input[1]);
    const budget = Number(input[2]);

    let price = 0;
    switch (flowersType) {
        case 'Roses': price = 5; break;
        case 'Dahlias': price = 3.8; break;
        case 'Tulips': price = 2.8; break;
        case 'Narcissus': price = 3; break;
        case 'Gladiolus': price = 2.5; break;
        default: console.log('Invalid flower type!');
    }

    const total = price * flowersCount;
    let disc = 0;
    let surcharge = 0;
    if (flowersType === 'Roses' && flowersCount > 80) {
        disc = total * 0.10;
    } else if (flowersType === 'Dahlias' && flowersCount > 90) {
        disc = total * 0.15;
    } else if (flowersType === 'Tulips' && flowersCount > 80) {
        disc = total * 0.15;
    } else if (flowersType === 'Narcissus' && flowersCount < 120) {
        surcharge = total * 0.15;
    } else if (flowersType === 'Gladiolus' && flowersCount < 80) {
        surcharge = total * 0.20;
    }

    const grandTotal = total + surcharge - disc;
    if (budget >= grandTotal) {
        const budgetLeft = (budget - grandTotal).toFixed(2);
        console.log(`Hey, you have a great garden with ${flowersCount} ${flowersType} and ${budgetLeft} leva left.`);
    } else {
        const shortfall = (grandTotal - budget).toFixed(2);
        console.log(`Not enough money, you need ${shortfall} leva more.`);
    }
}

// 04: Fishing Boat
function fishingBoat(input) {
    const budget = Number(input[0]);
    const season = input[1];
    const fishermanCount = Number(input[2]);

    let boatPrice = 0;
    switch (season) {
        case 'Spring': boatPrice = 3000; break;
        case 'Summer': boatPrice = 4200; break;
        case 'Autumn': boatPrice = 4200; break;
        case 'Winter': boatPrice = 2600; break;
        default: console.log('Invalid season.');
    }

    let disc1 = 0;
    if (fishermanCount <= 6) {
        disc1 = boatPrice * 0.1;
    } else if (fishermanCount <= 11) {
        disc1 = boatPrice * 0.15;
    } else {
        disc1 = boatPrice * 0.25;
    }

    let boatTotalPrice = boatPrice - disc1;
    let disc2 = 0;
    if (season != 'Autumn' && fishermanCount % 2 === 0) {
        disc2 = boatTotalPrice * 0.05;
    } 

    boatTotalPrice -= disc2;

    if (budget >= boatTotalPrice) {
        const budgetLeft = (budget - boatTotalPrice).toFixed(2);
        console.log(`Yes! You have ${budgetLeft} leva left.`);
    } else {
        const shortage = (boatTotalPrice - budget).toFixed(2);
        console.log(`Not enough money! You need ${shortage} leva.`);
    }
}

// 05: Journey
function journey(input) {
    const budget = Number(input[0]);
    const season = input[1];

    let destination = 'Invalid';
    let spent = 0;
    if (budget <= 100) {
        destination = 'Bulgaria';
        switch (season) {
            case 'summer': spent = budget * 0.3; break;
            case 'winter': spent = budget * 0.7; break;
        }
    } else if (budget <= 1000) {
        destination = 'Balkans';
        switch (season) {
            case 'summer': spent = budget * 0.4; break;
            case 'winter': spent = budget * 0.8; break;
        }
    } else {
        destination = 'Europe';
        switch (season) {
            case 'summer': spent = budget * 0.9; break;
            case 'winter': spent = budget * 0.9; break;
        }
    }

    let housingType = 'Invalid';
    switch (season) {
        case 'summer': housingType = 'Camp'; break;
        case 'winter': housingType = 'Hotel'; break;
    }

    if (destination === 'Europe') {
        housingType = 'Hotel';
    }
         

    console.log(`Somewhere in ${destination}`);
    console.log(`${housingType} - ${spent.toFixed(2)}`);
}

// 06: Operations between numbers
function operationsBetweenNumbers(input) {
    const a = Number(input[0]);
    const b = Number(input[1]);
    const operator = input[2];

    let result = 0;
    switch (operator) {
        case '+': console.log(`${a} + ${b} = ${a + b}`); break;
        case '-': console.log(`${a} - ${b} = ${a - b}`); break;
        case '*': console.log(`${a} * ${b} = ${a * b}`); break;
        case '%': console.log(`${a} % ${b} = ${a % b}`); break;
        case '/':
            console.log(b !== 0
                ? `${a} / ${b} = ${(a / b).toFixed(2)}`
                : `Cannot divide ${a} by zero`
            );
            break;
    }
}

// 07: Hotel Room
function hotelRoom(input) {
    const month = input[0];
    const daysCount = Number(input[1]);

    let studioPrice = 0;
    let apartmentPrice = 0;

    if (month === 'May' || month === 'October') {
        studioPrice = 50 * daysCount;
        apartmentPrice = 65 * daysCount;;

        if (daysCount > 7 && daysCount <= 14) {
            studioPrice -= studioPrice * 0.05;
        }

        if (daysCount > 14) {
            studioPrice -= studioPrice * 0.3;
        }
    }

    if (month === 'June' || month === 'September') {
        studioPrice = 75.2 * daysCount;;
        apartmentPrice = 68.7 * daysCount;;

        if (daysCount > 14) {
            studioPrice -= studioPrice * 0.2;
        }
    }

    if (month === 'July' || month === 'August') {
        studioPrice = 76 * daysCount;;
        apartmentPrice = 77 * daysCount;;
    }

    if (daysCount > 14) {
        apartmentPrice -= apartmentPrice * 0.1;
    }

    console.log(`Apartment: ${apartmentPrice.toFixed(2)} lv.`);
    console.log(`Studio: ${studioPrice.toFixed(2)} lv.`);
}

// 08: On Time for the Exam
function onTimeForExam(input) {
    const examHour = Number(input[0]);
    const examMin = Number(input[1]);
    const arrivalHour = Number(input[2]);
    const arrivalMin = Number(input[3]);

    const examTime = (examHour * 60) + examMin;
    const arrivalTime = (arrivalHour * 60) + arrivalMin;

    if (examTime < arrivalTime) {
        console.log('Late');
    } else if (examTime - arrivalTime <= 30) {
        console.log('On time');
    } else {
        console.log('Early');
    }

    if (examTime !== arrivalTime) {
        const absDiff = Math.abs(examTime - arrivalTime);
        const hours = Math.floor(absDiff / 60);
        const mins = (absDiff % 60).toString().padStart(2, '0');

        if (examTime > arrivalTime) {
            if (absDiff < 60) {
                console.log(`${absDiff} minutes before the start`)
            } else {
                console.log(`${hours}:${mins} hours before the start`)
            }
        } else {
            if (absDiff < 60) {
                console.log(`${absDiff} minutes after the start`)
            } else {
                console.log(`${hours}:${mins} hours after the start`)
            }
        }
    }
}

// 09: Ski Trip
function skiTrip(input) {
    const stayDays = Number(input[0]) - 1;
    const roomType = input[1];
    const rating = input[2];

    let price = 0;
    switch (roomType) {
        case 'room for one person': price = stayDays * 18; break;
        case 'apartment': price = stayDays * 25; break;
        case 'president apartment': price = stayDays * 35; break;
    }

    if (roomType == 'apartment') {
        if (stayDays < 10) price -= price * 0.3;
        else if (stayDays < 15) price -= price * 0.35;
        else price -= price * 0.5;
    }

    if (roomType == 'president apartment') {
        if (stayDays < 10) price -= price * 0.1;
        else if (stayDays < 15) price -= price * 0.15;
        else price -= price * 0.2;
    }

    switch (rating) {
        case 'positive': price += price * 0.25; break;
        case 'negative': price -= price * 0.10; break;
    }

    console.log(price.toFixed(2));
}