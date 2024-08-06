(function solve() {
    document.querySelector('#button').addEventListener('click', extractInfo);

    function extractInfo(event) {
        event.preventDefault();

        const inputJSON = document.querySelector('#input').value;
        const command = document.querySelector('#command').value;

        const obj = JSON.parse(inputJSON);
        const commandArgs = command.split(' ');
        const commandType = commandArgs[0];
        const commandKey = commandArgs[commandArgs.length - 1]; 
        const value = obj[commandKey];

        if (value === undefined) {
            document.querySelector('#result').value = 'No such item.';
            return;
        }

        let output = '';
        switch(commandType) {
            case 'typeof':
                output = typeof value;
                break;
            case 'value':
                output = value;
                break;
        }

        document.querySelector('#result').value = output;
    }
})();