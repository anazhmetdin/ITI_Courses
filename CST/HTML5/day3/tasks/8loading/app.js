var canvas = document.getElementsByTagName("canvas")[0];
var ctx = canvas.getContext("2d");
var startX=400;
var startY=400;

// draw an unrotated reference rect
ctx.fillStyle="rgba(0,110,200, 0.5)";

function forward(){
    ctx.clearRect(0, 0, canvas.width, canvas.height);  

    var x = 0;
    var interval = setInterval(()=>{
        drawRotatedRect(startX,startY,200,40,x);
        x += 30
        if (x > 360){
            clearInterval(interval);
    
            reverse();
        }
    }, 100);
}

function reverse(){
    ctx.clearRect(0, 0, canvas.width, canvas.height);  

    var x = 360;
    var interval = setInterval(()=>{
        drawRotatedRect(startX,startY,200,40,x);
        x -= 30
        if (x < 0){
            clearInterval(interval);
    
            forward();
        }
    }, 100);
}

forward();


function drawRotatedRect(x,y,width,height,degrees){
    // first save the untranslated/unrotated context
    ctx.save();

    ctx.beginPath();
    // move the rotation point to the center of the rect
    ctx.translate( x+width/2, y+height/2 );
    // rotate the rect
    ctx.rotate(degrees*Math.PI/180);

    ctx.rect( -width*1.1, -height*1.1, width,height);

    ctx.fill();

    // restore the context to its untranslated/unrotated state
    ctx.restore();
}