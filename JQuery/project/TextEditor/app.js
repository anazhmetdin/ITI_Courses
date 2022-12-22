// textsCount: total count of created and deleted texts
// scale: resolution scale of canvas -> muliples of canvas dimensions
var textsCount = 0, scale = 4, selectedText;

var canvas = $('canvas');
var layers = $('#layers');
var layersList = $('#layersList');
var textarea = $('#text');

var ctx = canvas.get(0).getContext("2d");

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
        activateTextAndLayer($('#'+transfromID( 't', this.id)), $(this));
    });

    // create new text element
    var newText = ( $(
        `<pre id="t${textsCount}" class="text" style="position:absolute; top:50%;
        left:50%; margin:0; font-size:30; user-select: none;
        max-width: ${layers.css('width')}; max-height:${layers.css('height')};
        overflow: hidden; white-space: break-spaces; word-wrap: break-word;
        font-family:Arial;">${newText}</pre>`) );
    
    // set the new added element as the selected text
    // activate the corresponding layer
    activateTextAndLayer(newText, textLayer);

    // add new selected text element to HTML
    layers.append(selectedText);

    // add event listner to start moving
    selectedText.mousedown(selectingText);

    // remove evenet listner
    var stopMoving = function() { $(document).off('mousemove'); };

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

// event handler to select text on mouse down
function selectingText(event) {
    // if target is not the selected text AND mouse is over the selected
    // in case of overlapping elements -> trigger moving event on the active text
    if (event.target.id != selectedText.attr('id') && selectedText.get(0).matches(":hover") ) {
        
        // create new event with current mouse position
        const e = $.Event('mousedown', {
            'clientX' : event.clientX, 
            'clientY' : event.clientY
        });
        
        // dispatch event on the selected text
        selectedText.trigger(e);
    
    } else { // event has targetted another text OR the mouse is not over the selected text

        // make sure the moving text is the activated one
        activateTextAndLayer($(event.target), $('#'+transfromID('l')));

        moveText(event);
    }
}

// event handler on mouse down to start moving
function moveText(event) {

    // get layers dimensions
    var boxXOffset = layers.offset().left;
    var boxWidth = Number.parseFloat(layers.css('width'));
    var boxYOffset = layers.offset().top;
    var boxHeight = Number.parseFloat(layers.css('height'));

    // selectedText dimensions
    var textWidth = Number.parseFloat(selectedText.css('width'))/2;
    var textHeight = Number.parseFloat(selectedText.css('height'))/2;
    
    // offset from mousedown position to selectedText center
    var centerXOffset = event.clientX - selectedText.offset().left - textWidth;
    var centerYOffset = event.clientY - selectedText.offset().top - textHeight;
    
    // offset from mouse to selectedText inside box
    var xOffset = boxXOffset + textWidth + centerXOffset;
    var yOffset = boxYOffset + textHeight + centerYOffset;

    // max and min allowed coodinates of the mouse while moving the selected text
    var maxX = boxXOffset + boxWidth + centerXOffset - textWidth;
    var minX = boxXOffset + textWidth + centerXOffset;
    
    var maxY = boxYOffset + boxHeight + centerYOffset - textHeight;
    var minY = boxYOffset + textHeight + centerYOffset;
    
    // update selectedText position when mouse moves
    $(document).mousemove(function(event) {
        
        if (maxX > event.clientX && event.clientX > minX)
        {
            selectedText.css('left', event.clientX-xOffset);
        }
        
        if (maxY > event.clientY && event.clientY > minY)
        {
            selectedText.css('top', event.clientY-yOffset);
        }

        limitTextToBox();

    })
}

// update text when textarea is updated
textarea.on('input', function() {
    
    selectedText.text($(this).val());

    limitTextToBox();

    // update layer text
    $('#'+transfromID('l')).text($(this).val());
})

// set textarea value
function setTextArea() {
    textarea.val(selectedText.text());
}

// make sure selected text doesn't pass the box
function limitTextToBox() {
    if (Number.parseFloat(selectedText.css('width')) + selectedText.offset().left > 
        layers.offset().left + Number.parseFloat(layers.css('width')))
    {
        selectedText.css('left', `calc(100% - ${selectedText.css('width')})`);
    }
    if (Number.parseFloat(selectedText.css('height')) + selectedText.offset().top > 
        layers.offset().top + Number.parseFloat(canvas.css('height')))
    {
        selectedText.css('top', `calc(100% - ${selectedText.css('height')})`);
    }
}

// extract index and add letter to transfrom ids
function transfromID(letter, id) {
    if(arguments.length == 1) {
        id = selectedText.attr('id');
    }
    return letter + id.substring(1);
}

// set text with index as the active text to be controlled
function setLayerActive(Textlayer) {
    // update textarea
    setTextArea();
    // set text in layer list as active
    highlightList(Textlayer);
}

// set text in layer list as active
function highlightList(Textlayer) {
    $('p[class=active]', layersList).removeClass('active');
    if (arguments.length == 1) {
        Textlayer.addClass('active');
    } else {
        layers.children().last().addClass('active');
    }
}

// set selected text
function setTextActive(newSelectedText) {
    if (!!selectedText) { 
        selectedText.removeClass('selected');
        selectedText.css('z-index', 0);
    }

    selectedText = newSelectedText;

    selectedText.addClass('selected');
    selectedText.css('z-index', 1);
}

// activate Text and layer
function activateTextAndLayer(text, layer) {
    setTextActive( text );
    setLayerActive( layer );
}