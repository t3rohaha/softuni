function solve() {
    const str = document.querySelector('#str1').value;
    const strArgs = str.split(' ');
    const casing = document.querySelector('#str2').value;

    let result = '';
    switch (casing) {
        case 'Camel Case': result = convertToCamel(strArgs); break;
        case 'Pascal Case': result = convertToPascal(strArgs); break;
        default: result = 'Error!'; break;
    }

    document.querySelector('#result').innerHTML = result;

    function convertToCamel(strArgs) {
        let output = strArgs[0].toLowerCase();
        output += convertToPascal(strArgs.slice(1));
        return output;
    }

    function convertToPascal(strArgs) {
        let output = '';
        for (let i = 0; i < strArgs.length; i++) {
            let temp = strArgs[i].toLowerCase();
            temp = temp[0].toUpperCase() + temp.slice(1);
            output += temp;
        }
        return output;
    }
}
