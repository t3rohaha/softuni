function solve() {
    const arrJSON = document.querySelector('#arr').value;
    const arr = JSON.parse(arrJSON);

    let result = [];
    for (let str of arr) {
        newStr = '';
        for (let y = str.length - 1; y >= 0; y--)
            newStr += str[y];

        newStr = newStr.toLowerCase();
        newStr = newStr[0].toUpperCase() + newStr.slice(1);
        result.push(newStr);
    }

    document.querySelector('#result').innerHTML = result.join(' ');
}