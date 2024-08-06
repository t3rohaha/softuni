(function solve() {
    const obj = {};

    const buttons = document.querySelectorAll('.button');
    buttons[0].addEventListener('click', addProperty);
    buttons[1].addEventListener('click', getProperty);
    buttons[2].addEventListener('click', getObject);

    function addProperty(event) {
        event.preventDefault();

        const key = document.querySelector('#key').value;
        const value = document.querySelector('#value').value;

        obj[key] = value;

        displayResult('New property added!');
    }

    function getProperty(event) {
        event.preventDefault();

        const key = document.querySelector('#key').value;

        displayResult(obj[key]);
    }

    function getObject(event) {
        event.preventDefault();

        displayResult(JSON.stringify(obj));
    }

    function displayResult(result) {
        document.querySelector('#result').value = result;
    }
})();