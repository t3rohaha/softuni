function solve() {
    const linkElements = document.querySelectorAll('#exercise a');

    for (let el of linkElements) {
        el.addEventListener('click', visitSite);
    }

    function visitSite(event) {
        const linkEl = event.target;
        const span = linkEl.nextElementSibling;
        let visitedCounter = +span.textContent.split(' ')[1];
        visitedCounter++;
        span.innerHTML = `Visited: ${visitedCounter} times`;
    }
}