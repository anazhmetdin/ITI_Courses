var displayed, imgIndex = 1;

(function() {$('.section, #serviceItems').hide();}());

$('.navButtons').click(function() {
    hideDisplay(this.id.substring(3).toLowerCase(), 'show');
});

$('.arrow').click(function() {
    if (this.id == 'left') {
        imgIndex = imgIndex == 1 ? 8 : imgIndex-1;
    } else {
        imgIndex = imgIndex == 8 ? 1 : imgIndex+1;
    }
    $('#image').attr('src', `./imgs/${imgIndex}.jpg`)
});

$('#submit').click(function() {
    hideDisplay('submitted', 'show');
    $('#submitted span').text(function() {
        $(this).text($('#'+this.id.substring(1)).val());
    });
});

$('#back').click(function() { hideDisplay('complain','show'); });

$('#btnServices').click(function() { hideDisplay('serviceItems','slideDown'); })

function hideDisplay (toBeDisplayed, fun) {
    if (!!displayed) { displayed.hide(); }
    displayed = $('#'+toBeDisplayed)[fun]();
}