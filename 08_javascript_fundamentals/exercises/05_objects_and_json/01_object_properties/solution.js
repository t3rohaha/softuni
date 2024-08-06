function solve() {
    const obj = {};

    document.querySelector('#button').addEventListener('click', addProperty);

    function addProperty(event) {
        event.preventDefault();

        const key = document.querySelector('#key').value;
        const value = document.querySelector('#value').value;

        if (key !== '' && value !== '') {
            obj[key] = value;
            document.querySelector('#result').value = JSON.stringify(obj);
        }
    }
}