var canvas = document.getElementsByTagName("canvas")[0];
var ctx = canvas.getContext("2d");

function clearRect(){
    ctx.clearRect(0, 0, canvas.width, canvas.height);  
}

function drawHalf(top = true) {
    
    ctx.beginPath();

        ctx.arc(200, 125, 100, 0, Math.PI, top);

        ctx.lineWidth = 2;
        ctx.fillStyle = 'black';
        ctx.stroke();

    ctx.closePath();

    ctx.fillStyle = 'yellow';
    ctx.fill();
}

var counter = 0;

function clearThenHalf(top){
    clearRect();
    drawHalf(top);

    counter++;
    if (counter == 10) {
        clearInterval(interval);
        drawHalf(true);
        drawHalf(false);
    }
}


var interval = setInterval(() => {
    clearThenHalf(true);
    setTimeout(clearThenHalf, 500, false);
}, 1000)