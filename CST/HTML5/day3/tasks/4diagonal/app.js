var canvas = document.getElementsByTagName("canvas")[0];
var ctx = canvas.getContext("2d");

var x = 0, y = 0;

ctx.lineWidth = 10;


var interval = setInterval(()=>{
    ctx.strokeStyle = `rgb(${x*255/canvas.width}, ${y*255/canvas.width}, 0)`;
    ctx.beginPath();
    ctx.moveTo(x,y);
    ctx.lineTo(x+5,y+5);
    ctx.stroke();
    ctx.closePath();
    x += 5;
    y += 5;

    if (x == canvas.width) {
        clearInterval(interval);
        alert('Animation End');
    }
}, 10)
