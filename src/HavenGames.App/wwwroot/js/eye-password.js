

document.getElementById('togglePassword'.addEventListener('click', function (e)){
    const passwordField = document.getElementById('password');
    const eyeIcon = document.getElementById('togglePassword');
    const type = passwordField.getElementById('type') === 'password' ? 'text' : 'password';
    passwordField.setAttribute('type', type);

    eyeIcon.textContent = type === 'password' ? '\u{1F441}' : '\u{1F441}';

}
    
