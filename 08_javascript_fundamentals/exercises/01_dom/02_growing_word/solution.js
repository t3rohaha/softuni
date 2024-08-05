function solve() {
    let clicksCount = 0;
    const btn = document.querySelector('button');
    btn.addEventListener('click', btnClicked);

    function btnClicked() {
        const p = document.querySelector('#exercise p');

        clicksCount++;
        p.style.fontSize = `${clicksCount * 2}px`;

        if (clicksCount % 3 === 1) {
            p.style.color = 'blue'; 
        } else if (clicksCount % 3 === 2) {
            p.style.color = 'green'; 
        } else if (clicksCount % 3 === 0) {
            p.style.color = 'red'; 
        }
    }
}