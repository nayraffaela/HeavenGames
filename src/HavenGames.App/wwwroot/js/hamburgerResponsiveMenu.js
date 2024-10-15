<script>
    document.addEventListener('DOMContentLoaded', function() {
        const hamburger = document.getElementById('hamburger');
    const magicMenu = document.querySelector('.magic-menu'); 

    if (hamburger && magicMenu) { 
        hamburger.addEventListener('click', function () {
            magicMenu.classList.toggle('active');
        });
        }
    });
</script>

