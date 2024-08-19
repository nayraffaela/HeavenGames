document.addEventListener("DOMContentLoaded", function () {
    const themeToggleButton = document.getElementById('theme-toggle');
    const moonIcon = document.getElementById('moon-icon');
    const sunIcon = document.getElementById('sun-icon');
    const body = document.body;

    if (localStorage.getItem('dark-mode') === 'enabled') {
        body.classList.add('dark-mode');
        sunIcon.classList.remove('d-none');
        moonIcon.classList.add('d-none');
    }

    themeToggleButton.addEventListener('click', () => {
        if (body.classList.contains('dark-mode')) {
            body.classList.remove('dark-mode');
            sunIcon.classList.add('d-none');
            moonIcon.classList.remove('d-none');
            localStorage.setItem('dark-mode', 'disabled');
        } else {
            body.classList.add('dark-mode');
            sunIcon.classList.remove('d-none');
            moonIcon.classList.add('d-none');
            localStorage.setItem('dark-mode', 'enabled');
        }
    });
});
