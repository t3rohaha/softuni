function solve() {
    const arrJSON = document.querySelector('#arr').value;
    const arr = JSON.parse(arrJSON);

    let result = '';
    for (let str of arr)
        result += handleString(str);

    document.querySelector('#result').innerHTML = result;

    function handleString(str) {
        const invalidData = '<p>Invalid data</p><p>- - -</p>';
        let output = '';

        const namePattern = /^[A-Z]{1}[a-z]* [A-Z]{1}[a-z]*/;
        const nameMatch = str.match(namePattern);
        if (nameMatch === null) return invalidData;
        else output += `<p>${nameMatch[0]}</p>`;

        const phonePattern = /( \+359 [0-9]{1} [0-9]{3} [0-9]{3})|( \+359-[0-9]{1}-[0-9]{3}-[0-9]{3})/;
        const phoneMatch = str.match(phonePattern);
        if (phoneMatch === null) return invalidData;
        else output += `<p>${phoneMatch[0]}</p>`;

        const emailPattern = / [a-z0-9]+@[a-z]+\.[a-z]{2,3}/;
        const emailMatch = str.match(emailPattern);
        if (emailMatch === null) return invalidData;
        else output += `<p>${emailMatch[0]}</p>`;

        output += `<p>- - -</p>`;

        return output;
    }
}