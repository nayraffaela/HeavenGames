<script>
    document.addEventListener('DOMContentLoaded', function() {
        const hamburger = document.getElementById('hamburger');
    const magicMenu = document.querySelector('.magic-menu'); // Use querySelector para selecionar pela classe

    if (hamburger && magicMenu) { // Verifica se os elementos existem
        hamburger.addEventListener('click', function () {
            magicMenu.classList.toggle('active');
        });
        }
    });
</script>

