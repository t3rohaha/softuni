// You are given an array with integers. Write a program to modify the elements
// after receiving commands.
function solve(args) {
    let array = args[0].split(' ').map(n => +n);

    for (var i = 1; i < args.length; i++) {
        const cmdArgs = args[i].split(' ');
        const cmd = cmdArgs[0];
        
        if (cmd === 'end') {
            break;
        }
        else if (cmd == 'swap') {
            const idx1 = +cmdArgs[1];
            const idx2 = +cmdArgs[2];
            const temp = array[idx1];
            array[idx1] = array[idx2];
            array[idx2] = temp;
        } else if (cmd == 'multiply') {
            const idx1 = +cmdArgs[1];
            const idx2 = +cmdArgs[2];
            array[idx1] = array[idx1] * array[idx2];
        } else if (cmd == 'decrease') {
            array = array.map(n => n - 1);
        } else {
            console.log('Invalid command!');
        }
    }

    console.log(array.join(', '));
}
