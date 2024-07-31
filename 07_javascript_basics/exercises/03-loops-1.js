// 01: Numbers ending in 7
function numbersEndingIn7() {
    for (let i = 7; i < 1000; i += 10) {
        console.log(i);
    }
}

// 02: Multiplication table
function multiplicationTable(input) {
    const multiplier = Number(input[0]);
    for (let i = 1; i <= 10; i++) {
        const result = i * multiplier;
        console.log(`${i} * ${multiplier} = ${result}`);
    }
}

// 03: Histogram
function histogram(input) {
    const count = Number(input[0]);
    let p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0;

    for (let i = 1; i <= count; i++) {
        const num = Number(input[i]);

        if (num < 200) {
            p1++;
        } else if (num <= 399) {
            p2++;
        } else if (num <= 599) {
            p3++;
        } else if (num <= 799) {
            p4++;
        } else {
            p5++;
        }
    }

    console.log(`${((p1 / count) * 100).toFixed(2)}%`);
    console.log(`${((p2 / count) * 100).toFixed(2)}%`);
    console.log(`${((p3 / count) * 100).toFixed(2)}%`);
    console.log(`${((p4 / count) * 100).toFixed(2)}%`);
    console.log(`${((p5 / count) * 100).toFixed(2)}%`);
}

// 04: Clever Lily
function cleverLily(input) {
    const age = Number(input[0]);
    let moneyGift = 10;
    let toys = 0;
    let total = 0;

    for (let i = 1; i <= age; i++) {
        if (i % 2 == 0) {
            total += moneyGift;
            moneyGift += 10;
            total--;
        } else {
            toys++;
        }
    }

    const toyPrice = Number(input[2]);
    total += toys * toyPrice;

    const washingMachinePrice = Number(input[1]);
    if (washingMachinePrice <= total) {
        console.log(`Yes! ${(total - washingMachinePrice).toFixed(2)}`);
    } else {
        console.log(`No! ${(washingMachinePrice - total).toFixed(2)}`);
    }
}

// 05: Salary
function salary(input) {
    const tabsOpen = Number(input[0]);
    let salary = Number(input[1]);

    for (let i = 2; i < input.length; i++) {
        const tab = input[i];
        switch (tab) {
            case 'Facebook': salary -= 150; break;
            case 'Instagram': salary -= 100; break;
            case 'Reddit': salary -= 50; break;
        }

        if (salary <= 0) {
            console.log('You have lost your salary.');
            break;
        }
    }

    if (salary > 0) {
        console.log(salary);
    }
}

// 06: Oscars
function oscars(input) {
    const actorName = input[0];
    let actorScore = Number(input[1]);
    const useless = input[2];
    const count = input.length;

    for (let i = 4; i < count; i+=2) {
        const judgeName = input[i - 1];
        const judgeScore = Number(input[i]);
        const totalJudgeScore = judgeName.length * judgeScore / 2;

        actorScore += totalJudgeScore;

        if (actorScore > 1250.5) {
            break;
        }
    }

    if (actorScore > 1250.5) {
        console.log(`Congratulations, ${actorName} got a nominee for leading role with ${actorScore.toFixed(1)}!`);
    } else {
        const shortage = 1250.5 - actorScore;
        console.log(`Sorry, ${actorName} you need ${shortage.toFixed(1)} more!`);
    }
}

// 07: Trekking Mania
function trekkingMania(input) {
    const groupsCount = Number(input[0]);

    let total = 0;
    let g1 = 0, g2 = 0, g3 = 0, g4 = 0, g5 = 0;

    for (let i = 1; i <= groupsCount; i++) {
        const groupSize = Number(input[i]);
        if (groupSize < 6) {
            g1 += groupSize;
        } else if (groupSize < 13) {
            g2 += groupSize;
        } else if (groupSize < 26) {
            g3 += groupSize;
        } else if (groupSize < 41) {
            g4 += groupSize;
        } else {
            g5 += groupSize;
        }
        total += groupSize;
    }

    console.log(`${((g1 / total) * 100).toFixed(2)}%`)
    console.log(`${((g2 / total) * 100).toFixed(2)}%`)
    console.log(`${((g3 / total) * 100).toFixed(2)}%`)
    console.log(`${((g4 / total) * 100).toFixed(2)}%`)
    console.log(`${((g5 / total) * 100).toFixed(2)}%`)
}