function solve() {
    const arrJSON = document.querySelector('#arr').value;
    const arr = JSON.parse(arrJSON);

    ascending = Array.from(arr).sort((a, b) => a - b);
    alphabetically = Array.from(arr).sort();

    let result = '';
    result += `<p>${ascending.join(', ')}</p>`;
    result += `<p>${alphabetically.join(', ')}</p>`;

    document.querySelector('#result').innerHTML = result;
}