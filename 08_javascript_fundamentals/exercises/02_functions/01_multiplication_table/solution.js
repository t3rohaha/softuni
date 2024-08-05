function solve() {
    const num1 = +document.querySelector('#num1').value;
    const num2 = +document.querySelector('#num2').value;
    const resultNode = document.querySelector('#result');
    
    if (num1 > num2) {
        invalidInput();
    } else {
        multiplicationTable();
    }

    function invalidInput() {
        resultNode.innerHTML = 'Try with other numbers.';
    }

    function multiplicationTable() {
        let output = '';
        for (let i = num1; i < 10; i++) {
            const result = i * num2;
            output += `<p>${i} * ${num2} = ${result}</p>`;
        }
        resultNode.innerHTML = output;
    }
}