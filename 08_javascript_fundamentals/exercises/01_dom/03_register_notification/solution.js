 function register() {
    let username = document.querySelector('#username');
    let email = document.querySelector('#email');
    let password = document.querySelector('#password');

    if (!validateForm()) return;

    showNotification();

    function showNotification() {
        const notification =
            `<h1>Successful Registration!</h1>` +
            `Username: ${username.value}` +
            `Email: ${email.value}` +
            `Password: ${'*'.repeat(password.value.length)}`;

        const resultEl = document.querySelector('#result');
        const textNode = document.createTextNode(notification);

        resultEl.appendChild(textNode);

        setTimeout(() => {
            resultEl.innerHTML = '';
        }, 5000);
    }

    function validateForm() {
        if (username.value === '') {
            console.error('Invalid username!');
            return false;
        }

        if (!(/(.+)@(.+).(com|bg)/gm).test(email.value)) {
            console.error('Invalid email!');
            return false;
        }

        if (password.value === '') {
            console.error('Invalid password!');
            return false;
        }

        return true;
    }
 }
