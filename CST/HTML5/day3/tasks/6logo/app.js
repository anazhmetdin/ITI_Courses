var canvas = document.getElementsByTagName("canvas")[0];
var ctx = canvas.getContext("2d");
var dim = canvas.height;

// bigger circle
ctx.beginPath();

    ctx.arc(dim/2, dim/2, dim/2, 0, 2 * Math.PI, true);

ctx.closePath();

var grd = ctx.createRadialGradient(dim*0.55, dim*0.4, dim*0.3, dim*0.6, dim*0.25, dim*0.7);
grd.addColorStop(0, "LightCoral");
grd.addColorStop(1, "DarkRed");

ctx.fillStyle = grd;
ctx.fill();


// smaller circle
ctx.beginPath();

    ctx.arc(dim/2, dim/2, dim*0.38, 0, 2 * Math.PI, true);

ctx.closePath();

var grd = ctx.createRadialGradient(dim*0.75, dim*0.65, dim*0.05, dim*0.5, dim*0.5, dim*0.7);
grd.addColorStop(0, "LightCoral");
grd.addColorStop(1, "DarkRed");

ctx.fillStyle = grd;
ctx.fill();

// N
ctx.fillStyle = "white";
ctx.font = "380px Arial";

ctx.fillText("N" , dim/4.3, dim*0.78);