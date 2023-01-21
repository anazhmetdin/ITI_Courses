function register() {
    const name = document.getElementById('name').value;
    const age = document.getElementById('age').value;
    const gender = document.querySelector('input[name="gender"]:checked').value;
    const color = document.getElementById('color').value;

    var valid = true;

    if (!!!name) {alert("Name is required"); valid = false;}
    else if (!!!age) {alert("Age is required"); valid = false;}
    else if (!!!gender) {alert("Gender is required"); valid = false;}
    else if (!!!color) {alert("Color is required"); valid = false;}
    
    if (valid) {
        setCookie('name', name);
        setCookie('age', age);
        setCookie('gender', gender);
        setCookie('color', color);
    
        window.location.assign('profile.html');
    }
}