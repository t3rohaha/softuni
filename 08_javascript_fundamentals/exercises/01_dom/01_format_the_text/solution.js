function solve() {
    const inputEl = document.querySelector('#input');

    if (inputEl.innerText == '') {
        return;
    }

    const input = inputEl.innerText;
    const sentences = input.split('.');

    const outputEl = document.querySelector('#output');
    while (true) {
        const p = document.createElement('p');
        const s = sentences.splice(0, 3);
        p.textContent = `${s.join('. ')}.`;

        if (sentences.length === 0) {
            p.textContent = p.textContent.slice(0, -1);
            outputEl.appendChild(p);
            break;
        } 

        outputEl.appendChild(p);
    }
}