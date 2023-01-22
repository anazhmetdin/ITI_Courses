var canvas = document.getElementsByTagName("canvas")[0];
var ctx = canvas.getContext("2d");

var img = document.createElement('IMG');
img.src = './ok.jpg';

img.onload = function() {
    canvas.width = img.width;
    canvas.height = img.height;
    ctx.drawImage(img, 0, 0);
    
    ctx.fillStyle = "white";
    ctx.font = "50px Courier New";
    
    ctx.shadowOffsetX = 3;
    ctx.shadowOffsetY = 3;

    ctx.shadowColor = "rgba(255,255,255,0.5)";

    ctx.shadowBlur = 2;
    ctx.fillText("Don't worry king", 50, 390);

    ctx.strokeStyle = "rgba(255,255,255,0.2)";
    ctx.lineWidth = 0.5;
    ctx.strokeText("    Br  en", 50, 450);

    ctx.fillText("I'm   ok ", 50, 450);
}

