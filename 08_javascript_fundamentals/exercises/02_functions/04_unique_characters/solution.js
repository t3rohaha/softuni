function solve() {
    const input = document.querySelector('#string').value;

    let result = '';
    for (let char of input) {
        if (char === ' ') {
            result += char;
            continue;
        }
        
        if (result.indexOf(char) === -1) {
            result += char;
        }
    }

    const resultNode = document.querySelector('#result');
    resultNode.textContent = result;
}