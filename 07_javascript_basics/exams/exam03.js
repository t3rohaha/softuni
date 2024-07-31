// 01. Easter Lunch
function easterLunch(input) {
    const easterBread = 3.2, eggs = 4.35, cookies = 5.4, eggPaint = 0.15;
    const easterBreadCount = Number(input[0]);
    const eggsCount = Number(input[1]);
    const cookiesCount = Number(input[2]);

    const easterBreadPrice = easterBread * easterBreadCount;
    const eggsPrice = eggs * eggsCount;
    const cookiesPrice = cookies * cookiesCount;
    const eggPaintPrice = eggPaint * eggsCount * 12;

    const total = easterBreadPrice + eggsPrice + cookiesPrice + eggPaintPrice;

    console.log(`${total.toFixed(2)}`);
}

// 02. Easter Bakery
function easterBakery(input) {
    const flourPrice = Number(input[0]);
    const sugarPrice = flourPrice - flourPrice * 0.25;
    const eggsPrice = flourPrice + flourPrice * 0.1;
    const yeastPrice = sugarPrice - sugarPrice * 0.8;

    const flourQty = Number(input[1]);
    const sugarQty = Number(input[2]);
    const eggsQty = Number(input[3]);
    const yeastQty = Number(input[4]);

    const flourTotal = flourPrice * flourQty;
    const sugarTotal = sugarPrice * sugarQty;
    const eggsTotal = eggsPrice * eggsQty;
    const yeastTotal = yeastPrice * yeastQty;

    const total = flourTotal + sugarTotal + eggsTotal + yeastTotal;

    console.log(`${total.toFixed(2)}`);
}

// 03. Easter Party
function easterParty(input) {
    const guestsCount = Number(input[0]);
    const guestCover = Number(input[1]);
    let guestsTotal = guestsCount * guestCover;

    if (guestsCount >= 10 && guestsCount <= 15) {
        guestsTotal -= guestsTotal * 0.15;
    } else if (guestsCount > 15 && guestsCount <= 20) {
        guestsTotal -= guestsTotal * 0.2;
    } else if (guestsCount > 20) {
        guestsTotal -= guestsTotal * 0.25;
    }

    const budget = Number(input[2]);
    const cakeTotal = budget * 0.1;
    const total = guestsTotal + cakeTotal;

    if (budget >= total) {
        const left = (budget - total).toFixed(2);
        console.log(`It is party time! ${left} leva left.`);
    } else {
        const shortage = (total - budget).toFixed(2);
        console.log(`No party! ${shortage} leva needed.`);
    }
}

// 04. Easter Guests
function easterGuests(input) {
    const easterBreadPrice = 4, eggPrice = 0.45;
    const guestCount = Number(input[0]);
    const budget = Number(input[1]);

    const easterBreadQty = Math.ceil(guestCount / 3);
    const eggsQty = guestCount * 2;

    const easterBreadTotal = easterBreadQty * easterBreadPrice;
    const eggsTotal = eggsQty * eggPrice;

    const total = easterBreadTotal + eggsTotal;

    if (budget >= total) {
        const left = (budget - total).toFixed(2);
        console.log(`Lyubo bought ${easterBreadQty} Easter bread and ${eggsQty} eggs.`);
        console.log(`He has ${left} lv. left.`);
    } else {
        const shortage = (total - budget).toFixed(2);
        console.log(`Lyubo doesn't have enough money.`);
        console.log(`He needs ${shortage} lv. more.`);
    }
}

// 05. Easter Trip
function easterTrip(input) {
    const destination = input[0];
    const dateRange = input[1];

    let price = 0;
    switch (destination) {
        case 'France':
            switch (dateRange) {
                case '21-23': price = 30; break;
                case '24-27': price = 35; break;
                case '28-31': price = 40; break;
            }
            break;
        case 'Italy':
            switch (dateRange) {
                case '21-23': price = 28; break;
                case '24-27': price = 32; break;
                case '28-31': price = 39; break;
            }
            break;
        case 'Germany':
            switch (dateRange) {
                case '21-23': price = 32; break;
                case '24-27': price = 37; break;
                case '28-31': price = 43; break;
            }
            break;
    }

    const days = Number(input[2]);
    const total = (price * days).toFixed(2);
    console.log(`Easter trip to ${destination} : ${total} leva.`)
}

// 06. Painting Eggs
function paintingEggs(input) {
    const size = input[0];
    const color = input[1];

    let price = 0;
    switch (color) {
        case 'Red':
            switch (size) {
                case 'Large': price = 16; break;
                case 'Medium': price = 13; break;
                case 'Small': price = 9; break;
            }
            break;
        case 'Green':
            switch (size) {
                case 'Large': price = 12; break;
                case 'Medium': price = 9; break;
                case 'Small': price = 8; break;
            }
            break;
        case 'Yellow':
            switch (size) {
                case 'Large': price = 9; break;
                case 'Medium': price = 7; break;
                case 'Small': price = 5; break;
            }
            break;
    }

    const qty = Number(input[2]);
    const total = price * qty;
    const tax = total * 0.35;
    const grandTotal = (total - tax).toFixed(2);

    console.log(`${grandTotal} leva.`);
}

