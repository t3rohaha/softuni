function solve() {
    const arr = document.querySelector('#arr').value.split(', ');

    let result = [];
    for (let i = 0; i < arr.length; i++)
        if (i % 2 === 0) result.push(arr[i]);

    document.querySelector('#result').textContent = result.join(' x ');
}