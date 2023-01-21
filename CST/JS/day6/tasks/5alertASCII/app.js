document.addEventListener('DOMContentLoaded', ()=>{
    document.body.addEventListener('keydown', (event)=>{
        var message = event.keyCode;
        if (event.shiftKey) {message += " - it's shift key";}
        if (event.altKey) {message += " - it's alt key";}
        if (event.ctrlKey) {message += " - it's ctrl key";}
        alert(message);
    });
});