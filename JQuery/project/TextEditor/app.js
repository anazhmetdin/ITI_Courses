var texts = [], textIndex, textsCount = 0, scale = 4, selectedText;

var canvas = $('canvas').get(0);
var layers = $('#layers').get(0);

var ctx = canvas.getContext("2d");

canvas.width *= scale;
canvas.height *= scale;

$('#new').click(function() {
    textIndex = textsCount;
    textsCount++;

    var newText = `untitled ${textsCount}`;

    texts.push(newText);

    layers.innerHTML += `
<pre style="position:absolute; top:50%;
left:50%; margin:0; font-size:30; user-select: none;
font-family:Arial;">Hello World!</pre>`;

    selectedText = $(layers.children[textIndex+1]);

    selectedText.mousedown(function(event) {
        moveText(event);
    });

    var stopMoving = function() {
        $(document).off('mousemove');
    };

    $(document).mouseup(stopMoving);
    $(document).mouseleave(stopMoving);

    //ctx.font = `${newText.fontSize}px ${newText.fontFamily}`;
    //ctx.fillText(newText.value, newText.x, newText.y);
})


function moveText(event) {

    var text = $(event.target);
    var box = $(layers);

    var boxXOffset = box.offset().left;
    var boxWidth = Number.parseFloat(box.css('width'));
    var boxYOffset = box.offset().top;
    var boxHeight = Number.parseFloat(box.css('height'));

    var textWidth = Number.parseFloat(text.css('width'))/2;
    var textHeight = Number.parseFloat(text.css('height'))/2;
    
    var centerXOffset = event.clientX - text.offset().left - textWidth;
    var centerYOffset = event.clientY - text.offset().top - textHeight;
    
    var maxX = boxXOffset + boxWidth + centerXOffset - textWidth;
    var minX = boxXOffset + textWidth + centerXOffset;
    
    var maxY = boxYOffset + boxHeight + centerYOffset - textHeight;
    var minY = boxYOffset + textHeight + centerYOffset;
    
    var xOffset = boxXOffset + textWidth + centerXOffset;
    var yOffset = boxYOffset + textHeight + centerYOffset;

    $(document).mousemove(function(event) {
        
        if (maxX > event.clientX && event.clientX > minX)
        {
            text.css('left', event.clientX-xOffset);
        }
        
        if (maxY > event.clientY && event.clientY > minY)
        {
            text.css('top', event.clientY-yOffset);
        }
    })
}