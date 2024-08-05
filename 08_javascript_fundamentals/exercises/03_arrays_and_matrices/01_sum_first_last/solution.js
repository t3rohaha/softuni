function solve() {
    const arrJSON = document.querySelector('#arr').value;
    const arr = JSON.parse(arrJSON);
    const length = arr.length;

    let result = '';
    for (let i = 0; i < length; i++) {
        const num = +arr[i];
        const product = num * length;
        result += `<p>${i} -> ${product}</p>`;
    }

    document.querySelector('#result').innerHTML = result;
}