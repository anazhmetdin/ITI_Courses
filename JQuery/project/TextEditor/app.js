// texts: array of layers names
// textIndex: indext of selected text
// scale: resolution scale of canvas -> muliples of canvas dimensions
var texts = [], textIndex, textsCount = 0, scale = 4, selectedText;

var canvas = $('canvas').get(0);
var layers = $('#layers');

var ctx = canvas.getContext("2d");

// set resolution
canvas.width *= scale;
canvas.height *= scale;

// create new text object when button is clicked
$('#new').click(function() {
    textIndex = textsCount;
    textsCount++;

    // layer name
    var newText = `untitled ${textsCount}`;

    // push name to layers array
    texts.push(newText);

    // append text element
    layers.append('beforeend',  
`<pre style="position:absolute; top:50%;
left:50%; margin:0; font-size:30; user-select: none;
font-family:Arial;">Hello World!</pre>`);

    // get the new added element
    selectedText = layers.index(textIndex+1);

    // add event listner to start moving
    selectedText.mousedown(function(event) {
        moveText(event);
    });

    // remove evenet listner
    var stopMoving = function() {
        $(document).off('mousemove');
    };

    // stop moving when mouse is up or has left the document
    $(document).mouseup(stopMoving);
    $(document).mouseleave(stopMoving);

    // add text to canvas
    // https://www.w3schools.com/tags/canvas_font.asp
    //ctx.font = `${newText.fontSize}px ${newText.fontFamily}`;
    //ctx.fillStyle = "red";
    //ctx.textAlign = "center";
    //ctx.fillText(newText.value, newText.x, newText.y);
})

// event handler on mouse down to start moving
function moveText(event) {

    var text = $(event.target);
    var layers = $(layers);

    // get layers dimensions
    var boxXOffset = layers.offset().left;
    var boxWidth = Number.parseFloat(layers.css('width'));
    var boxYOffset = layers.offset().top;
    var boxHeight = Number.parseFloat(layers.css('height'));

    // text dimensions
    var textWidth = Number.parseFloat(text.css('width'))/2;
    var textHeight = Number.parseFloat(text.css('height'))/2;
    
    // offset from mousedown position to text center
    var centerXOffset = event.clientX - text.offset().left - textWidth;
    var centerYOffset = event.clientY - text.offset().top - textHeight;
    
    // offset from mouse to text inside box
    var xOffset = boxXOffset + textWidth + centerXOffset;
    var yOffset = boxYOffset + textHeight + centerYOffset;

    // max and min coodinates 
    var maxX = boxXOffset + boxWidth + centerXOffset - textWidth;
    var minX = boxXOffset + textWidth + centerXOffset;
    
    var maxY = boxYOffset + boxHeight + centerYOffset - textHeight;
    var minY = boxYOffset + textHeight + centerYOffset;
    
    // update text position when mouse moves
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