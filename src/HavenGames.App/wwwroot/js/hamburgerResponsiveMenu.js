document.addEventListener('DOMContentLoaded', function () {
    const hamburger = document.getElementById('hamburger');
    const magicMenu = document.getElementById('magicMenu');

    hamburger.addEventListener('click', function () {
        magicMenu.classList.toggle('active');
    });
});
