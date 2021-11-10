function hideShowPassword(){
    var password = document.querySelector('#password');
    var eye = document.querySelector('#hideShowPassword');
    passwordType = password.getAttribute('type')

    if(passwordType == 'password') {
        password.setAttribute('type', 'text');
        eye.setAttribute('class', 'fas fa-eye');
    } else {
        password.setAttribute('type', 'password');
        eye.setAttribute('class', 'fas fa-eye-slash');
    }
}
function getSession(){
    return;
}
