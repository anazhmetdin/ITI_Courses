// textsCount: total count of created and deleted texts
// scale: resolution scale of canvas -> muliples of canvas dimensions
var textsCount = 0, scale = 4, selectedText;

var canvas = $('canvas').get(0);
var layers = $('#layers');
var layersList = $('#layersList');
var textarea = $('#text');

var ctx = canvas.getContext("2d");

// set resolution
canvas.width *= scale;
canvas.height *= scale;

// create new text object when button is clicked
$('#new').click(function() {
    textsCount++;

    // layer name
    var newText = `text ${textsCount}`;

    // create list element
    var textLayer = $(`<p id="l${textsCount}">${newText}</p>`);

    // push name to layers list element
    layersList.append(textLayer);

    // make list item selects corresponding text
    textLayer.on('click', function(){
        selectedText = $('#'+transfromID(this.id, 't'));
        setTextActive($(this));
    });

    // append text element
    selectedText = $(
`<pre id="t${textsCount}" style="position:absolute; top:50%;
left:50%; margin:0; font-size:30; user-select: none;
font-family:Arial;">${newText}</pre>`);

    layers.append(selectedText);

    // set the new added element as the selected text
    setTextActive(textLayer);

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
    // $(document).mouseleave(stopMoving); // not working as expected

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
    selectedText = text;
    setTextArea();

    highlightList($('#'+transfromID(event.target.id, 'l')));

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

// update text when textarea is updated
textarea.on('input', function() {
    selectedText.text($(this).val());
})

// set textarea value
function setTextArea() {
    textarea.val(selectedText.text());
}

// extract index and add letter to transfrom ids
function transfromID(id, letter) {
    return letter + id.substring(1);
}

// set text with index as the active text to be controlled
function setTextActive(Textlayer) {
    // update textarea
    setTextArea();
    // set text in layer list as active
    highlightList(Textlayer);
}

// set text in layer list as active
function highlightList(Textlayer) {
    layersList.children().removeClass('active');
    if (arguments.length == 1) {
        Textlayer.addClass('active');
    } else {
        layers.children().last().addClass('active');
    }
}