var canvas = document.getElementsByTagName("canvas")[0];
var ctx = canvas.getContext("2d");

function playground() {
    var grd = ctx.createLinearGradient(0, 0, 0, canvas.height/2);
    grd.addColorStop(0, "DeepSkyBlue");
    grd.addColorStop(1, "white");
    
    ctx.fillStyle = grd;
    ctx.fillRect(0, 0, canvas.width, canvas.height/2); 
    
    grd = ctx.createLinearGradient(0, canvas.height/2, 0, canvas.height);
    grd.addColorStop(0, "Green");
    grd.addColorStop(1, "MediumSeaGreen");
    
    ctx.fillStyle = grd;
    ctx.fillRect(0, canvas.height/2, canvas.width, canvas.height);

    grd = ctx.createLinearGradient(0, canvas.height/4, 0, 7*canvas.height/12);
    grd.addColorStop(0, "black");
    grd.addColorStop(0.7, "black");
    grd.addColorStop(0.9, "transparent");
    
    ctx.strokeStyle = grd;
    ctx.lineWidth = 4;
    ctx.strokeRect(canvas.width/4, canvas.height/4, canvas.width/2, canvas.height/3);
    ctx.lineWidth = 0;
}

var x = canvas.width/2;
var y = canvas.height/2 + 100;
var size = 55;

function ball(x, y, size) {
    ctx.beginPath();

        ctx.arc(x, y, size, 0, 2 * Math.PI, top);

    ctx.closePath();
    
    var grd = ctx.createRadialGradient(x-size/3, y-size/2, size/3, x, y, size*2);
    grd.addColorStop(0, "LightCoral");
    grd.addColorStop(1, "DarkRed");

    ctx.fillStyle = grd;
    ctx.fill();
}


var counter = 0;
var framesCount = 150
var xDirection;
var yDirection;

setInterval(() => {
    if (counter == 0) {
        xDirection = Math.random() * 2 - 1;
        yDirection = Math.random() * (0.7) + 0.7;
    }

    playground();
    ball(x+counter*xDirection, y-counter*yDirection, size-counter/4);
    counter = (counter + 2)%framesCount;
});