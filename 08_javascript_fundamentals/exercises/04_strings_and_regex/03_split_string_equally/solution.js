function solve() {
    const str = document.querySelector('#str').value;
    const num = +document.querySelector('#num').value;

    const output = [];
    for (let i = 0; i < str.length; i += num)
        output.push(str.slice(i, i+num));

    let last = output[output.length - 1];
    while (last.length !== num)
        last += str.slice(0, num - last.length);
    output[output.length - 1] = last;

    document.querySelector('#result').innerHTML = output.join(' ');
}