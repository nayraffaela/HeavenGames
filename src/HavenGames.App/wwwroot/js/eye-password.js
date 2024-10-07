document.getElementById('togglePassword').addEventListener('click', function () {
    var passwordInput = document.getElementById('password');
    var eyeIcon = document.getElementById('eyeIcon');

    if (passwordInput.type === 'password') {
        passwordInput.type = 'text';
        eyeIcon.src = '/imgs/eye.png'; // Caminho para o ícone de olho aberto
    } else {
        passwordInput.type = 'password';
        eyeIcon.src = '/imgs/eyeclose.png'; // Caminho para o ícone de olho fechado
    }
});