function solve() {
    const input = document.querySelector('#num').value;
    const arrJSON = document.querySelector('#arr').value;
    const arr = JSON.parse(arrJSON);

    let result = '';
    for (let el of arr) {
        const index = el.indexOf(input);
        const exists = index !== -1;
        result += `<p>${exists} -> ${index}</p>`;
    }

    document.querySelector('#result').innerHTML = result;
}