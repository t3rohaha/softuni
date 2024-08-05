function solve() {
    const str = document.querySelector('#str').value;
    const strArgs = str.split(' ');

    let numbersOutput = '';
    let output = ''; 
    for (let x of strArgs) {
        if (isNaN(x)) {
            output += handleString(x);
        } else {
            numbersOutput += handleNumber(x);
        }
    }

    output += `<p>${numbersOutput}</p>`;
    document.querySelector('#result').innerHTML = output;

    function handleString(str) {
        const output = [];
        for (let char of str) {
            output.push(char.charCodeAt(0));
        }
        return `<p>${output.join(' ')}</p>`;
    }

    function handleNumber(str) {
        return String.fromCharCode(+str);
    }
}