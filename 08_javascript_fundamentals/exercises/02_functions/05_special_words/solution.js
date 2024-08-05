function solve() {
    const start = +document.querySelector('#firstNumber').value;
    const end = +document.querySelector('#secondNumber').value;
    const str1 = document.querySelector('#firstString').value;
    const str2 = document.querySelector('#secondString').value;
    const str3 = document.querySelector('#thirdString').value;

    let result = '';
    for (let i = start; i <= end; i++) {
        const cond1 = i % 3 === 0;
        const cond2 = i % 5 === 0;

        if (cond1 && cond2) {
            result += `<p>${i} ${str1}-${str2}-${str3}</p>`;
            continue;
        }

        if (cond1) {
            result += `<p>${i} ${str2}</p>`;
            continue;
        }

        if (cond2) {
            result += `<p>${i} ${str3}</p>`;
            continue;
        }

        result += `<p>${i}</p>`;
    }

    document.querySelector('#result').innerHTML = result;
}