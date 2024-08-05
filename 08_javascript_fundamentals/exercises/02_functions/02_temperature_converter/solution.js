function solve() {
    const degrees = +document.querySelector('#num1').value;
    const convertFrom = document.querySelector('#type').value;
    const resultNode = document.querySelector('#result');

    let result = 0;
    switch (convertFrom.toLowerCase()) {
        case 'celsius': result = ((degrees * 9) / 5) + 32; break;
        case 'fahrenheit': result = ((degrees - 32) * 5) / 9; break;
        default:
            resultNode.innerHTML = 'Error!';
            return;
    }

    resultNode.innerHTML = Math.round(result);
}