// 07.Easter Eggs Battle
function easterEggsBattle(input) {
    let p1 = Number(input[0]);
    let p2 = Number(input[1]);

    for (let i = 2; i < input.length; i++) {
        const cmd = input[i];

        if (cmd === 'one') {
            p2--;
        } else if (cmd === 'two') {
            p1--;
        } else if (cmd === 'End') {
            console.log(`Player one has ${p1} eggs left.`);
            console.log(`Player two has ${p2} eggs left.`);
            break;
        }

        if (p1 === 0) {
            console.log(`Player one is out of eggs. Player two has ${p2} eggs left.`);
            break;
        }

        if (p2 === 0) {
            console.log(`Player two is out of eggs. Player one has ${p1} eggs left.`);
            break;
        }
    }
}

// 08. Easter Shop
function easterShop(input) {
    let eggsQty = Number(input[0]);

    let sold = 0;
    for (let i = 1; i < input.length; i += 2) {
        const cmd = input[i];

        if (cmd === 'Close') {
            console.log('Store is closed!');
            console.log(`${sold} eggs sold.`);
            break;
        }

        if (cmd === 'Buy') {
            const buyCount = Number(input[i+1]);
            if (buyCount > eggsQty) {
                console.log(`Not enough eggs in store!`);
                console.log(`You can buy only ${eggsQty}.`);
                break;
            }
            eggsQty -= buyCount;
            sold += buyCount;
        }

        if (cmd === 'Fill') {
            const fillCount = Number(input[i+1]);
            eggsQty += fillCount;
            continue;
        }
    }
}

// 09. Easter Eggs
function easterEggs(input) {
    const eggsCount = Number(input[0]);

    let red = 0, orange = 0, blue = 0, green = 0;
    for (let i = 1; i < input.length; i++) {
        const color = input[i];

        switch (color) {
            case 'red': red++; break;
            case 'orange': orange++; break;
            case 'blue': blue++; break;
            case 'green': green++; break;
        }
    }

    console.log(`Red eggs: ${red}`);
    console.log(`Orange eggs: ${orange}`);
    console.log(`Blue eggs: ${blue}`);
    console.log(`Green eggs: ${green}`);

    if (red > orange && red > blue && red > green) {
        console.log(`Max eggs: ${red} -> red`);
        return;
    }

    if (orange > red && orange > blue && orange > green) {
        console.log(`Max eggs: ${orange} -> orange`);
        return;
    }

    if (blue > red && blue > orange && blue > green) {
        console.log(`Max eggs: ${blue} -> blue`);
        return;
    }

    if (green > red && green > orange && green > blue) {
        console.log(`Max eggs: ${green} -> green`);
        return;
    }
}

// 10. Easter Bake
function easterBake(input) {
    let totalSugar = 0, totalFlour = 0, maxSugar = 0, maxFlour = 0;

    for (let i = 2; i < input.length; i += 2) {
        const sugarQty = Number(input[i-1]);
        const flourQty = Number(input[i]);

        totalSugar += sugarQty;
        totalFlour += flourQty;

        if (sugarQty > maxSugar) {
            maxSugar = sugarQty;
        }

        if (flourQty > maxFlour) {
            maxFlour = flourQty;
        }
    }

    const sugarPackSize = 950;
    const flourPackSize = 750;
    const sugarPacksNeeded = Math.ceil(totalSugar / sugarPackSize);
    const flourPacksNeeded = Math.ceil(totalFlour / flourPackSize);

    console.log(`Sugar: ${sugarPacksNeeded}`);
    console.log(`Flour: ${flourPacksNeeded}`);
    console.log(`Max used flour is ${maxFlour} grams, max used sugar is ${maxSugar} grams.`);
}

// 11. Easter Competition
function easterCompetition(input) {
    let winnerName = 'Empty', maxPts = 0;
    for (let i = 1; i < input.length; i++)  {
        const name = input[i];
        let ptsTotal = 0;

        while (true) {
            i++;

            const cmd = input[i];
            if (cmd === 'Stop') break;

            const pts = Number(cmd);
            ptsTotal += pts;
        }

        console.log(`${name} has ${ptsTotal} points.`);

        if (ptsTotal > maxPts) {
            console.log(`${name} is the new number 1!`);

            winnerName = name;
            maxPts = ptsTotal;
        }
    }

    console.log(`${winnerName} won competition with ${maxPts} points!`);
}

// 12. Easter Decoration
function easterDecoration(input) {
    const basketPrice = 1.5, wreathPrice = 3.8, bunnyPrice = 7;
    let total = 0;
    for (let i = 1; i < input.length; i++) {
        let bill = 0;
        let itemsCount = 0;

        while (true) {
            const purchase = input[i];
            if (purchase === 'Finish') break;

            switch (purchase) {
                case 'basket': bill += basketPrice; break; 
                case 'wreath': bill += wreathPrice; break; 
                case 'chocolate bunny': bill += bunnyPrice; break; 
            }

            itemsCount++;
            i++;
        }

        if (itemsCount % 2 == 0) {
            bill -= bill * 0.2;
        }

        total += bill;

        console.log(`You purchased ${itemsCount} items for ${bill.toFixed(2)} leva.`);
    }

    const clientsCount = Number(input[0]);
    const avgBill = (total / clientsCount).toFixed(2);
    console.log(`Average bill per client is: ${avgBill} leva.`);
}
