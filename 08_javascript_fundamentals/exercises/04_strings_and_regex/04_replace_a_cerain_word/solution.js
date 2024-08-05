function solve() {
    const arrJSON = document.querySelector('#arr').value;
    const arr = JSON.parse(arrJSON);
    
    const replaceFrom = arr[1].split(' ')[0].toLowerCase();
    const replaceTo = document.querySelector('#str').value;

    let output = '';
    for (let str of arr) {
        const newStr = str.replace(new RegExp(replaceFrom, 'i'), replaceTo);
        output += `<p>${newStr}</p>`;
    }

    document.querySelector('#result').innerHTML = output;
}