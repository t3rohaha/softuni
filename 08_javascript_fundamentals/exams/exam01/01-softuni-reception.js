// Three employees are working in the reception all day. Each of them can handle
// a different number of students per hour. Your task is to calculate how much
// time it will take to answer all the questions of a given number of students.
function solve(args) {
    const tempo = +args[0] + +args[1] + +args[2];
    let count = +args[3];

    let hours = 0;
    while (count > 0) {
        hours++
        if (hours % 4 === 0) continue;
        count -= tempo;
    }

    console.log(`Time needed: ${hours}h.`)
}
