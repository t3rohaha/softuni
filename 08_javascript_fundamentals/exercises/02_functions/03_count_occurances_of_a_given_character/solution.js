function solve() {
    const str = document.querySelector('#string').value;
    const char = document.querySelector('#character').value;
    const resultNode = document.querySelector('#result');

    let count = 0;
    for (let c of str) {
        if (c === char) {
            count++;
        }
    }

    let result = '';
    if (count % 2 === 0) {
        result = `Count of ${char} is even.`;
    } else {
        result = `Count of ${char} is odd.`;
    }

    resultNode.innerHTML = result;
}