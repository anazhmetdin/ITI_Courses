var canvas = document.getElementsByTagName("canvas")[0];
var ctx = canvas.getContext("2d");

ctx.beginPath();
ctx.fillStyle = "red";

ctx.moveTo(250,50);
ctx.lineTo(250,300);
ctx.lineTo(100,300);
ctx.fill();

ctx.closePath();

ctx.fillStyle = "black";
ctx.font = "20px Arial";

ctx.fillText("a" , 180, 320);
ctx.fillText("b" , 260, 200);
ctx.fillText("c" , 140, 200);