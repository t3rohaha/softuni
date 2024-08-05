function solve() {
	const titleEl = document.querySelector('#createTitle');
	const contentEl = document.querySelector('#createContent');

	if (titleEl.value !== '' && contentEl.value !== '') {
		const newArticle =
			`<article>` +
				`<h3>${titleEl.value}</h3>` +
				`<p>${contentEl.value}</p>` +
			`</article>`;

		insertArticle(newArticle);

		titleEl.value = '';
		contentEl.value = '';
	}

	function insertArticle(newArticle) {
		const articlesEl = document.querySelector('#articles');
		articlesEl.insertAdjacentHTML('beforeend', newArticle);
	}
}