const text  = document.getElementById('text');
const red   = document.getElementById('red');
const green = document.getElementById('green');
const blue  = document.getElementById('blue');

updatecolor();

function updatecolor () {
    text.style.color = `rgb(${red.value}, ${green.value}, ${blue.value})`;
}

Array.prototype.map.call(document.getElementsByClassName('color'), (element) => {
    element.oninput = () => {
        updatecolor();
    }
});