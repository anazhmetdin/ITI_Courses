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
left:50%; margin:0; font-size:30;
font-family:Arial;">Hello World!</pre>`;

    selectedText = $(layers.children[textIndex+1]);


    //ctx.font = `${newText.fontSize}px ${newText.fontFamily}`;
    //ctx.fillText(newText.value, newText.x, newText.y);
})