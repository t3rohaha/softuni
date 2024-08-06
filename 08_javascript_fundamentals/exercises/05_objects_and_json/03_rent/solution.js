(function solve() {
    document.querySelector('#button').addEventListener('click', calculateRent);

    function calculateRent(event) {
        event.preventDefault();

        const flats = document.querySelector('#flats').value.split(', ');
        const families = document.querySelector('#families').value.split(', ');
        const rents = document.querySelector('#rents').value.split(', ');
        const len = flats.length;

        let total = 0;
        let output = '';
        for (let i = 0; i < len; i++) {
            output += `In flat ${flats[i]} family ${families[i]} has to pay ${rents[i]}\n`;
            total += +rents[i];
        }

        output += `Total rent paid: ${total.toFixed(2)}`;

        document.querySelector('#result').value = output;
    }
})();