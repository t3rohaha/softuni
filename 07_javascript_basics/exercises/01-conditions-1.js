// 01: Sum Seconds
function sumSeconds(input) {
    const time1 = Number(input[0]);
    const time2 = Number(input[1]);
    const time3 = Number(input[2]);
    const sum = time1 + time2 + time3;

    const mins = Math.floor(sum / 60);
    const secs = sum % 60;

    if (secs < 10) {
        console.log(`${mins}:0${secs}`);
    } else {
        console.log(`${mins}:${secs}`);
    }
}

// 02: Bonus Score
function bonusScore(input) {
    const score = Number(input[0]);
    let bonus = 0;

    if (score <= 100) {
        bonus = 5;
    } else if (score <= 1000) {
        bonus = score * 0.2;
    } else {
        bonus = score * 0.1;
    }

    if (score % 2 === 0) {
        bonus += 1;
    } else if (score % 10 === 5) {
        bonus += 2;
    }

    console.log(bonus);
    console.log(score + bonus);
}

// 03: Time + 15 Minutes
function timePlus15Mins(input) {
    let hour = Number(input[0]);
    let mins = Number(input[1]);

    mins += 15;

    if (mins >= 60) {
        hour++;
        mins -= 60;
    }

    if (hour >= 24) {
        hour -= 24;
    }

    console.log(`${hour}:${mins.toString().padStart(2, '0')}`);
}

// 04: Toy Shop
function toyShop(input) {
    const puzzlePrice = 2.6;
    const dollPrice = 3;
    const bearPrice = 4.1;
    const minionPrice = 8.2;
    const truckPrice = 2;

    const goal = Number(input[0]);
    const puzzleCount = Number(input[1]);
    const dollCount = Number(input[2]);
    const bearCount = Number(input[3]);
    const minionCount = Number(input[4]);
    const truckCount = Number(input[5]);

    let profit = (puzzlePrice * puzzleCount) +
                 (dollPrice * dollCount) +
                 (bearPrice * bearCount) +
                 (minionPrice * minionCount) +
                 (truckPrice * truckCount);

    const totalCount = puzzleCount + dollCount + bearCount + minionCount +
                       truckCount;

    if (totalCount >= 50) {
        profit -= profit * 0.25;
    }

    profit -= profit * 0.1;

    const absDiff = Math.abs(profit - goal).toFixed(2);

    if (profit >= goal) {
        console.log(`Yes! ${absDiff} lv left.`);
    } else {
        console.log(`Not enough money! ${absDiff} lv needed.`);
    }
}

// 05: Godzilla vs. Kong
function godzillaVsKong(input) {
    const budget = Number(input[0]);
    const extra = Number(input[1]);
    const clothingPricePerExtra = Number(input[2]);
    
    const decorationTotal = budget * 0.1;
    let clothingTotal = extra * clothingPricePerExtra;

    if (extra > 150) {
        clothingTotal -= clothingTotal * 0.1;
    }

    const total = decorationTotal + clothingTotal;
    const absDiff = Math.abs(total - budget).toFixed(2);

    if (total > budget) {
        console.log('Not enough money!');
        console.log(`Wingard needs ${absDiff} leva more.`)
    } else {
        console.log('Action!');
        console.log(`Wingard starts filming with ${absDiff} leva left.`);
    }
}

// 06: World Swimming Record
function worldSwimmingRecord(input) {
    const wr = Number(input[0]);
    const dist = Number(input[1]);
    const pace = Number(input[2]);
    const delay = Math.floor(dist / 15) * 12.5;
    const time = dist * pace + delay;

    if (time < wr) {
        console.log(`Yes, he succeeded! The new world record is ${time.toFixed(2)} seconds.`);
    } else {
        const diff = time - wr;
        console.log(`No, he failed! He was ${diff.toFixed(2)} seconds slower.`);
    }
}

// 07: Shopping
function shopping(input) {
    const gpuPrice = 250;
    const gpuCount = Number(input[1]);
    const gpuTotal = gpuPrice * gpuCount;

    const cpuPrice = gpuTotal * 0.35;
    const cpuCount = Number(input[2]);
    const cpuTotal = cpuPrice * cpuCount;

    const ramPrice = gpuTotal * 0.1;
    const ramCount = Number(input[3]);
    const ramTotal = ramPrice * ramCount;

    const budget = Number(input[0]);
    let total = gpuTotal + cpuTotal + ramTotal;

    if (gpuCount > cpuCount) {
        total -= total * 0.15;
    }

    const diff = Math.abs(total - budget).toFixed(2);

    if (budget >= total) {
        console.log(`You have ${diff} leva left!`);
    } else {
        console.log(`Not enough money! You need ${diff} leva more!`);
    }
}

// 08: Lunch Break
function lunchBreak(input) {
    const breakDuration = Number(input[2]);
    const seriesTitle = input[0];

    const lunch = breakDuration / 8;
    const rest = breakDuration / 4;
    const series = Number(input[1]);
    const total = lunch + rest + series;

    const timeDiff = Math.ceil(Math.abs(breakDuration - total));
    
    if (total <= breakDuration) {
        console.log(`You have enough time to watch ${seriesTitle} and left with ${timeDiff} minutes free time.`);
    } else {
        console.log(`You don't have enough time to watch ${seriesTitle}, you need ${timeDiff} more minutes.`);
    }
}